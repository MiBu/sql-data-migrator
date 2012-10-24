using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using SqlDtw.Utils;

namespace SqlDtw.Forms
{
    public partial class NewDatabaseForm : Form
    {
        private Server databaseServer;
        private StringResult result;

        public NewDatabaseForm()
        {            
            InitializeComponent();
        }

        public static StringResult ShowDialog(Server srv)
        {
            using (NewDatabaseForm fm = new NewDatabaseForm())
            {                
                fm.databaseServer = srv;
                fm.ShowDialog();
                if (fm.DialogResult == DialogResult.OK)
                {
                    return fm.result;                    
                }
                else
                    return null;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            result = new StringResult();

            if (String.IsNullOrEmpty(tbDatabaseName.Text))
            {
                MessageBox.Show("Name is required!", "Error", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    //create database
                    Database db = new Database(databaseServer, tbDatabaseName.Text);
                    db.Create();

                    result.Successfull = true;
                    result.Result = tbDatabaseName.Text;
                    result.Message = "Database " + tbDatabaseName.Text + " successfully created!";
                }
                catch (Exception ex)
                {
                    result.Successfull = false;
                    result.Result = null;
                    result.Message = ex.Message + " " + (ex.InnerException != null ? ex.InnerException.Message : "");
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }            
        }        
    }
}
