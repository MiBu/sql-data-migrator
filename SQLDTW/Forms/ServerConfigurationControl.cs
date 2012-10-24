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
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Server;

namespace SqlDtw.Forms
{
    public partial class ServerConfigurationControl : DataImportUserControlBase
    {                
        public ServerConfigurationControl()
        {
            InitializeComponent();
        }        

        private String sourceServerAddress = String.Empty;        
        private SqlServerAuthenticationType sourceAuthenticationType;
        private String sourceUserName;
        private String sourcePassword;
        private String sourceDatabase;

        private String destinationServerAddress = String.Empty;
        private SqlServerAuthenticationType destinationAuthenticationType;
        private String destinationUserName;
        private String destinationPassword;
        private String destinationDatabase;

        private bool ValidateSourceSettings()
        {
            sourceServerAddress = tbSourceServerAddress.Text;
            sourceAuthenticationType = (SqlServerAuthenticationType)cbSourceAuthenticationType.SelectedItem;
            sourceUserName = tbSourceUserName.Text;
            sourcePassword = tbSourcePassword.Text;

            if (sourceAuthenticationType.TypeEnum == SqlServerAuthenticationTypeEnum.WindowsAuthentication)
            {
                if (!String.IsNullOrEmpty(sourceServerAddress)) return true;
            }
            else if (sourceAuthenticationType.TypeEnum == SqlServerAuthenticationTypeEnum.SqlServerAuthentication)
            {
                if (String.IsNullOrEmpty(sourceServerAddress)) return false;
                if (String.IsNullOrEmpty(sourceUserName)) return false;
                if (String.IsNullOrEmpty(sourcePassword)) return false;

                return true;
            }
            return false;
        }

        private bool ValidateDestinationSettings()
        {
            destinationServerAddress = tbDestinationServerAddress.Text;
            destinationAuthenticationType = (SqlServerAuthenticationType)cbDestinationAuthenticationType.SelectedItem;
            destinationUserName = tbDestinationUserName.Text;
            destinationPassword = tbDestinationPassword.Text;

            if (destinationAuthenticationType.TypeEnum == SqlServerAuthenticationTypeEnum.WindowsAuthentication)
            {
                if (!String.IsNullOrEmpty(destinationServerAddress)) return true;
            }
            else if (destinationAuthenticationType.TypeEnum == SqlServerAuthenticationTypeEnum.SqlServerAuthentication)
            {
                if (String.IsNullOrEmpty(destinationServerAddress)) return false;
                if (String.IsNullOrEmpty(destinationUserName)) return false;
                if (String.IsNullOrEmpty(destinationPassword)) return false;

                return true;
            }
            return false;
        }

        private bool ValidateNextSettings()
        {
            if (ValidateSourceSettings() && ValidateDestinationSettings())
            {
                if (String.IsNullOrEmpty(sourceDatabase)) return false;
                if (String.IsNullOrEmpty(destinationDatabase)) return false;

                return true;
            }

            return false;
        }

        private void CopySourceSettingsToDestinationSettings()
        {
            tbDestinationServerAddress.Text = tbSourceServerAddress.Text;            
            cbDestinationAuthenticationType.SelectedIndex = cbSourceAuthenticationType.SelectedIndex;            
            tbDestinationUserName.Text = tbSourceUserName.Text;
            tbDestinationPassword.Text = tbSourcePassword.Text;
            cbDestinationDatabase_MouseClick(null, null);
            cbDestinationDatabase.SelectedIndex = cbSourceDatabase.SelectedIndex;
        }

        private void btnSourceTestConnection_Click(object sender, EventArgs e)
        {
            if (ValidateSourceSettings())
            {
                Cursor.Current = Cursors.WaitCursor;
                TestServerConnectionResult result = SqlServerConnectionUtils.TestSqlServerConnection(sourceServerAddress, sourceAuthenticationType, sourceUserName, sourcePassword);
                Cursor.Current = Cursors.Default;
                if (result.Result)
                {
                    //MessageBox.Show("Connection successfull!", "Connection test", MessageBoxButtons.OK);
                    cbSourceDatabase.Enabled = true;
                    btnCopyConfiguration.Enabled = true;
                }
                else
                {
                    MessageBox.Show(result.Message, "Connection error", MessageBoxButtons.OK);
                }
            }
        }

