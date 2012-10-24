using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Server;
using SqlDtw.Utils;
using System.Data.SqlClient;

namespace SqlDtw.Classes
{
    public class DataTransferDefinition
    {
        public Server SourceServer { get; set; }
        public String SourceServerAddress { get; set; }
        public String SourceUserName { get; set; }
        public String SourcePassword { get; set; }
        public SqlServerAuthenticationTypeEnum SourceAuthenticationType { get; set; }
        public Server DestinationServer { get; set; }
        public String DestinationServerAddress { get; set; }
        public String DestinationUserName { get; set; }
        public String DestinationPassword { get; set; }
        public SqlServerAuthenticationTypeEnum DestinationAuthenticationType { get; set; }
        public String SourceDatabase { get; set; }
        public String DestinationDatabase { get; set; }
        public SqlConnection SourceConnection { 
            get
            {
                String connectionString = "Data Source=" + SourceServerAddress
                    + ";Database=" + SourceDatabase + ";MultipleActiveResultSets=true;";
                if (SourceAuthenticationType == SqlServerAuthenticationTypeEnum.WindowsAuthentication)
                    connectionString += "Trusted_Connection=True;";
                else
                {
                    connectionString += "User Id=" + SourceUserName + ";Password=" + SourcePassword + ";";
                }
                return new SqlConnection(connectionString);
            }
        }
        public SqlConnection DestinationConnection { 
            get
            {
                String connectionString = "Data Source=" + DestinationServerAddress
                    + ";Database=" + DestinationDatabase + ";MultipleActiveResultSets=true;";
                if (DestinationAuthenticationType == SqlServerAuthenticationTypeEnum.WindowsAuthentication)
                    connectionString += "Trusted_Connection=True;";
                else
                {
                    connectionString += "User Id=" + DestinationUserName + ";Password=" + DestinationPassword + ";";
                }
                return new SqlConnection(connectionString);
            }
        }
        public List<TableDefinition> TablesForTransfer { get; set; }

        public String EndStatus { get; set; }
        public Boolean Error { get; set; }        
        public String StatusMessages { get; set; }
    }
}
