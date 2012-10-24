using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Server;
using SqlDtw.Classes;

namespace SqlDtw.Utils
{
    static class SqlServerConnectionUtils
    {
        public static TestServerConnectionResult TestSqlServerConnection(String serverAddress, SqlServerAuthenticationType authenticatonType, String userName, String password)
        {
            TestServerConnectionResult result = new TestServerConnectionResult();
            result.Result = false;
            result.Message = String.Empty;

            //Test server connection
            if (authenticatonType.TypeEnum == SqlServerAuthenticationTypeEnum.WindowsAuthentication)
            {
                try
                {
                    ServerConnection conn = new ServerConnection(serverAddress);
                    
                    conn.Connect();                                        
                    conn.Disconnect();

                    result.Result = true;
                    result.Connection = conn;
                    result.Message = "Connection established!";
                }
                catch (Exception ex)
                {
                    result.Message = ex.Message + " " + (ex.InnerException != null ? ex.InnerException.Message : "");
                }
            }
            else if (authenticatonType.TypeEnum == SqlServerAuthenticationTypeEnum.SqlServerAuthentication)
            {
                try
                {
                    ServerConnection conn = new ServerConnection(serverAddress, userName, password);

                    conn.Connect();
                    conn.Disconnect();

                    result.Result = true;
                    result.Connection = conn;
                    result.Message = "Connection established!";
                }
                catch (Exception ex)
                {
                    result.Message = ex.Message + " " + (ex.InnerException != null ? ex.InnerException.Message : "");
                }
            }            

            return result;
        }

        public static Server GetSqlServerObject(String serverAddress, SqlServerAuthenticationType authenticationType, String userName, String password)
        {
            Server srv = null;
            TestServerConnectionResult result = TestSqlServerConnection(serverAddress, authenticationType, userName, password);

            if (result.Result)
                srv = new Server(result.Connection);

            return srv;
        }

        public static Server GetSqlServerObject(ServerConnection connection)
        {
            return new Server(connection);                        
        }

        public static List<String> GetServerDatabaseList(ServerConnection connection)
        {
            List<String> databases = new List<string>();
            Server srv = GetSqlServerObject(connection);
            
            foreach (Database d in srv.Databases)
                databases.Add(d.Name);

            return databases;
        }

        public static List<String> GetServerDatabaseList(Server server)
        {
            List<String> databases = new List<string>();

            foreach (Database d in server.Databases)
                databases.Add(d.Name);

            return databases;
        }

        public static List<TableDefinition> GetDatabaseTableList(Server server, String databaseName)
        {
            List<TableDefinition> tableDefinitions = new List<TableDefinition>();

            Database db = server.Databases[databaseName];
            foreach (Table t in db.Tables)
            {
                TableDefinition table = new TableDefinition();
                table.Name = t.Name;
                table.SchemaName = t.Schema;

                tableDefinitions.Add(table);
            }

            return tableDefinitions;
        }

        private static List<TableDefinition> WalkTableDependency(DependencyTreeNode node, int startOrderNumber)
        {
            startOrderNumber++;
            DependencyTreeNode nextNode = null;
            List<TableDefinition> tables = new List<TableDefinition>();
          
            if (node.HasChildNodes)
            {
                tables.AddRange(WalkTableDependency(node.FirstChild, startOrderNumber));
            }
            if (node.NumberOfSiblings > 1 && (nextNode = node.NextSibling) != null)
            {
                tables.AddRange(WalkTableDependency(nextNode, startOrderNumber));
                //if(nextNode.HasChildNodes)
                //    tables.AddRange(WalkTableDependency(node.FirstChild, startOrderNumber));
            }
            if (node.Urn.Type == "Table")
            {
                tables.Add(CreateTableDefinition(node, startOrderNumber));                         
            }                                    
            return tables;
        }

        private static TableDefinition CreateTableDefinition(DependencyTreeNode node, int orderNumber)
        {
            TableDefinition t = new TableDefinition();
            t.Name = node.Urn.GetAttribute("Name");
            t.SchemaName = node.Urn.GetAttribute("Schema");
            t.TransferOrder = orderNumber;
            return t;
        }

        public static List<TableDefinition> GetRelatedTables(Server server, String databaseName, String tableName, String schemaName, int startTransferOrder)
        {
            List<TableDefinition> tables = new List<TableDefinition>();
            DependencyWalker walker = new DependencyWalker(server);
            Table table = server.Databases[databaseName].Tables[tableName,schemaName];
            DependencyTree parrentTree = walker.DiscoverDependencies(new Urn[] {table.Urn}, true);
            //DependencyTree childTree = walker.DiscoverDependencies(new Urn[] { table.Urn }, false);            
            DependencyCollection parrentColl = walker.WalkDependencies(parrentTree);
            //DependencyCollection childColl = walker.WalkDependencies(childTree);
            
            //Vraca sve parente trenutne tablice (sve razine) -> svi ti objekti se trbebaju prenjeti prije same tablice (imaju veci transfer order)
            //Za svaki od njih koji dodatno ima 
            tables.AddRange(WalkTableDependency(parrentTree.FirstChild, startTransferOrder));
            //tables.AddRange(WalkTableDependency(childTree.FirstChild, startTransferOrder - 1));

            return tables;            
        }        
    }
}
