using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SqlDtw.Classes;

namespace SqlDtw.Forms
{
    public partial class CompletedControl : DataImportUserControlBase
    {
        public CompletedControl()
        {
            InitializeComponent();
        }

        private void CompletedControl_Load(object sender, EventArgs e)
        {
            if (this.DataTransferDefinition.Error)
                lblSummary.ForeColor = Color.Red;
            else
                lblSummary.ForeColor = Color.Green;

            lblSummary.Text = this.DataTransferDefinition.EndStatus;
            rtbStatus.Text = this.DataTransferDefinition.StatusMessages;
        }
    }
}
