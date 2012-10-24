using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SqlDtw.Classes
{
    public class TableDefinition : IEquatable<TableDefinition>, IComparable<TableDefinition>
    {
        [CategoryAttribute("General"),ReadOnlyAttribute(true)]
        public String Name { get; set; }
        [CategoryAttribute("General"), ReadOnlyAttribute(true)]
        public String SchemaName { get; set; }
        [BrowsableAttribute(false)]
        [DefaultValue(0)]
        public Int32 TransferOrder { get; set; }
        [BrowsableAttribute(false)]
        public String NameWithSchemaName { get { return "[" + SchemaName + "].[" + Name + "]"; }}
        [CategoryAttribute("Transfer option")]
        public Boolean TransferRelatedTables { get; set; }
        [CategoryAttribute("Transfer option")]
        public HandleExistingTableOptions HandleExistingTable { get; set; }


        public bool Equals(TableDefinition other)
        {
            if (this.Name == other.Name 
                && this.SchemaName == other.SchemaName) return true;
            
            return false;
        }        

        public int CompareTo(TableDefinition other)
        {
            if (this.TransferOrder > other.TransferOrder) return 1;
            else if (this.TransferOrder < other.TransferOrder) return -1;
            else return 0;
        }
    }

    public class TableDefinitionTransferOrderComparer : IComparer<TableDefinition>
    {

        public int Compare(TableDefinition x, TableDefinition y)
        {
            if (x.TransferOrder > y.TransferOrder) return 1;
            else if (x.TransferOrder < y.TransferOrder) return -1;
            else return 0;
        }
    }

    public class TableDefinitionComparer : IEqualityComparer<TableDefinition>
    {
        public bool Equals(TableDefinition x, TableDefinition y)
        {
            return x.Name == y.Name && x.SchemaName == y.SchemaName;
        }

        public int GetHashCode(TableDefinition definition)
        {
            if(Object.ReferenceEquals(definition,null)) return 0;

            int hashName = definition.Name == null ? 0 : definition.Name.GetHashCode();

            int hashSchemaName = definition.SchemaName == null ? 0 : definition.SchemaName.GetHashCode();

            return hashName ^ hashSchemaName ;
        }
    }
}
