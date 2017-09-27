using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Bussiness.Output.HeatMap;
using MB.Controls;
using MiLTester.SourceCode.Presentation.Components;
using MiLTester.SourceCode.Bussiness.Settings;
using MiLTester.SourceCode.Bussiness.Workspace;
using MiLTester.SourceCode.Presentation.SettingsForms;
using MiLTester.SourceCode.Bussiness.Workspace.Parameters;

namespace MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms
{
    public partial class ModelUnderTestCCSettings : WizardForm, ICCSettingsChangeListener
    {

        public ModelUnderTestCCSettings(CCTestWorkspace testWorkspace)
        {
            this.testWorkspace = testWorkspace;
            InitializeComponent();
            ////////////////////////////////////
            float from = 0,to = 0;
            TestParameter desiredVariable = testWorkspace.GetDesiredValueVariable();
            from = desiredVariable.from;
            to = desiredVariable.to;
            
            parentCCSettingsForm = new ParentCCSettingsForm(this, from, to);
            parentCCSettingsForm.LoadCCSettings(((CCTestWorkspace)testWorkspace).ccSettings);
            this.Controls.Add(parentCCSettingsForm);
            ////////////////////////////////////
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        }

        public void SettingsChanged()
        {
            UpdateTimeEstimates();
        }

        private void UpdateTimeEstimates()
        {
            CCSettings CCSettings = parentCCSettingsForm.ReadCCSettings();
            TimeSpan timeSpan = ((CCTestWorkspace)testWorkspace).GetTestEstimatedRunningTimeWithThisSettings(CCSettings);
            DateTime finisheTime = DateTime.Now + timeSpan;
            lblRunninTime.Text = timeSpan.ToString();
            lblFinishTime.Text = finisheTime.ToString();
            if (timeSpan.TotalSeconds == 0)
                btnStart.Enabled = false;
            else
                btnStart.Enabled = true;
        }

 
        private void btnStart_Click(object sender, EventArgs e)
        {
            Hide();
            ((CCTestWorkspace)testWorkspace).ccSettings = parentCCSettingsForm.ReadCCSettings();
            TestProgressForm testProgressForm = new TestProgressForm(testWorkspace);
            testProgressForm.ShowDialog();
        }

        private void ModelUnderTestCCSettings_Shown(object sender, EventArgs e)
        {
            UpdateTimeEstimates();

            float from = 0, to = 0;
            TestParameter desiredVariable = ((CCTestWorkspace)testWorkspace).GetDesiredValueVariable();
            from = desiredVariable.from;
            to = desiredVariable.to;
            parentCCSettingsForm.CreateLabelsWithNewRanges(from,to);
        }
        private ParentCCSettingsForm parentCCSettingsForm;


    }
}
