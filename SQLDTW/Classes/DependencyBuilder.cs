using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlDtw.Utils;

namespace SqlDtw.Classes
{
    public class DependencyBuilder
    {
        private DataTransferDefinition definition;
        public delegate void DependencyBuiltHandler(object sender, DependencyBuildEventArgs e);
        public event DependencyBuiltHandler DependencyBuilt;

        public DependencyBuilder(DataTransferDefinition definition)
        {
            this.definition = definition;
        }

        public List<TableDefinition> BuildDependencies(List<TableDefinition> tables)
        {
            List<TableDefinition> dependencies = new List<TableDefinition>();
            foreach (TableDefinition t in tables)
            {
                if (t.TransferRelatedTables)
                {
                    List<TableDefinition> dependentTables = SqlServerConnectionUtils.GetRelatedTables(definition.SourceServer, definition.SourceDatabase, t.Name, t.SchemaName, t.TransferOrder);
                    if (dependentTables != null)                    
                        if(dependentTables.Count > 1)
                        {
                            foreach(TableDefinition dt in dependentTables)
                            {
                                //Propagate settings
                                dt.TransferRelatedTables = t.TransferRelatedTables;
                                dt.HandleExistingTable = t.HandleExistingTable;                            
                            }
                            dependentTables.Remove(t);
                            dependencies.AddRange(BuildDependencies(dependentTables));
                            //
                            dependencies.Add(t);
                            dependencies.AddRange(dependentTables);
                        }
                }
            }
            return dependencies;
        }

        public List<TableDefinition> BuildDependencies()
        {
            List<TableDefinition> dependencies = new List<TableDefinition>();

            for (int j = 0; j < definition.TablesForTransfer.Count; j++)
            {
                TableDefinition table = definition.TablesForTransfer[j];
                if (dependencies.Exists(x => x.Name == table.Name && x.SchemaName == table.SchemaName && table.TransferOrder > 0))
                    continue;

                String status = String.Empty;
                if (table.TransferRelatedTables)
                {
                    List<TableDefinition> dependentTables = SqlServerConnectionUtils.GetRelatedTables(definition.SourceServer, definition.SourceDatabase, table.Name, table.SchemaName, table.TransferOrder);
                    //Inherit settings
                    
                    if (dependentTables != null)
                    {
                        foreach (TableDefinition t in dependentTables)
                        {
                            t.TransferRelatedTables = table.TransferRelatedTables;
                            t.HandleExistingTable = table.HandleExistingTable;
                            definition.TablesForTransfer.Where(x => x.Name == t.Name && x.SchemaName == t.SchemaName).First().TransferOrder = t.TransferOrder;
                        }

                        if (dependentTables.Count > 1)
                        {
                            status = "Tables that depend on " + table.NameWithSchemaName + ": \r\n";
                            for (int i = 1; i < dependentTables.Count; i++)
                                status += dependentTables[i].NameWithSchemaName + "\r\n";
                        }

                        DependencyBuildEventArgs args = new DependencyBuildEventArgs();
                        args.Result = (int)(((float)(j + 1) / definition.TablesForTransfer.Count) * 100);
                        args.Message = status;
                        args.MessageType = MessageTypesEnum.Normal;
                        OnDependencyBuilt(args);
                        dependencies.AddRange(dependentTables);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    dependencies.Add(table);
                }
            }
            return dependencies;
        }

        protected virtual void OnDependencyBuilt(DependencyBuildEventArgs e)
        {
            if (DependencyBuilt != null)
                DependencyBuilt(this, e);
        }
    }
}
