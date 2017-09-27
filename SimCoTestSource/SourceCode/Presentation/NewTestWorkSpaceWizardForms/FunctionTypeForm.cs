using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Bussiness.Workspace;
using MiLTester.SourceCode.Data;
using System.Text.RegularExpressions;
using System.IO;

namespace MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms
{
    public partial class FunctionTypeForm : WizardForm
    {
        private TestWorkspace templateTestWorkspace = null;
        
        public FunctionTypeForm()
        {
            InitializeComponent();
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            initializeWorkspaceName("WorkSpaceName");
        }

        public FunctionTypeForm(TestWorkspace templateTestWorkspace):
            this()
        {
            this.templateTestWorkspace = templateTestWorkspace;
            initializeWorkspaceName(templateTestWorkspace.ToString());
            rbContinuousController.Enabled = rbSimulink.Enabled = false;
            switch (templateTestWorkspace.functionType)
            {
                case FunctionTypeEnum.Continuous_Controller:
                    rbContinuousController.Checked = true;
                    break;
                case FunctionTypeEnum.State_Based_Controller:
                    rbSimulink.Checked = true;
                    break;
            }
        }

        private void initializeWorkspaceName(string workspaceDefaultName)
        {
            string workspaceName = workspaceDefaultName;
            int cnt = 1;
            do
            {
                if(TestWorkspaceDataProvider.
                    GetTestWorkspaceDataProvider().IsWorkspaceNameUnique(workspaceName))
                    break;
                ++cnt;
                workspaceName = workspaceDefaultName + cnt.ToString();
            }
            while(true);
            tbWorkspaceName.Text = workspaceName;
        }

        public override WizardForm CreateNextForm(TestWorkspace testWorkspace)
        {
            return new ModelUnderTestModelSettingsForm(testWorkspace);
        }

        private void FunctionTypeForm_Shown(object sender, EventArgs e)
        {
            tbWorkspaceName.Focus();
        }

        private new void btnNext_Click(object sender, EventArgs e)
        {
            bool result=false;
            if(templateTestWorkspace==null)
                result=CreateTestWorkSpace();
            else
                result=CreateTestWorkSpace(templateTestWorkspace);
            if (!result)
                return ;
            base.btnNext_Click(sender,e);
        }

        private bool CreateTestWorkSpace()
        {
            bool InvalidName=false;
            foreach(char c in tbWorkspaceName.Text)
                if (Path.GetInvalidFileNameChars().Contains(c))
                {
                    InvalidName=true;
                    break;
                }
            if (InvalidName)
            {
                MessageBox.Show("The Test Workspace Name is Invalid! Select a name that can be used as the name of a Windows folder.",
                    "Invalid Test Workspace Name", MessageBoxButtons.OK);
                tbWorkspaceName.Focus();
                tbWorkspaceName.SelectAll();
                return false;
            }

            if (!TestWorkspaceDataProvider.
                    GetTestWorkspaceDataProvider().IsWorkspaceNameUnique(tbWorkspaceName.Text))
            {
                MessageBox.Show("The Test Workspace Name is Duplicate!", 
                    "Dupllicate Test Workspace Name", MessageBoxButtons.OK);
                return false;
            }
            if (rbContinuousController.Checked)
                    testWorkspace = new CCTestWorkspace(tbWorkspaceName.Text);
            else if (rbSimulink.Checked)
                testWorkspace = new SLTestWorkspace(tbWorkspaceName.Text);
            else
                testWorkspace = new IOTestWorkspace(tbWorkspaceName.Text);
            return true;
        }

        private bool CreateTestWorkSpace(TestWorkspace templateTestWorkspace)
        {
            if (!TestWorkspaceDataProvider.
                    GetTestWorkspaceDataProvider().IsWorkspaceNameUnique(tbWorkspaceName.Text))
            {
                MessageBox.Show("The Test Workspace Name is Duplicate!",
                    "Dupllicate Test Workspace Name", MessageBoxButtons.OK);
                return false;
            }
            testWorkspace = (TestWorkspace)templateTestWorkspace.Clone();
            testWorkspace.SetWorkspaceName(tbWorkspaceName.Text);
            testWorkspace.CreatedFromTemplate = true;
            return true;
        }
    }
}
