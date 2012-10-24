using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Collections.Specialized;

namespace SqlDtw.Classes
{
    class BulkCopyTables
    {
        public delegate void TableCopiedHandler(object sender, TableCopiedEventArgs args);
        public event TableCopiedHandler TableCopied;

        public virtual void OnTableCopied(TableCopiedEventArgs args)
        {
            if (TableCopied != null)
                TableCopied(this, args);
        }

        private DataTransferDefinition definition;        
        private long count;
        private Boolean cancel = false;
        
        public void Cancel()
        {
            this.cancel = true;
        }

        public BulkCopyTables(DataTransferDefinition definition)
        {       
            this.definition = definition;
            //this.definition.DestinationServer.ConnectionContext.InfoMessage += new SqlInfoMessageEventHandler(ConnectionContext_InfoMessage);
        }

        //void ConnectionContext_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        //{
        //    if (e.Errors != null)                                    
        //        SendErrorMessage(e.Message + "\r\n");                       
        //}

        public void TransferData()
        {
                                    
            //List<TableDefinition> distinctTables = definition.TablesForTransfer.Distinct(new TableDefinitionComparer()).ToList();
            //definition.TablesForTransfer = distinctTables.OrderByDescending(x => x, new TableDefinitionTransferOrderComparer()).ToList<TableDefinition>();            

            foreach (TableDefinition table in definition.TablesForTransfer.OrderBy(x => x, new TableDefinitionTransferOrderComparer()).ToList())
            {
                if (cancel) return;
                //handle destination table existing data options
                switch (table.HandleExistingTable)
                {
                    case HandleExistingTableOptions.LeaveExisting :
                        break;
                    case HandleExistingTableOptions.DeleteData :
                        DeleteDataInDestinationTable(table.Name, table.SchemaName);
                        break;
                    case HandleExistingTableOptions.TruncateData :
                        TruncateDataInDestinationTable(table.Name, table.SchemaName);
                        break;
                    case HandleExistingTableOptions.RecreateTable :
                        RecreateDestinationTable(table.Name, table.SchemaName);
                        break;
                    default: break;
                }
            }            

            foreach (TableDefinition table in definition.TablesForTransfer)
            {
                if (cancel) return;
                using(SqlConnection conn = definition.SourceConnection)                    
                {                                        
                    conn.Open();                    
                    //Izbroji retke i posalji notifikaciju
                    SqlCommand rowCount = new SqlCommand("SELECT COUNT(*) FROM "+table.NameWithSchemaName);
                    rowCount.Connection = conn;
                    count = System.Convert.ToInt32(rowCount.ExecuteScalar());
                    
                    String status = "Transfering "+count+" rows from "+table.NameWithSchemaName+"\r\n";
                    TableCopiedEventArgs args = new TableCopiedEventArgs();
                    args.Message = status;
                    args.MessageType = MessageTypesEnum.Normal;
                    args.ProgressPercentage = 0;
                    OnTableCopied(args);

                    using(SqlConnection destinationConn = definition.DestinationConnection)
                    {
                        destinationConn.Open();
                        
                        using (SqlBulkCopy destinationBulkImport = new SqlBulkCopy(definition.DestinationConnection.ConnectionString, SqlBulkCopyOptions.KeepIdentity | SqlBulkCopyOptions.CheckConstraints))
                        {

                            ColumnCollection sourceColumns = definition.SourceServer.Databases[definition.SourceDatabase].Tables[table.Name, table.SchemaName].Columns;
                            ColumnCollection destinationColumns = definition.DestinationServer.Databases[definition.DestinationDatabase].Tables[table.Name, table.SchemaName].Columns;
                            string columnList = String.Empty;
                            foreach (Column c in sourceColumns)
                            {
                                if (!c.Computed)
                                {
                                    
                                    string safeName = "[" + c.Name + "]";

                                    SqlBulkCopyColumnMapping mapping = new SqlBulkCopyColumnMapping(safeName, c.Name);
                                    destinationBulkImport.ColumnMappings.Add(mapping);

                                    if(c.DataType.SqlDataType == SqlDataType.VarChar 
                                        || c.DataType.SqlDataType == SqlDataType.VarCharMax
                                        || c.DataType.SqlDataType == SqlDataType.NVarChar
                                        || c.DataType.SqlDataType == SqlDataType.NVarCharMax
                                        || c.DataType.SqlDataType == SqlDataType.Char
                                        || c.DataType.SqlDataType == SqlDataType.NChar 
                                        )
                                    {
                                        string destinationCollation = String.IsNullOrEmpty(destinationColumns[c.Name].Collation) ? definition.DestinationServer.Databases[definition.DestinationDatabase].Collation : destinationColumns[c.Name].Collation;
                                        safeName += " COLLATE "+ destinationCollation + " AS " + safeName;
                                    }
                                    columnList += safeName + ",";
                                    
                                    
                                }

                            }
                            columnList = columnList.Substring(0, columnList.LastIndexOf(','));
                            SqlCommand sourceDataCommand = new SqlCommand("SELECT " + columnList + " FROM " + table.NameWithSchemaName);
                            sourceDataCommand.Connection = conn;
                            SqlDataReader reader = sourceDataCommand.ExecuteReader();
             
                            //TODO: ubaciti property za provjeravanje constrainta, zašvasano na true

                            
                            destinationBulkImport.BatchSize = 10000;                            
                            destinationBulkImport.NotifyAfter = 10000;
                            destinationBulkImport.SqlRowsCopied += new SqlRowsCopiedEventHandler(sourceBulkExport_SqlRowsCopied);
                            destinationBulkImport.DestinationTableName = table.NameWithSchemaName;                            
                            
                            //Copy data                
                            try
                            {                                
                                destinationBulkImport.WriteToServer(reader);
                                //Status
                                status = "Transfered " + count + " rows for " + table.NameWithSchemaName + "\r\n";
                                args = new TableCopiedEventArgs();
                                args.Message = status;
                                args.MessageType = MessageTypesEnum.Highlight;
                                args.ProgressPercentage = 100;
                                OnTableCopied(args);
                                
                            }
                            catch (Exception ex)
                            {                                
                                SendErrorMessage(ex);
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }                                         
                    }
                }                
            }
        }

        void sourceBulkExport_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            String status = "Transfered " + e.RowsCopied + " rows." + "\r\n";
            TableCopiedEventArgs args = new TableCopiedEventArgs();
            args.Message = status;
            args.MessageType = MessageTypesEnum.Normal;
            args.ProgressPercentage = (int)((e.RowsCopied / (float)count) * 100);
            OnTableCopied(args);
        }

