using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Bussiness.Workspace;

namespace MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms
{
    public class WizardForm : Form
    {
        protected void btnNext_Click(object sender, EventArgs e)
        {
            Hide();
            if (nextForm == null)
            {
                nextForm = CreateNextForm(testWorkspace);
                nextForm.SetPreviousForm(this);
            }
            nextForm.ShowDialog();
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            Hide();
            previousForm.Show();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void SetPreviousForm(Form previousForm)
        {
            this.previousForm = previousForm;
        }

        public virtual WizardForm CreateNextForm(TestWorkspace testWorkspace)
        {
            return null;
        }

        protected TestWorkspace testWorkspace = null;
        protected Form previousForm = null;
        protected WizardForm nextForm = null;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // WizardForm
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "WizardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }
    }
}
