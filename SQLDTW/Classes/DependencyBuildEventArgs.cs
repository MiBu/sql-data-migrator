using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SqlDtw.Classes
{
    public class DependencyBuildEventArgs
    {
        public int Result { get; set; }
        public String Message { get; set; }
        [DefaultValue(MessageTypesEnum.Normal)]
        public MessageTypesEnum MessageType { get; set; }
    }
}