        private void btnDestinationTestConnection_Click(object sender, EventArgs e)
        {            
            if (ValidateDestinationSettings())
            {
                Cursor.Current = Cursors.WaitCursor;
                TestServerConnectionResult result = SqlServerConnectionUtils.TestSqlServerConnection(destinationServerAddress, destinationAuthenticationType, destinationUserName, destinationPassword);
                Cursor.Current = Cursors.Default;
                if (result.Result)
                {
                    //MessageBox.Show("Connection successfull!", "Connection test", MessageBoxButtons.OK);
                    cbDestinationDatabase.Enabled = true;
                    btnNewDestinationDatabase.Enabled = true;
                }
                else
                {
                    MessageBox.Show(result.Message, "Connection error", MessageBoxButtons.OK);
                }
            }
        }

        private void ServerConfigurationControl_Load(object sender, EventArgs e)
        {
            cbSourceAuthenticationType.DisplayMember = "Name";
            cbSourceAuthenticationType.ValueMember = "TypeEnum";
            cbDestinationAuthenticationType.DisplayMember = "Name";
            cbDestinationAuthenticationType.ValueMember = "TypeEnum";

            cbSourceAuthenticationType.Items.AddRange(SqlServerAuthenticationTypes.GetDefaultAuthenticationTypes().ToArray());
            cbSourceAuthenticationType.SelectedIndex = 0;
            cbDestinationAuthenticationType.Items.AddRange(SqlServerAuthenticationTypes.GetDefaultAuthenticationTypes().ToArray());
            cbDestinationAuthenticationType.SelectedIndex = 0;            
        }
              
        private void cbSourceAuthenticationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DataTransferDefinition.SourceAuthenticationType = ((SqlServerAuthenticationType)(cbSourceAuthenticationType.SelectedItem)).TypeEnum;
            tbSourceUserName.Enabled = (((SqlServerAuthenticationType)(cbSourceAuthenticationType.SelectedItem)).TypeEnum == SqlServerAuthenticationTypeEnum.SqlServerAuthentication);
            tbSourcePassword.Enabled = (((SqlServerAuthenticationType)(cbSourceAuthenticationType.SelectedItem)).TypeEnum == SqlServerAuthenticationTypeEnum.SqlServerAuthentication);

        }

