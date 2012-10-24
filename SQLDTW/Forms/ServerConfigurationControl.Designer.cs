namespace SqlDtw.Forms
{
    partial class ServerConfigurationControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbDestination = new System.Windows.Forms.GroupBox();
            this.btnDestinationTestConnection = new System.Windows.Forms.Button();
            this.btnNewDestinationDatabase = new System.Windows.Forms.Button();
            this.tbDestinationServerAddress = new System.Windows.Forms.TextBox();
            this.cbDestinationAuthenticationType = new System.Windows.Forms.ComboBox();
            this.tbDestinationUserName = new System.Windows.Forms.TextBox();
            this.cbDestinationDatabase = new System.Windows.Forms.ComboBox();
            this.tbDestinationPassword = new System.Windows.Forms.TextBox();
            this.lblDestinationDatabase = new System.Windows.Forms.Label();
            this.lblDestinationPassword = new System.Windows.Forms.Label();
            this.lblDestinationUserName = new System.Windows.Forms.Label();
            this.lblDestinationAuthentication = new System.Windows.Forms.Label();
            this.lblDestinationServerAddress = new System.Windows.Forms.Label();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.btnSourceTestConnection = new System.Windows.Forms.Button();
            this.lblSourceDatabase = new System.Windows.Forms.Label();
            this.lblSourcePassword = new System.Windows.Forms.Label();
            this.lblSourceUserName = new System.Windows.Forms.Label();
            this.lblSourceAuthenticationType = new System.Windows.Forms.Label();
            this.lblSourceServerAddress = new System.Windows.Forms.Label();
            this.tbSourceServerAddress = new System.Windows.Forms.TextBox();
            this.cbSourceAuthenticationType = new System.Windows.Forms.ComboBox();
            this.tbSourceUserName = new System.Windows.Forms.TextBox();
            this.cbSourceDatabase = new System.Windows.Forms.ComboBox();
            this.tbSourcePassword = new System.Windows.Forms.TextBox();
            this.btnCopyConfiguration = new System.Windows.Forms.Button();
            this.gbDestination.SuspendLayout();
            this.gbSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDestination
            // 
            this.gbDestination.Controls.Add(this.btnDestinationTestConnection);
            this.gbDestination.Controls.Add(this.btnNewDestinationDatabase);
            this.gbDestination.Controls.Add(this.tbDestinationServerAddress);
            this.gbDestination.Controls.Add(this.cbDestinationAuthenticationType);
            this.gbDestination.Controls.Add(this.tbDestinationUserName);
            this.gbDestination.Controls.Add(this.cbDestinationDatabase);
            this.gbDestination.Controls.Add(this.tbDestinationPassword);
            this.gbDestination.Controls.Add(this.lblDestinationDatabase);
            this.gbDestination.Controls.Add(this.lblDestinationPassword);
            this.gbDestination.Controls.Add(this.lblDestinationUserName);
            this.gbDestination.Controls.Add(this.lblDestinationAuthentication);
            this.gbDestination.Controls.Add(this.lblDestinationServerAddress);
            this.gbDestination.Location = new System.Drawing.Point(471, 15);
            this.gbDestination.Name = "gbDestination";
            this.gbDestination.Size = new System.Drawing.Size(358, 454);
            this.gbDestination.TabIndex = 19;
            this.gbDestination.TabStop = false;
            this.gbDestination.Text = "Destination";
            // 
            // btnDestinationTestConnection
            // 
            this.btnDestinationTestConnection.Location = new System.Drawing.Point(9, 272);
            this.btnDestinationTestConnection.Name = "btnDestinationTestConnection";
            this.btnDestinationTestConnection.Size = new System.Drawing.Size(145, 33);
            this.btnDestinationTestConnection.TabIndex = 30;
            this.btnDestinationTestConnection.Text = "Test connection";
            this.btnDestinationTestConnection.UseVisualStyleBackColor = true;
            this.btnDestinationTestConnection.Click += new System.EventHandler(this.btnDestinationTestConnection_Click);
            // 
            // btnNewDestinationDatabase
            // 
            this.btnNewDestinationDatabase.Enabled = false;
            this.btnNewDestinationDatabase.Location = new System.Drawing.Point(9, 402);
            this.btnNewDestinationDatabase.Name = "btnNewDestinationDatabase";
            this.btnNewDestinationDatabase.Size = new System.Drawing.Size(145, 33);
            this.btnNewDestinationDatabase.TabIndex = 29;
            this.btnNewDestinationDatabase.Text = "New database ...";
            this.btnNewDestinationDatabase.UseVisualStyleBackColor = true;
            this.btnNewDestinationDatabase.Click += new System.EventHandler(this.btnNewDestinationDatabase_Click);
            // 
            // tbDestinationServerAddress
            // 
            this.tbDestinationServerAddress.Location = new System.Drawing.Point(9, 54);
            this.tbDestinationServerAddress.Name = "tbDestinationServerAddress";
            this.tbDestinationServerAddress.Size = new System.Drawing.Size(343, 20);
            this.tbDestinationServerAddress.TabIndex = 24;
            this.tbDestinationServerAddress.TextChanged += new System.EventHandler(this.tbDestinationServerAddress_TextChanged);
            this.tbDestinationServerAddress.Validated += new System.EventHandler(this.tbDestinationServerAddress_Validated);
            // 
            // cbDestinationAuthenticationType
            // 
            this.cbDestinationAuthenticationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestinationAuthenticationType.FormattingEnabled = true;
            this.cbDestinationAuthenticationType.Location = new System.Drawing.Point(9, 115);
            this.cbDestinationAuthenticationType.Name = "cbDestinationAuthenticationType";
            this.cbDestinationAuthenticationType.Size = new System.Drawing.Size(343, 21);
            this.cbDestinationAuthenticationType.TabIndex = 25;
            this.cbDestinationAuthenticationType.SelectedIndexChanged += new System.EventHandler(this.cbDestinationAuthenticationType_SelectedIndexChanged);
            // 
            // tbDestinationUserName
            // 
            this.tbDestinationUserName.Enabled = false;
            this.tbDestinationUserName.Location = new System.Drawing.Point(9, 177);
            this.tbDestinationUserName.Name = "tbDestinationUserName";
            this.tbDestinationUserName.Size = new System.Drawing.Size(145, 20);
            this.tbDestinationUserName.TabIndex = 26;
            // 
            // cbDestinationDatabase
            // 
            this.cbDestinationDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestinationDatabase.Enabled = false;
            this.cbDestinationDatabase.FormattingEnabled = true;
            this.cbDestinationDatabase.Location = new System.Drawing.Point(9, 364);
            this.cbDestinationDatabase.Name = "cbDestinationDatabase";
            this.cbDestinationDatabase.Size = new System.Drawing.Size(343, 21);
            this.cbDestinationDatabase.TabIndex = 28;
            this.cbDestinationDatabase.SelectedIndexChanged += new System.EventHandler(this.cbDestinationDatabase_SelectedIndexChanged);
            this.cbDestinationDatabase.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbDestinationDatabase_MouseClick);
            // 
            // tbDestinationPassword
            // 
            this.tbDestinationPassword.Enabled = false;
            this.tbDestinationPassword.Location = new System.Drawing.Point(9, 238);
            this.tbDestinationPassword.Name = "tbDestinationPassword";
            this.tbDestinationPassword.PasswordChar = '*';
            this.tbDestinationPassword.Size = new System.Drawing.Size(145, 20);
            this.tbDestinationPassword.TabIndex = 27;
            // 
            // lblDestinationDatabase
            // 
            this.lblDestinationDatabase.AutoSize = true;
            this.lblDestinationDatabase.Location = new System.Drawing.Point(6, 335);
            this.lblDestinationDatabase.Name = "lblDestinationDatabase";
            this.lblDestinationDatabase.Size = new System.Drawing.Size(56, 13);
            this.lblDestinationDatabase.TabIndex = 23;
            this.lblDestinationDatabase.Text = "Database:";
            // 
            // lblDestinationPassword
            // 
            this.lblDestinationPassword.AutoSize = true;
            this.lblDestinationPassword.Location = new System.Drawing.Point(6, 211);
            this.lblDestinationPassword.Name = "lblDestinationPassword";
            this.lblDestinationPassword.Size = new System.Drawing.Size(56, 13);
            this.lblDestinationPassword.TabIndex = 22;
            this.lblDestinationPassword.Text = "Password:";
            // 
            // lblDestinationUserName
            // 
            this.lblDestinationUserName.AutoSize = true;
            this.lblDestinationUserName.Location = new System.Drawing.Point(6, 150);
            this.lblDestinationUserName.Name = "lblDestinationUserName";
            this.lblDestinationUserName.Size = new System.Drawing.Size(61, 13);
            this.lblDestinationUserName.TabIndex = 21;
            this.lblDestinationUserName.Text = "User name:";
            // 
            // lblDestinationAuthentication
            // 
            this.lblDestinationAuthentication.AutoSize = true;
            this.lblDestinationAuthentication.Location = new System.Drawing.Point(6, 88);
            this.lblDestinationAuthentication.Name = "lblDestinationAuthentication";
            this.lblDestinationAuthentication.Size = new System.Drawing.Size(78, 13);
            this.lblDestinationAuthentication.TabIndex = 20;
            this.lblDestinationAuthentication.Text = "Authentication:";
            // 
            // lblDestinationServerAddress
            // 
            this.lblDestinationServerAddress.AutoSize = true;
            this.lblDestinationServerAddress.Location = new System.Drawing.Point(6, 27);
            this.lblDestinationServerAddress.Name = "lblDestinationServerAddress";
            this.lblDestinationServerAddress.Size = new System.Drawing.Size(81, 13);
            this.lblDestinationServerAddress.TabIndex = 19;
            this.lblDestinationServerAddress.Text = "Server address:";
            // 
            // gbSource
            // 
            this.gbSource.Controls.Add(this.btnSourceTestConnection);
            this.gbSource.Controls.Add(this.lblSourceDatabase);
            this.gbSource.Controls.Add(this.lblSourcePassword);
            this.gbSource.Controls.Add(this.lblSourceUserName);
            this.gbSource.Controls.Add(this.lblSourceAuthenticationType);
            this.gbSource.Controls.Add(this.lblSourceServerAddress);
            this.gbSource.Controls.Add(this.tbSourceServerAddress);
            this.gbSource.Controls.Add(this.cbSourceAuthenticationType);
            this.gbSource.Controls.Add(this.tbSourceUserName);
            this.gbSource.Controls.Add(this.cbSourceDatabase);
            this.gbSource.Controls.Add(this.tbSourcePassword);
            this.gbSource.Location = new System.Drawing.Point(11, 15);
            this.gbSource.Name = "gbSource";
            this.gbSource.Size = new System.Drawing.Size(322, 454);
            this.gbSource.TabIndex = 18;
            this.gbSource.TabStop = false;
            this.gbSource.Text = "Source";
            // 
            // btnSourceTestConnection
            // 
            this.btnSourceTestConnection.Location = new System.Drawing.Point(6, 272);
            this.btnSourceTestConnection.Name = "btnSourceTestConnection";
            this.btnSourceTestConnection.Size = new System.Drawing.Size(145, 33);
            this.btnSourceTestConnection.TabIndex = 19;
            this.btnSourceTestConnection.Text = "Test connection";
            this.btnSourceTestConnection.UseVisualStyleBackColor = true;
            this.btnSourceTestConnection.Click += new System.EventHandler(this.btnSourceTestConnection_Click);
            // 
            // lblSourceDatabase
            // 
            this.lblSourceDatabase.AutoSize = true;
            this.lblSourceDatabase.Location = new System.Drawing.Point(6, 335);
            this.lblSourceDatabase.Name = "lblSourceDatabase";
            this.lblSourceDatabase.Size = new System.Drawing.Size(56, 13);
            this.lblSourceDatabase.TabIndex = 18;
            this.lblSourceDatabase.Text = "Database:";
            // 
            // lblSourcePassword
            // 
            this.lblSourcePassword.AutoSize = true;
            this.lblSourcePassword.Location = new System.Drawing.Point(6, 211);
            this.lblSourcePassword.Name = "lblSourcePassword";
            this.lblSourcePassword.Size = new System.Drawing.Size(56, 13);
            this.lblSourcePassword.TabIndex = 17;
            this.lblSourcePassword.Text = "Password:";
            // 
            // lblSourceUserName
            // 
            this.lblSourceUserName.AutoSize = true;
            this.lblSourceUserName.Location = new System.Drawing.Point(6, 150);
            this.lblSourceUserName.Name = "lblSourceUserName";
            this.lblSourceUserName.Size = new System.Drawing.Size(61, 13);
            this.lblSourceUserName.TabIndex = 16;
            this.lblSourceUserName.Text = "User name:";
            // 
            // lblSourceAuthenticationType
            // 
            this.lblSourceAuthenticationType.AutoSize = true;
            this.lblSourceAuthenticationType.Location = new System.Drawing.Point(6, 88);
            this.lblSourceAuthenticationType.Name = "lblSourceAuthenticationType";
            this.lblSourceAuthenticationType.Size = new System.Drawing.Size(78, 13);
            this.lblSourceAuthenticationType.TabIndex = 15;
            this.lblSourceAuthenticationType.Text = "Authentication:";
            // 
            // lblSourceServerAddress
            // 
            this.lblSourceServerAddress.AutoSize = true;
            this.lblSourceServerAddress.Location = new System.Drawing.Point(6, 27);
            this.lblSourceServerAddress.Name = "lblSourceServerAddress";
            this.lblSourceServerAddress.Size = new System.Drawing.Size(81, 13);
            this.lblSourceServerAddress.TabIndex = 14;
            this.lblSourceServerAddress.Text = "Server address:";
            // 
            // tbSourceServerAddress
            // 
            this.tbSourceServerAddress.Location = new System.Drawing.Point(6, 54);
            this.tbSourceServerAddress.Name = "tbSourceServerAddress";
            this.tbSourceServerAddress.Size = new System.Drawing.Size(310, 20);
            this.tbSourceServerAddress.TabIndex = 0;
            this.tbSourceServerAddress.TextChanged += new System.EventHandler(this.tbSourceServerAddress_TextChanged);
            this.tbSourceServerAddress.Validated += new System.EventHandler(this.tbSourceServerAddress_Validated);
            // 
            // cbSourceAuthenticationType
            // 
            this.cbSourceAuthenticationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceAuthenticationType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbSourceAuthenticationType.FormattingEnabled = true;
            this.cbSourceAuthenticationType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbSourceAuthenticationType.Location = new System.Drawing.Point(6, 115);
            this.cbSourceAuthenticationType.Name = "cbSourceAuthenticationType";
            this.cbSourceAuthenticationType.Size = new System.Drawing.Size(310, 21);
            this.cbSourceAuthenticationType.TabIndex = 4;
            this.cbSourceAuthenticationType.SelectedIndexChanged += new System.EventHandler(this.cbSourceAuthenticationType_SelectedIndexChanged);
            // 
            // tbSourceUserName
            // 
            this.tbSourceUserName.Enabled = false;
            this.tbSourceUserName.Location = new System.Drawing.Point(6, 177);
            this.tbSourceUserName.Name = "tbSourceUserName";
            this.tbSourceUserName.Size = new System.Drawing.Size(145, 20);
            this.tbSourceUserName.TabIndex = 6;
            // 
            // cbSourceDatabase
            // 
            this.cbSourceDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceDatabase.Enabled = false;
            this.cbSourceDatabase.FormattingEnabled = true;
            this.cbSourceDatabase.Location = new System.Drawing.Point(9, 364);
            this.cbSourceDatabase.Name = "cbSourceDatabase";
            this.cbSourceDatabase.Size = new System.Drawing.Size(307, 21);
            this.cbSourceDatabase.TabIndex = 10;
            this.cbSourceDatabase.SelectedIndexChanged += new System.EventHandler(this.cbSourceDatabase_SelectedIndexChanged);
            this.cbSourceDatabase.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbSourceDatabase_MouseClick);
            // 
            // tbSourcePassword
            // 
            this.tbSourcePassword.Enabled = false;
            this.tbSourcePassword.Location = new System.Drawing.Point(6, 238);
            this.tbSourcePassword.Name = "tbSourcePassword";
            this.tbSourcePassword.PasswordChar = '*';
            this.tbSourcePassword.Size = new System.Drawing.Size(145, 20);
            this.tbSourcePassword.TabIndex = 7;
            // 
            // btnCopyConfiguration
            // 
            this.btnCopyConfiguration.Enabled = false;
            this.btnCopyConfiguration.Image = global::SqlDtw.Properties.Resources.arrow_right_green;
            this.btnCopyConfiguration.Location = new System.Drawing.Point(358, 149);
            this.btnCopyConfiguration.Name = "btnCopyConfiguration";
            this.btnCopyConfiguration.Size = new System.Drawing.Size(88, 45);
            this.btnCopyConfiguration.TabIndex = 17;
            this.btnCopyConfiguration.UseVisualStyleBackColor = true;
            this.btnCopyConfiguration.Click += new System.EventHandler(this.btnCopyConfiguration_Click);
            // 
            // ServerConfigurationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbDestination);
            this.Controls.Add(this.gbSource);
            this.Controls.Add(this.btnCopyConfiguration);
            this.Name = "ServerConfigurationControl";
            this.Size = new System.Drawing.Size(832, 472);
            this.Load += new System.EventHandler(this.ServerConfigurationControl_Load);
            this.gbDestination.ResumeLayout(false);
            this.gbDestination.PerformLayout();
            this.gbSource.ResumeLayout(false);
            this.gbSource.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDestination;
        private System.Windows.Forms.Button btnDestinationTestConnection;
        private System.Windows.Forms.Button btnNewDestinationDatabase;
        private System.Windows.Forms.TextBox tbDestinationServerAddress;
        private System.Windows.Forms.ComboBox cbDestinationAuthenticationType;
        private System.Windows.Forms.TextBox tbDestinationUserName;
        private System.Windows.Forms.ComboBox cbDestinationDatabase;
        private System.Windows.Forms.TextBox tbDestinationPassword;
        private System.Windows.Forms.Label lblDestinationDatabase;
        private System.Windows.Forms.Label lblDestinationPassword;
        private System.Windows.Forms.Label lblDestinationUserName;
        private System.Windows.Forms.Label lblDestinationAuthentication;
        private System.Windows.Forms.Label lblDestinationServerAddress;
        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.Button btnSourceTestConnection;
        private System.Windows.Forms.Label lblSourceDatabase;
        private System.Windows.Forms.Label lblSourcePassword;
        private System.Windows.Forms.Label lblSourceUserName;
        private System.Windows.Forms.Label lblSourceAuthenticationType;
        private System.Windows.Forms.Label lblSourceServerAddress;
        private System.Windows.Forms.TextBox tbSourceServerAddress;
        private System.Windows.Forms.ComboBox cbSourceAuthenticationType;
        private System.Windows.Forms.TextBox tbSourceUserName;
        private System.Windows.Forms.ComboBox cbSourceDatabase;
        private System.Windows.Forms.TextBox tbSourcePassword;
        private System.Windows.Forms.Button btnCopyConfiguration;
    }
}
