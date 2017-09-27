using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Bussiness.Settings;
using MiLTester.SourceCode.Service;
using MiLTester.SourceCode.Presentation.SettingsForms;
using MiLTester.SourceCode.Bussiness.Workspace;

namespace MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms
{
    public partial class ModelUnderTestAdvancedCCSettingsForm : WizardForm
    {
        public ModelUnderTestAdvancedCCSettingsForm(CCTestWorkspace testWorkspace)
        {
            this.testWorkspace = testWorkspace;
            
            InitializeComponent();
            
            parentAdvancedCCSettingsForm = new ParentAdvancedCCSettingsForm();
            parentAdvancedCCSettingsForm.LoadAdvancedCCSettings(testWorkspace.advancedCCSettings);
            this.Controls.Add(parentAdvancedCCSettingsForm);
            ////////////////////////////////////
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        }

        public override WizardForm CreateNextForm(TestWorkspace testWorkspace)
        {
            if (testWorkspace is CCTestWorkspace)
              return new ModelUnderTestCCSettings((CCTestWorkspace)testWorkspace);
            if (testWorkspace is SLTestWorkspace)
                return new ModelUnderTestSLSettings((SLTestWorkspace)testWorkspace);
            return null;
        }

        private new void btnNext_Click(object sender, EventArgs e)
        {
            ((CCTestWorkspace)testWorkspace).advancedCCSettings=parentAdvancedCCSettingsForm.ReadAdvancedCCSettings();
            base.btnNext_Click(sender, e);
        }

        private ParentAdvancedCCSettingsForm parentAdvancedCCSettingsForm;
    }
}
