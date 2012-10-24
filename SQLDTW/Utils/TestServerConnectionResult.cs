using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace SqlDtw.Utils
{
    class TestServerConnectionResult
    {
        public bool Result { get; set; }
        public String Message { get; set; }
        public ServerConnection Connection { get; set; }

    }
}
