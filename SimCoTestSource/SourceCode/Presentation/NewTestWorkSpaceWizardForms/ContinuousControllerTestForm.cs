using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Bussiness.Workspace;
using MiLTester.SourceCode.Bussiness.Workspace.Parameters;
using MiLTester.SourceCode.Common;
using MiLTester.SourceCode.Bussiness.RunEngine;
using MiLTester.SourceCode.Bussiness.Workspace.TestCases;
using MiLTester.SourceCode.Service;

namespace MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms
{
    public partial class ContinuousControllerTestForm : WizardForm
    {
        public ContinuousControllerTestForm(TestWorkspace testWorkspace)
        {
            this.testWorkspace = testWorkspace;
            InitializeComponent();
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            LoadTestCCParameters();
            if (testWorkspace.CreatedFromTemplate)
            {
                cbConfirmCorrectness.Enabled = true;
                cbConfirmCorrectness.Checked = true;
            }
        }

        public override WizardForm CreateNextForm(TestWorkspace testWorkspace)
        {
            if (SettingFilesManager.softwareRunningMode == SoftwareModeEnum.NormalMode)
                return new ModelUnderTestCCSettings((CCTestWorkspace)testWorkspace);
            else
                return new ModelUnderTestAdvancedCCSettingsForm((CCTestWorkspace)testWorkspace);
        }

        private void btnRunModel_Click(object sender, EventArgs e)
        {
            if (!CheckAndSetTestCCParameters())
                return;
            TestRunProgressForm testRunProgressForm = new TestRunProgressForm();
            CCTestCase ccTestCase = new CCTestCase();
            ccTestCase.initialDesired=((CCTestWorkspace)testWorkspace).GetInitialDesiredValue();
            ccTestCase.finalDesired = ((CCTestWorkspace)testWorkspace).GetFinalDesiredValue();
            ErrorResult errorResult = testRunProgressForm.TestRunModel(testWorkspace,ccTestCase);
            if (errorResult.errorCode != ErrorCode.Success)
            {
                if (errorResult.errorCode != ErrorCode.TestRunCanceled)
                    MessageBox.Show("Error in Running the Model with this Information!",
                        "Error Running the Model", MessageBoxButtons.OK);
                return;
            }
            modelRunningTimeCurrentMilisec = errorResult.errorParemeter; 
            cbConfirmCorrectness.Enabled = true;
            cbConfirmCorrectness.Checked = true;
        }
        
        private new void btnNext_Click(object sender, EventArgs e)
        {
            if (!CheckAndSetTestCCParameters())
                return;
            testWorkspace.SetModelRunningTime(modelRunningTimeCurrentMilisec);
            //MatlabProgram.KillMatlab();
            base.btnNext_Click(sender, e);
        }

        private void LoadTestCCParameters()
        {
            TestParameter desiredVariable = ((CCTestWorkspace)testWorkspace).GetDesiredValueVariable();
            if (desiredVariable != null)
            {
                tbDesiredVarName.Text = desiredVariable.parameterName;
                tbDesiredVarFrom.Text = tbActualVarFrom.Text = desiredVariable.from.ToString();
                tbDesiredVarTo.Text = tbActualVarTo.Text = desiredVariable.to.ToString();
            }
            TestParameter actualVariable = ((CCTestWorkspace)testWorkspace).GetActualValueVariable();
            if (actualVariable!=null)
                tbActualVarName.Text = actualVariable.parameterName;

            foreach (TestParameter ccTestParameter in ((CCTestWorkspace)testWorkspace).GetCalibrationVairables())
            {
                    string[] items = new string[5];
                    items[0] = ccTestParameter.parameterName;
                    items[1] = ccTestParameter.from.ToString();
                    items[2] = ccTestParameter.to.ToString();
                    items[3] = ccTestParameter.parameterDataType.dataTypeName;
                    items[4] = ccTestParameter.valueForTest.ToString();
                    ListViewItem listViewItem = new ListViewItem(items);
                    lvCalibrationVariables.Items.Add(listViewItem);
                    btnCalibrationVarRemove.Enabled = true;
            }
            tbSimulationTime.Text = testWorkspace.GetSimulationTime().ToString();
            tbInitialDsrdTest.Text = tbDesiredVarFrom.Text;
            tbFinalDsrdTest.Text = tbDesiredVarTo.Text;
            modelRunningTimeCurrentMilisec = ((CCTestWorkspace)testWorkspace).GetModelRunningTime();
        }

