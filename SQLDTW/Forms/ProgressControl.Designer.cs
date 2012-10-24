namespace SqlDtw.Forms
{
    partial class ProgressControl
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
            this.lblProgress = new System.Windows.Forms.Label();
            this.gbStatusWindow = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbStatus = new System.Windows.Forms.RichTextBox();
            this.pbStatusBar = new System.Windows.Forms.ProgressBar();
            this.btnStop = new System.Windows.Forms.Button();
            this.gbStatusWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(9, 12);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(99, 13);
            this.lblProgress.TabIndex = 3;
            this.lblProgress.Text = "Operation progress:";
            // 
            // gbStatusWindow
            // 
            this.gbStatusWindow.Controls.Add(this.btnStop);
            this.gbStatusWindow.Controls.Add(this.btnStart);
            this.gbStatusWindow.Controls.Add(this.tbStatus);
            this.gbStatusWindow.Location = new System.Drawing.Point(3, 60);
            this.gbStatusWindow.Name = "gbStatusWindow";
            this.gbStatusWindow.Size = new System.Drawing.Size(826, 409);
            this.gbStatusWindow.TabIndex = 2;
            this.gbStatusWindow.TabStop = false;
            this.gbStatusWindow.Text = "Status";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(722, 354);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(98, 38);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbStatus
            // 
            this.tbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbStatus.Location = new System.Drawing.Point(3, 16);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ReadOnly = true;
            this.tbStatus.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbStatus.ShortcutsEnabled = false;
            this.tbStatus.Size = new System.Drawing.Size(820, 320);
            this.tbStatus.TabIndex = 0;
            this.tbStatus.Text = "";
            // 
            // pbStatusBar
            // 
            this.pbStatusBar.Location = new System.Drawing.Point(9, 31);
            this.pbStatusBar.Name = "pbStatusBar";
            this.pbStatusBar.Size = new System.Drawing.Size(814, 23);
            this.pbStatusBar.TabIndex = 1;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(605, 354);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(98, 38);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // ProgressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.gbStatusWindow);
            this.Controls.Add(this.pbStatusBar);
            this.Name = "ProgressControl";
            this.Size = new System.Drawing.Size(832, 472);
            this.Load += new System.EventHandler(this.ProgressControl_Load);
            this.gbStatusWindow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbStatusBar;
        private System.Windows.Forms.GroupBox gbStatusWindow;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.RichTextBox tbStatus;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
    }
}
