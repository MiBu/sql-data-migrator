using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SqlDtw.Classes
{
    class TableCopiedEventArgs
    {
        public int ProgressPercentage { get; set; }
        public String Message { get; set; }
        [DefaultValue(MessageTypesEnum.Normal)]
        public MessageTypesEnum MessageType { get; set; }
    }
}
