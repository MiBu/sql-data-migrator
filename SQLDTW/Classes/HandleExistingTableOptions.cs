using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlDtw.Classes
{
    public enum HandleExistingTableOptions
    {
        RecreateTable,
        TruncateData,
        DeleteData,
        LeaveExisting
    }
}
