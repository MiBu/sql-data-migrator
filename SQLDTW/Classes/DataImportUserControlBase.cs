using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SqlDtw.Classes;

namespace SqlDtw.Classes
{
    public class DataImportUserControlBase : UserControl
    {
        public delegate void IsBussyHandler(object sender, ControlBussyEventArgs args);
        public event IsBussyHandler IsBussy;

        public virtual void OnBussy(ControlBussyEventArgs args)
        {
            if (IsBussy != null)
                IsBussy(this, args);
        }

        public DataImportUserControlBase() : base() { }

        public DataTransferDefinition DataTransferDefinition { get; set; }
        public virtual void UpdateDataTransferDefinition(DataTransferDefinition definition) 
        {
            DataTransferDefinition = definition;
        }
        public virtual DataTransferDefinition PopulateDataTransferDefinition() { return this.DataTransferDefinition; }

        public virtual void Cancel()
        {
            this.Dispose();            
        }
    }
}
