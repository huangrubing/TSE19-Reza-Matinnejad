using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Data;

namespace MiLTester.SourceCode.Presentation
{
    public partial class TestWorkspaceRenameForm : Form
    {
        public TestWorkspaceRenameForm(string testWorkspaceName)
        {
            InitializeComponent();
            testWorkspaceOldName = testWorkspaceName;
            tbWorkspaceName.Text = testWorkspaceName;
        }
        
        public string GetNewTestWorkspaceName()
        {
            return newTestWorkspaceName;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(!TestWorkspaceDataProvider.GetTestWorkspaceDataProvider().
                IsWorkspaceNameUnique(tbWorkspaceName.Text))
            {
                MessageBox.Show("The Test Workspace Name is Duplicate!",
                    "Dupllicate Test Workspace Name", MessageBoxButtons.OK);
                tbWorkspaceName.Focus();
                tbWorkspaceName.SelectAll();
                return;
            }
            DialogResult = DialogResult.OK;
            newTestWorkspaceName = tbWorkspaceName.Text;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private string newTestWorkspaceName;

        private void TestWorkspaceRenameForm_Shown(object sender, EventArgs e)
        {
            tbWorkspaceName.Focus();
        }

        private void tbWorkspaceName_TextChanged(object sender, EventArgs e)
        {
            if (testWorkspaceOldName.Equals(tbWorkspaceName.Text))
                btnOk.Enabled = false;
            else
                btnOk.Enabled = true;
        }
        private string testWorkspaceOldName;
    }
}
