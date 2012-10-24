using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SqlDtw.Classes;
using SqlDtw.Utils;

namespace SqlDtw.Forms
{    
    public partial class ProgressControl : DataImportUserControlBase
    {

        delegate void UpdateUICallback(DependencyBuildEventArgs args);
        delegate void UpdateUICallback2(TableCopiedEventArgs args); 

        List<TableDefinition> dependencies;
        BackgroundWorker worker;
        DependencyBuilder builder;
        BulkCopyTables copyTables;

        public ProgressControl()
        {
            InitializeComponent();            
        }

        public override void Cancel()
        {
            if(worker != null)
                worker.CancelAsync();
            base.Cancel();
        }

        private void ProgressControl_Load(object sender, EventArgs e)
        {
            dependencies = new List<TableDefinition>();          
        }        

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DataTransferDefinition.StatusMessages = tbStatus.Text;
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            Cursor.Current = Cursors.Default;

            OnBussy(new ControlBussyEventArgs { IsBussy = false });

            if (e.Cancelled)
            {
                this.DataTransferDefinition.EndStatus = "Canceled!";                
                //set status canceled
            }
            else if (!(e.Error == null))
            {
                //set status error
                RefreshStatus(e.Error.Message, MessageTypesEnum.Error);
                this.DataTransferDefinition.Error = true;
                this.DataTransferDefinition.EndStatus = "Finished with Error!";
            }
            else
            {
                this.DataTransferDefinition.EndStatus = "Success!";
                //set status done
            }
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            builder = new DependencyBuilder(this.DataTransferDefinition);
            copyTables = new BulkCopyTables(this.DataTransferDefinition);
                                                              
            builder.DependencyBuilt += new DependencyBuilder.DependencyBuiltHandler(builder_DependencyBuilt);

            DependencyBuildEventArgs args = new DependencyBuildEventArgs();
            args.Message = "Starting dependency build...\r\n";
            args.MessageType = MessageTypesEnum.Highlight;
            builder_DependencyBuilt(this, args);

            this.dependencies = builder.BuildDependencies();//(this.DataTransferDefinition.TablesForTransfer);
            var dependenciesOrderedDesc = dependencies.OrderByDescending(x => x, new TableDefinitionTransferOrderComparer()).ToList();
            this.DataTransferDefinition.TablesForTransfer = dependenciesOrderedDesc.Distinct(new TableDefinitionComparer()).ToList();

            args = new DependencyBuildEventArgs();
            args.Message = "Finished dependency build...\r\n";
            args.MessageType = MessageTypesEnum.Highlight;
            builder_DependencyBuilt(this, args);

            TableCopiedEventArgs args2 = new TableCopiedEventArgs();
            args2.Message = "Starting data transfer...\r\n";
            args2.MessageType = MessageTypesEnum.Highlight;
            copyTables_TableCopied(this, args2);
                
            copyTables.TableCopied += new BulkCopyTables.TableCopiedHandler(copyTables_TableCopied);
            copyTables.TransferData();

            args2 = new TableCopiedEventArgs();
            args2.Message = "Finisher data transfer...\r\n";
            args2.MessageType = MessageTypesEnum.Highlight;
            copyTables_TableCopied(this, args2);

        }

        private void RefreshStatus(String message, MessageTypesEnum messageType)
        {
            int currentTextLength = tbStatus.Text.Length;
            //if (currentTextLength > 7000)
            //{
            //    tbStatus.ResetText();
            //}
            //tbStatus.MaxLength = 8000;
            tbStatus.AppendText(message);
            tbStatus.SelectionStart = currentTextLength;
            tbStatus.SelectionLength = message.Length;
            
                //Color the line
            switch(messageType)
            {
                case MessageTypesEnum.Error:                                                    
                    tbStatus.SelectionColor = Color.Red;
                    break;
                case MessageTypesEnum.Highlight:
                    tbStatus.SelectionFont = new Font("Microsoft Sans Serif",(float)8.5,FontStyle.Bold);
                    break;
                case MessageTypesEnum.Normal:
                    break;

            }
            //move scroolbarr
            currentTextLength = tbStatus.Text.Length;
            tbStatus.SelectionStart = currentTextLength;
            tbStatus.ScrollToCaret();
            tbStatus.Refresh();
        }

        void copyTables_TableCopied(object sender, TableCopiedEventArgs args)
        {
            //Da mozemo provjeriti cancelation
            worker.ReportProgress(0);
     
            if (this.InvokeRequired)
            {
                UpdateUICallback2 c = new UpdateUICallback2((v) =>
                {
                    pbStatusBar.Value = args.ProgressPercentage;
                    RefreshStatus(args.Message, args.MessageType);
                });
                this.BeginInvoke(c, new object[] { args });
            }
        }

        void builder_DependencyBuilt(object sender, DependencyBuildEventArgs e)
        {
            //Da mozemo provjeriti cancelation
            worker.ReportProgress(0);

            if (this.InvokeRequired)
            {
                UpdateUICallback c = new UpdateUICallback((v) =>
                    {
                        pbStatusBar.Value = e.Result;
                        RefreshStatus(e.Message, e.MessageType);
                    });
                this.BeginInvoke(c, new object[] { e });
            }
        }

        public override void  UpdateDataTransferDefinition(DataTransferDefinition definition)
        {
 	        this.DataTransferDefinition = definition;
        }

        public override DataTransferDefinition  PopulateDataTransferDefinition()
        {
            this.DataTransferDefinition.StatusMessages = tbStatus.Text;            
            this.DataTransferDefinition.TablesForTransfer = dependencies;
            return this.DataTransferDefinition;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            OnBussy(new ControlBussyEventArgs { IsBussy = true });            
            worker.RunWorkerAsync();            
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (worker.CancellationPending)
            {
                copyTables.Cancel();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (worker != null)
            {
                worker.CancelAsync();
            }
        }     
    }
}
