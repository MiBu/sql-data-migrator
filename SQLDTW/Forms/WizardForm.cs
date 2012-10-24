using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SqlDtw.Classes;

namespace SqlDtw.Forms
{
    public partial class WizardForm : Form
    {
        private List<DataImportUserControlBase> userControls;
        private DataTransferDefinition dataTransferDefinition;
        private int currentIndex = 0;

        public WizardForm()
        {
            InitializeComponent();
            dataTransferDefinition = new DataTransferDefinition();
            userControls = new List<DataImportUserControlBase>();
            userControls.Add(new ServerConfigurationControl());
            userControls.Add(new TableSelectionControl());
            userControls.Add(new ProgressControl());
            userControls.Add(new CompletedControl());
            move(0);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            move(-1);
        }

        private void move(int count)
        {
            currentIndex += count;

            if (currentIndex == userControls.Count -1)
            {
                btnNext.Enabled = false;
                btnBack.Enabled = true;
                btnFinishCancel.Text = "Finish";
            }
            else
            {
                btnNext.Enabled = true;
                btnBack.Enabled = true;
                btnFinishCancel.Text = "Cancel";

                if (currentIndex == 0)
                    btnBack.Enabled = false;
            }

            DataImportUserControlBase control = userControls[currentIndex];
            control.IsBussy += new DataImportUserControlBase.IsBussyHandler(control_IsBussy);
            control.UpdateDataTransferDefinition(dataTransferDefinition);
            control.Parent = mainPanel;
            control.Dock = DockStyle.Fill;            
            control.Show();
            control.BringToFront();
        }

        void control_IsBussy(object sender, ControlBussyEventArgs args)
        {
            Cursor.Current = Cursors.WaitCursor;
            btnNext.Enabled = !(args.IsBussy);
            btnBack.Enabled = !(args.IsBussy);
            Cursor.Current = Cursors.Default;
        }

        private void WizardForm_Load(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //save changes on current control
            this.dataTransferDefinition = userControls[currentIndex].PopulateDataTransferDefinition();           
            //move to the next control
            Cursor.Current = Cursors.WaitCursor;
            move(1);
            Cursor.Current = Cursors.Default;
        }

        private void btnFinishCancel_Click(object sender, EventArgs e)
        {
            DataImportUserControlBase control = userControls[currentIndex];
            control.Cancel();
            this.Close();           
        }
    }
}