        private bool CheckAndSetTestCCParameters()
        {
            if (tbDesiredVarName.Text == "")
            {
                MessageBox.Show("Enter Desired Variable Name!",
                    "Parameter Error", MessageBoxButtons.OK);
                tbDesiredVarName.Focus();
                tbDesiredVarName.SelectAll();
                return false;
            }
            if (tbActualVarName.Text == "")
            {
                MessageBox.Show("Enter Actual Variable Name!",
                    "Parameter Error", MessageBoxButtons.OK);
                tbActualVarName.Focus();
                tbActualVarName.SelectAll();
                return false;
            }
            short DummyCheckInt;
            float DummyCheckFloat;
            if (!float.TryParse(tbDesiredVarFrom.Text, out DummyCheckFloat))
            {
                MessageBox.Show("Enter a valid value for The From field!",
                    "Parameter Error", MessageBoxButtons.OK);
                tbDesiredVarFrom.Focus();
                tbDesiredVarFrom.SelectAll();
                return false;
            }
            if (!float.TryParse(tbDesiredVarTo.Text, out DummyCheckFloat))
            {
                MessageBox.Show("Enter a valid value for the To field!",
                    "Parameter Error", MessageBoxButtons.OK);
                tbDesiredVarTo.Focus();
                tbDesiredVarTo.SelectAll();
                return false;
            }

            if (float.Parse(tbDesiredVarTo.Text) < float.Parse(tbDesiredVarFrom.Text))
            {
                MessageBox.Show("From value must be smaller than the To value!",
                    "Parameter Error", MessageBoxButtons.OK);
                tbDesiredVarTo.Focus();
                tbDesiredVarTo.SelectAll();
                return false;
            }

            if (!Int16.TryParse(tbSimulationTime.Text, out DummyCheckInt))
            {
                MessageBox.Show("Enter a Number for Simulation Time!",
                    "Parameter Error", MessageBoxButtons.OK);
                tbSimulationTime.Focus();
                tbSimulationTime.SelectAll();
                return false;
            }
            
            if (!float.TryParse(tbInitialDsrdTest.Text, out DummyCheckFloat))
            {
                MessageBox.Show("Enter a valid value for the Initial Desired field!",
                    "Parameter Error", MessageBoxButtons.OK);
                tbInitialDsrdTest.Focus();
                tbInitialDsrdTest.SelectAll();
                return false;
            }
            if ((DummyCheckFloat < float.Parse(tbDesiredVarFrom.Text)) ||
                (DummyCheckFloat > float.Parse(tbDesiredVarTo.Text)))
            {
                MessageBox.Show("Enter a value between from and to values for the Initial Desired field!",
                    "Parameter Error", MessageBoxButtons.OK);
                tbInitialDsrdTest.Focus();
                tbInitialDsrdTest.SelectAll();
                return false;
            }

            if (!float.TryParse(tbFinalDsrdTest.Text, out DummyCheckFloat))
            {
                MessageBox.Show("Enter a valid value for the Final Desired field!",
                    "Parameter Error", MessageBoxButtons.OK);
                tbFinalDsrdTest.Focus();
                tbFinalDsrdTest.SelectAll();
                return false;
            }
            if ((DummyCheckFloat < float.Parse(tbDesiredVarFrom.Text)) ||
                (DummyCheckFloat > float.Parse(tbDesiredVarTo.Text)))
            {
                MessageBox.Show("Enter a value between from and to values for the Final Desired field!",
                    "Parameter Error", MessageBoxButtons.OK);
                tbFinalDsrdTest.Focus();
                tbFinalDsrdTest.SelectAll();
                return false;
            }

            ((CCTestWorkspace)testWorkspace).SetDesiredValueVariable(
                new TestParameter(tbDesiredVarName.Text, ParameteresType.DesiredVariable,
                    float.Parse(tbDesiredVarFrom.Text), float.Parse(tbDesiredVarTo.Text)));
            ((CCTestWorkspace)testWorkspace).SetActualValueVariable(
                new TestParameter(tbActualVarName.Text, ParameteresType.ActualVariable,
                    float.Parse(tbActualVarFrom.Text), float.Parse(tbActualVarTo.Text)));
            ((CCTestWorkspace)testWorkspace).SetInitialDesiredValue(
                float.Parse(tbInitialDsrdTest.Text));
            ((CCTestWorkspace)testWorkspace).SetFinalDesiredValue(
                float.Parse(tbFinalDsrdTest.Text));
            ((CCTestWorkspace)testWorkspace).ResetCalibrationVariables();
            for (int i = 0; i < lvCalibrationVariables.Items.Count; ++i)
            {
                ((CCTestWorkspace)testWorkspace).AddCalibrationVariable(
                    new TestParameter(lvCalibrationVariables.Items[i].SubItems[0].Text,
                        ParameteresType.CalibrationVariable,
                        float.Parse(lvCalibrationVariables.Items[i].SubItems[1].Text),
                        float.Parse(lvCalibrationVariables.Items[i].SubItems[2].Text),
                        float.Parse(lvCalibrationVariables.Items[i].SubItems[4].Text)));
            }

            testWorkspace.SetSimulationTime(
                Int16.Parse(tbSimulationTime.Text));
            return true;
        }

