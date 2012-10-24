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
    public partial class TableSelectionControl : DataImportUserControlBase
    {
        private List<TableDefinition> tableDefinitions;

        public TableSelectionControl()
        {            
            tableDefinitions = new List<TableDefinition>();
            InitializeComponent();
        }

        public override DataTransferDefinition PopulateDataTransferDefinition()
        {
            this.DataTransferDefinition.TablesForTransfer = GetSelectedItemsTyped(lbSelectedTables.SelectedItems);
            return this.DataTransferDefinition;
        }

        public override void UpdateDataTransferDefinition(DataTransferDefinition definition)
        {
            this.DataTransferDefinition = definition;
            RefreshTables();
        }


        private void TableSelectionControl_Load(object sender, EventArgs e)
        {
            //Populate check list
            RefreshTables();
        }

        private void RefreshTables()
        {
            tableDefinitions = SqlServerConnectionUtils.GetDatabaseTableList(this.DataTransferDefinition.SourceServer, this.DataTransferDefinition.SourceDatabase);
            //Only checked go to DataTransferDefiniton TableDefinitionList 
            lbSelectedTables.Items.Clear();
            lbSourceTables.Items.Clear();              
            lbSourceTables.DisplayMember = "NameWithSchemaName";
            lbSelectedTables.DisplayMember = "NameWithSchemaName";
            lbSourceTables.Items.AddRange(tableDefinitions.ToArray());
        }

        private object[] GetSelectedItems(ListBox.SelectedObjectCollection items)
        {
            object[] tableItems = new object[items.Count];

            for(int i=0; i< items.Count; i++)
                tableItems[i] = items[i];

            return tableItems;
        }

        private List<TableDefinition> GetSelectedItemsTyped(ListBox.SelectedObjectCollection items)
        {
            List<TableDefinition> tableItems = new List<TableDefinition>();

            for (int i = 0; i < items.Count; i++)
                tableItems.Add((TableDefinition)items[i]);

            return tableItems;
        }

        private void RemoveRange(object[] items, ListBox lb)
        {
            foreach (TableDefinition item in items)
                lb.Items.Remove(item);
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            object[] items = GetSelectedItems(lbSourceTables.SelectedItems);
            RemoveRange(items, lbSourceTables);            
            lbSelectedTables.Items.AddRange(items);            
        }

        private void btnRemoveTable_Click(object sender, EventArgs e)
        {
            object[] items = GetSelectedItems(lbSelectedTables.SelectedItems);
            RemoveRange(items, lbSelectedTables);
            lbSourceTables.Items.AddRange(items);
        }

        private void lbSelectedTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            pgSourceTables.SelectedObjects = GetSelectedItems(lbSelectedTables.SelectedItems);
        }

        private void lbSourceTables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)            
            {
                for (int i = 0; i < lbSourceTables.Items.Count; i++)                
                    lbSourceTables.SelectedItems.Add(lbSourceTables.Items[i]);                                 
            }
        }

        private void lbSelectedTables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                for (int i = 0; i < lbSelectedTables.Items.Count; i++)
                    lbSelectedTables.SelectedItems.Add(lbSelectedTables.Items[i]);   
            }
        }       
    }
}