        private void cbDestinationAuthenticationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DataTransferDefinition.DestinationAuthenticationType = ((SqlServerAuthenticationType)(cbDestinationAuthenticationType.SelectedItem)).TypeEnum;
            tbDestinationUserName.Enabled = (((SqlServerAuthenticationType)(cbDestinationAuthenticationType.SelectedItem)).TypeEnum == SqlServerAuthenticationTypeEnum.SqlServerAuthentication);
            tbDestinationPassword.Enabled = (((SqlServerAuthenticationType)(cbDestinationAuthenticationType.SelectedItem)).TypeEnum == SqlServerAuthenticationTypeEnum.SqlServerAuthentication);
        }

        private void btnCopyConfiguration_Click(object sender, EventArgs e)
        {
            CopySourceSettingsToDestinationSettings();
            cbDestinationDatabase.Enabled = true;
            btnNewDestinationDatabase.Enabled = true;
            tbDestinationServerAddress_Validated(this, null);
        }

        private void cbSourceDatabase_MouseClick(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<String> databases = null;
            cbSourceDatabase.Items.Clear();            

            if (ValidateSourceSettings())
            {
                TestServerConnectionResult result = SqlServerConnectionUtils.TestSqlServerConnection(sourceServerAddress, sourceAuthenticationType, sourceUserName, sourcePassword);
                if (result.Result)
                {
                    
                    databases = SqlServerConnectionUtils.GetServerDatabaseList(result.Connection);
                    cbSourceDatabase.Items.AddRange(databases.ToArray());                    
                }
                else
                {
                    MessageBox.Show(result.Message, "Connection error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Wrong parameters entered", "Validation Error", MessageBoxButtons.OK);
            }
            Cursor.Current = Cursors.Default;
        }        

        private void cbDestinationDatabase_MouseClick(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<String> databases = null;
            cbDestinationDatabase.Items.Clear();

            if (ValidateDestinationSettings())
            {
                TestServerConnectionResult result = SqlServerConnectionUtils.TestSqlServerConnection(destinationServerAddress, destinationAuthenticationType, destinationUserName, destinationPassword);
                if (result.Result)
                {                    
                    databases = SqlServerConnectionUtils.GetServerDatabaseList(result.Connection);
                    cbDestinationDatabase.Items.AddRange(databases.ToArray());                    
                }
                else
                {
                    MessageBox.Show(result.Message, "Connection error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Wrong parameters entered", "Validation Error", MessageBoxButtons.OK);
            }
            Cursor.Current = Cursors.Default;
        }

        private void tbSourceServerAddress_Validated(object sender, EventArgs e)
        {
            cbSourceDatabase.Items.Clear();
        }

        private void tbDestinationServerAddress_Validated(object sender, EventArgs e)
        {
            cbDestinationDatabase.Items.Clear();            
        }

        private void btnNewDestinationDatabase_Click(object sender, EventArgs e)
        {
            if (ValidateDestinationSettings())
            {
                Server srv = SqlServerConnectionUtils.GetSqlServerObject(destinationServerAddress, destinationAuthenticationType, destinationUserName, destinationPassword);
                StringResult newDatabase = NewDatabaseForm.ShowDialog(srv);
                if (newDatabase != null)
                {
                    if (newDatabase.Successfull)
                    {
                        cbDestinationDatabase_MouseClick(null, null);
                    }
                    else
                    {
                        MessageBox.Show(newDatabase.Message, "Error", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("Wrong parameters entered", "Validation Error", MessageBoxButtons.OK);
            }
            
        }

        private void cbSourceDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            sourceDatabase = (String)cbSourceDatabase.SelectedItem;
        }

        private void cbDestinationDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            destinationDatabase = (String)cbDestinationDatabase.SelectedItem;
        }

        public override DataTransferDefinition PopulateDataTransferDefinition()
        {
            Server sourceServer = SqlServerConnectionUtils.GetSqlServerObject(sourceServerAddress,sourceAuthenticationType,sourceUserName,sourcePassword);
            Server destinationServer = SqlServerConnectionUtils.GetSqlServerObject(destinationServerAddress,destinationAuthenticationType,destinationUserName,destinationPassword);

            if (sourceServer != null && destinationServer != null && ValidateNextSettings())
            {
                this.DataTransferDefinition.SourceServer = sourceServer;
                this.DataTransferDefinition.DestinationServer = destinationServer;
                this.DataTransferDefinition.SourceDatabase = sourceDatabase;
                this.DataTransferDefinition.DestinationDatabase = destinationDatabase;
                this.DataTransferDefinition.SourceUserName = sourceUserName;
                this.DataTransferDefinition.DestinationUserName = destinationUserName;
                this.DataTransferDefinition.SourcePassword = sourcePassword;
                this.DataTransferDefinition.DestinationPassword = destinationPassword;
                this.DataTransferDefinition.SourceServerAddress = sourceServerAddress;
                this.DataTransferDefinition.DestinationServerAddress = destinationServerAddress;
            }
            else
            {
                MessageBox.Show("Wrong parameters entered", "Validation Error", MessageBoxButtons.OK);
            }

            return this.DataTransferDefinition;
        }

        public override void UpdateDataTransferDefinition(DataTransferDefinition definition)
        {
            this.DataTransferDefinition = definition;
        }

        private void tbSourceServerAddress_TextChanged(object sender, EventArgs e)
        {
            cbSourceDatabase.Enabled = false;
            btnCopyConfiguration.Enabled = false;
        }

        private void tbDestinationServerAddress_TextChanged(object sender, EventArgs e)
        {
            cbDestinationDatabase.Enabled = false;
            btnNewDestinationDatabase.Enabled = false;
        }
    }
}