        private void tbDesiredVarFrom_TextChanged(object sender, EventArgs e)
        {
            tbActualVarFrom.Text = tbDesiredVarFrom.Text;
            tbInitialDsrdTest.Text = tbDesiredVarFrom.Text;
            ModelTestParametersChanged();
        }

        private void tbDesiredVarTo_TextChanged(object sender, EventArgs e)
        {
            tbActualVarTo.Text = tbDesiredVarTo.Text;
            tbFinalDsrdTest.Text = tbDesiredVarTo.Text;
            ModelTestParametersChanged();
        }

        private void cbConfirmCorrectness_CheckedChanged(object sender, EventArgs e)
        {
            if(cbConfirmCorrectness.Checked)
                btnNext.Enabled = true;
            else
                btnNext.Enabled = false;
        }

        private void tbSimulationTime_TextChanged(object sender, EventArgs e)
        {
            ModelTestParametersChanged();
        }

        private void tbDesiredVarName_TextChanged(object sender, EventArgs e)
        {
            ModelTestParametersChanged();
        }

        private void tbActualVarName_TextChanged(object sender, EventArgs e)
        {
            ModelTestParametersChanged();
        }

        private void ModelTestParametersChanged()
        {
            modelRunningTimeCurrentMilisec = 0;
            cbConfirmCorrectness.Checked = false;
            cbConfirmCorrectness.Enabled = false;
            btnNext.Enabled = false;
        }

        private void SetShortcutTooltips()
        {
            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(pnlDesiredVarHelp, "Desired value variable must correspond to a \r 'From Workspace' variable in Matlab/Simulink model.");
            tooltip.SetToolTip(pnlActualVarHelp, "Actual value variable must correspond to a \r 'To Workspace' variable in Matlab/Simulink model.");
        }

        private void ContinuousControllerTestForm_Shown(object sender, EventArgs e)
        {
            SetShortcutTooltips();
        }

