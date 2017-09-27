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
using MiLTester.SourceCode.Bussiness.Workspace.Parameters;
using MiLTester.SourceCode.Bussiness.Settings;

namespace MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms
{
    public partial class ModelUnderTestSLSettings : WizardForm, ISBSettingsChangeListener
    {
        public ModelUnderTestSLSettings(SLTestWorkspace testWorkspace)
        {
            InitializeComponent();
            this.testWorkspace = testWorkspace;
            parentSLSettingsForm = new ParentSLSettingsForm(this);
            parentSLSettingsForm.LoadSLSettings(((SLTestWorkspace)testWorkspace).slSettings);
            this.Controls.Add(parentSLSettingsForm);
            ////////////////////////////////////
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            for (int i = 0; i < testWorkspace.outputVariables.Count; ++i)
            {
                TestParameter outVar = ((SLTestWorkspace)testWorkspace).outputVariables[i];
                cmbPortNums.Items.Add(outVar.blockInfo.blockPortNum);
                cmbPortNames.Items.Add(outVar.blockInfo.blockTag);
            }
            cmbPortNums.SelectedIndex = 0;
            tbTime.Text = "3600";
            btnApply.Enabled = false;
        }

        public void SettingsChanged()
        {
            btnApply.Enabled = true;
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            Hide();
            //((SLTestWorkspace)testWorkspace).slSettings = parentSLSettingsForm.ReadSLSettings();
            SLTestProgressForm sltestProgressForm = new SLTestProgressForm(testWorkspace);
            sltestProgressForm.ShowDialog();

        }
        private ParentSLSettingsForm parentSLSettingsForm;

        private void cmbPortNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbPortNums.SelectedIndex != cmbPortNames.SelectedIndex)
                cmbPortNums.SelectedIndex = cmbPortNames.SelectedIndex;
        }

        private void cmbPortNums_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbPortNames.SelectedIndex != cmbPortNums.SelectedIndex)
                cmbPortNames.SelectedIndex = cmbPortNums.SelectedIndex;
            SLSettings settings = new SLSettings(true);
            parentSLSettingsForm.LoadSLSettings(settings);
        }

        private void btnExclude_Click(object sender, EventArgs e)
        {
            SLSettings settings = new SLSettings(true);
            settings.Reset();
            parentSLSettingsForm.LoadSLSettings(settings);
            btnApply_Click(null, null);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            btnApply.Enabled = false;
        }
    }
}
