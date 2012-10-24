using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlDtw.Utils
{
    public class SqlServerAuthenticationType
    {
        public String Name { get; set; }
        public SqlServerAuthenticationTypeEnum TypeEnum;
    }

    public enum SqlServerAuthenticationTypeEnum
    {
        WindowsAuthentication,
        SqlServerAuthentication
    }
}
