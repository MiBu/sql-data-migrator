using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlDtw.Utils
{

    public static class SqlServerAuthenticationTypes
    {
        private static List<SqlServerAuthenticationType> types = null;

        public static List<SqlServerAuthenticationType> GetDefaultAuthenticationTypes()
        {
            if (types == null)
            {
                types = new List<SqlServerAuthenticationType>();
                types.Add(new SqlServerAuthenticationType { Name = "Windows Authentication", TypeEnum = SqlServerAuthenticationTypeEnum.WindowsAuthentication });
                types.Add(new SqlServerAuthenticationType { Name = "SQL Server Authentication", TypeEnum = SqlServerAuthenticationTypeEnum.SqlServerAuthentication });
            }
            return types;
        }
    }
}