        private void RecreateDestinationTable(String tableName, String schemaName)
        {
            try
            {
                StringCollection tableScript;
                StringCollection schemaScript;

                Database db = definition.DestinationServer.Databases[definition.DestinationDatabase];
                Table t = db.Tables[tableName, schemaName];

                if (t == null)
                {
                    //If table does not exist, create one
                    Database db2 = definition.SourceServer.Databases[definition.SourceDatabase];
                    t = db2.Tables[tableName, schemaName];
                    Schema s = db2.Schemas[schemaName];
                    schemaScript = s.Script();
                    tableScript = t.Script();
                    schemaScript.Remove("USE " + db2.Name);
                    tableScript.Remove("USE " + db2.Name);

                    if (db.Schemas[schemaName] == null)
                        db.ExecuteNonQuery(schemaScript);
                }
                else
                {
                    //if table exists recreate it
                    tableScript = t.Script();
                    t.Drop();
                }

                db.ExecuteNonQuery(tableScript);
            }
            catch (Exception ex)
            {
                SendErrorMessage(ex);
            }
        }
        private void TruncateDataInDestinationTable(String tableName, String schemaName)
        {
            try
            {
                Database db = definition.DestinationServer.Databases[definition.DestinationDatabase];
                Table t = db.Tables[tableName, schemaName];
                t.TruncateData();                
                SendMessage("Truncated data from [" + schemaName + "].[" + tableName + "]\r\n");
            }
            catch (Exception ex)
            {
                SendErrorMessage("Error: TRUNCATE failed on table [" + schemaName + "].[" + tableName + "]\r\n");
                SendErrorMessage(ex);               
            }

        }
        private void DeleteDataInDestinationTable(String tableName, String schemaName)
        {
            try
            {                
                Database db = definition.DestinationServer.Databases[definition.DestinationDatabase];                
                Table t = db.Tables[tableName, schemaName];            
                db.ExecuteNonQuery("DELETE FROM ["+schemaName+"].["+tableName+"]");
                SendMessage("Deleted data from [" + schemaName + "].[" + tableName + "]\r\n");
            }
            catch (Exception ex)
            {
                SendErrorMessage("Error: DELETE failed on table [" + schemaName + "].[" + tableName + "]\r\n");
                SendErrorMessage(ex);               
            }
        }

        private void SendErrorMessage(Exception ex)
        {
            TableCopiedEventArgs args = new TableCopiedEventArgs();
            args.Message= "Error: " + ex.Message + " " + (ex.InnerException != null ? ex.InnerException.Message : "") + "\r\n";                        
            args.MessageType = MessageTypesEnum.Error;
            args.ProgressPercentage = 100;
            OnTableCopied(args);
        }

        private void SendErrorMessage(String message)
        {
            TableCopiedEventArgs args = new TableCopiedEventArgs();
            args.Message = message;
            args.MessageType = MessageTypesEnum.Error;
            args.ProgressPercentage = 100;
            OnTableCopied(args);
        }

        private void SendMessage(String message)
        {
            TableCopiedEventArgs args = new TableCopiedEventArgs();
            args.Message = message;
            args.MessageType = MessageTypesEnum.Normal;            
            OnTableCopied(args);
        }
    }
}