        private void btnCalibrationVarAdd_Click(object sender, EventArgs e)
        {
            if (tbCalibrationVarName.Text == "")
            {
                tbCalibrationVarName.Focus();
                tbCalibrationVarName.SelectAll();
                return;
            }
            float calibrationVarFrom;
            if (tbCalibrationVarFrom.Text == "" ||
                !float.TryParse(tbCalibrationVarFrom.Text, out calibrationVarFrom))
            {
                tbCalibrationVarFrom.Focus();
                tbCalibrationVarFrom.SelectAll();
                return;
            }
            float calibrationVarTo;
            if (tbCalibrationVarTo.Text == "" ||
                !float.TryParse(tbCalibrationVarTo.Text, out calibrationVarTo))
            {
                tbCalibrationVarTo.Focus();
                tbCalibrationVarTo.SelectAll();
                return;
            }
            float calibrationVarTestValue;
            if (tbCalibrationVarTestValue.Text == "" ||
                !float.TryParse(tbCalibrationVarTestValue.Text, out calibrationVarTestValue) ||
                (calibrationVarTestValue < calibrationVarFrom) ||
                (calibrationVarTestValue > calibrationVarTo))
            {
                tbCalibrationVarTestValue.Focus();
                tbCalibrationVarTestValue.SelectAll();
                return;
            }
            string[] items = new string[5];
            items[0] = tbCalibrationVarName.Text;
            items[1] = tbCalibrationVarFrom.Text;
            items[2] = tbCalibrationVarTo.Text;
            items[3] = tbCalibrationVarType.Text;
            items[4] = tbCalibrationVarTestValue.Text;
            ListViewItem listViewItem = new ListViewItem(items);
            bool repeatitive = false;
            for (int i = 0; i < lvCalibrationVariables.Items.Count; ++i)
                if (lvCalibrationVariables.Items[i].SubItems[0].Text == tbCalibrationVarName.Text)
                {
                    repeatitive = true;
                    lvCalibrationVariables.Items[i].SubItems[1].Text = tbCalibrationVarFrom.Text;
                    lvCalibrationVariables.Items[i].SubItems[2].Text = tbCalibrationVarTo.Text;
                    lvCalibrationVariables.Items[i].SubItems[3].Text = tbCalibrationVarType.Text;
                    lvCalibrationVariables.Items[i].SubItems[4].Text = tbCalibrationVarTestValue.Text;
                    break;
                }
            if(!repeatitive)
                lvCalibrationVariables.Items.Add(listViewItem);
            btnCalibrationVarRemove.Enabled = true;
            ModelTestParametersChanged();
        }

        private void btnCalibrationVarRemove_Click(object sender, EventArgs e)
        {
            if (lvCalibrationVariables.SelectedIndices.Count == 0)
                lvCalibrationVariables.Items[0].Selected = true;
            int indexToDel = lvCalibrationVariables.SelectedIndices[0];
            lvCalibrationVariables.Items.RemoveAt(lvCalibrationVariables.SelectedIndices[0]);
            if (lvCalibrationVariables.Items.Count == 0)
                btnCalibrationVarRemove.Enabled = false;
            else
            {
                if (lvCalibrationVariables.Items.Count > indexToDel)
                    lvCalibrationVariables.Items[indexToDel].Selected = true;
                else
                    lvCalibrationVariables.Items[indexToDel - 1].Selected = true;
            }
        }

        private void lvCalibrationVariables_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvCalibrationVariables.Columns[e.ColumnIndex].Width;
        }

        private void lvCalibrationVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCalibrationVariables.SelectedIndices.Count <= 0)
                return;
            tbCalibrationVarName.Text = lvCalibrationVariables.SelectedItems[0].SubItems[0].Text;
            tbCalibrationVarFrom.Text = lvCalibrationVariables.SelectedItems[0].SubItems[1].Text;
            tbCalibrationVarTo.Text = lvCalibrationVariables.SelectedItems[0].SubItems[2].Text;
            tbCalibrationVarType.Text = lvCalibrationVariables.SelectedItems[0].SubItems[3].Text;
            tbCalibrationVarTestValue.Text = lvCalibrationVariables.SelectedItems[0].SubItems[4].Text;
        }
        private int modelRunningTimeCurrentMilisec;
    }
}
