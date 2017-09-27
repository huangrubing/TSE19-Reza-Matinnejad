using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Bussiness.Workspace;
using MiLTester.SourceCode.Presentation.SettingsForms;

namespace MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms
{
    public partial class ModelUnderTestModelSettingsForm : WizardForm
    {
        public ModelUnderTestModelSettingsForm(TestWorkspace testWorkspace)
        {
            this.testWorkspace=testWorkspace;
            InitializeComponent();
            /////////////////////////////////////////
            parentModelSettingsForm = new ParentModelSettingsForm(
                testWorkspace.modelSettings);
            parentModelSettingsForm.Location = new Point(0,0);
            this.Controls.Add(parentModelSettingsForm);
            /////////////////////////////////////////
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        }

        public override WizardForm CreateNextForm(TestWorkspace testWorkspace)
        {
            if (testWorkspace is CCTestWorkspace)
                return new ContinuousControllerTestForm(testWorkspace);
            if (testWorkspace is SLTestWorkspace)
                return new StaticChecksForm(testWorkspace);
                //return new SimulinkTestForm(testWorkspace);
            return null;
        }

        private new void btnNext_Click(object sender, EventArgs e)
        {
            if (!parentModelSettingsForm.CheckModelSettings())
                return;                
            testWorkspace.modelSettings = parentModelSettingsForm.ReadModelSettings();
            base.btnNext_Click(sender, e);
        }
        private ParentModelSettingsForm parentModelSettingsForm;
    }
}
