namespace SqlDtw.Forms
{
    partial class TableSelectionControl
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
            this.btnRemoveTable = new System.Windows.Forms.Button();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pgSourceTables = new System.Windows.Forms.PropertyGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbSelectedTables = new System.Windows.Forms.ListBox();
            this.gbSourceTables = new System.Windows.Forms.GroupBox();
            this.lbSourceTables = new System.Windows.Forms.ListBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbSourceTables.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRemoveTable
            // 
            this.btnRemoveTable.Location = new System.Drawing.Point(376, 135);
            this.btnRemoveTable.Name = "btnRemoveTable";
            this.btnRemoveTable.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveTable.TabIndex = 11;
            this.btnRemoveTable.Text = "Remove";
            this.btnRemoveTable.UseVisualStyleBackColor = true;
            this.btnRemoveTable.Click += new System.EventHandler(this.btnRemoveTable_Click);
            // 
            // btnAddTable
            // 
            this.btnAddTable.Location = new System.Drawing.Point(376, 106);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(75, 23);
            this.btnAddTable.TabIndex = 10;
            this.btnAddTable.Text = "Add";
            this.btnAddTable.UseVisualStyleBackColor = true;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pgSourceTables);
            this.groupBox2.Location = new System.Drawing.Point(457, 268);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 201);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Table properties";
            // 
            // pgSourceTables
            // 
            this.pgSourceTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgSourceTables.HelpVisible = false;
            this.pgSourceTables.Location = new System.Drawing.Point(3, 16);
            this.pgSourceTables.Name = "pgSourceTables";
            this.pgSourceTables.Size = new System.Drawing.Size(368, 182);
            this.pgSourceTables.TabIndex = 5;
            this.pgSourceTables.ToolbarVisible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbSelectedTables);
            this.groupBox1.Location = new System.Drawing.Point(457, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 258);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Tables";
            // 
            // lbSelectedTables
            // 
            this.lbSelectedTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSelectedTables.FormattingEnabled = true;
            this.lbSelectedTables.Location = new System.Drawing.Point(3, 16);
            this.lbSelectedTables.Name = "lbSelectedTables";
            this.lbSelectedTables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbSelectedTables.Size = new System.Drawing.Size(368, 239);
            this.lbSelectedTables.Sorted = true;
            this.lbSelectedTables.TabIndex = 0;
            this.lbSelectedTables.SelectedIndexChanged += new System.EventHandler(this.lbSelectedTables_SelectedIndexChanged);
            this.lbSelectedTables.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbSelectedTables_KeyDown);
            // 
            // gbSourceTables
            // 
            this.gbSourceTables.Controls.Add(this.lbSourceTables);
            this.gbSourceTables.Location = new System.Drawing.Point(3, 3);
            this.gbSourceTables.Name = "gbSourceTables";
            this.gbSourceTables.Size = new System.Drawing.Size(370, 466);
            this.gbSourceTables.TabIndex = 7;
            this.gbSourceTables.TabStop = false;
            this.gbSourceTables.Text = "Source Tables";
            // 
            // lbSourceTables
            // 
            this.lbSourceTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSourceTables.FormattingEnabled = true;
            this.lbSourceTables.Location = new System.Drawing.Point(3, 16);
            this.lbSourceTables.Name = "lbSourceTables";
            this.lbSourceTables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbSourceTables.Size = new System.Drawing.Size(364, 447);
            this.lbSourceTables.Sorted = true;
            this.lbSourceTables.TabIndex = 6;
            this.lbSourceTables.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbSourceTables_KeyDown);
            // 
            // TableSelectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemoveTable);
            this.Controls.Add(this.btnAddTable);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbSourceTables);
            this.Name = "TableSelectionControl";
            this.Size = new System.Drawing.Size(832, 472);
            this.Load += new System.EventHandler(this.TableSelectionControl_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbSourceTables.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid pgSourceTables;
        private System.Windows.Forms.ListBox lbSourceTables;
        private System.Windows.Forms.GroupBox gbSourceTables;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbSelectedTables;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.Button btnRemoveTable;
    }
}
