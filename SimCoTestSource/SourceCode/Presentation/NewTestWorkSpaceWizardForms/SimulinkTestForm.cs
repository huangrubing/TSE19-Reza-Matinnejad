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
using MiLTester.SourceCode.Bussiness.Workspace.TestCases;
using MiLTester.SourceCode.Common;
using MiLTester.SourceCode.Service;
using MiLTester.SourceCode.Data;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns;

namespace MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms
{
    public partial class SimulinkTestForm : WizardForm
    {
        public SimulinkTestForm(TestWorkspace testWorkspace)
        {
            this.testWorkspace = testWorkspace;
            InitializeComponent();
            tbModelName.Text = testWorkspace.modelSettings.GetSimulinkModelName();
            cmbVarType.SelectedIndex = 0;
            tbSimulationTime.Text = "";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        }
        
        /*private void LoadTestSBParameters()
        {
            foreach (TestParameter sbTestParameter in ((SLTestWorkspace)testWorkspace).inputVariables)
            {
                string[] items = new string[6];
                items[0] = sbTestParameter.parameterName;
                items[1] = "Input";
                items[2] = sbTestParameter.from.ToString();
                items[3] = sbTestParameter.to.ToString();
                items[4] = sbTestParameter.parameterDataType.dataTypeName;
                items[5] = sbTestParameter.valueForTest.ToString();
                ListViewItem listViewItem = new ListViewItem(items);
                lvVariables.Items.Add(listViewItem);
                btnVarRemove.Enabled = true;
            }

            foreach (TestParameter ccTestParameter in testWorkspace.calibrationVariables)
            {
                string[] items = new string[6];
                items[0] = ccTestParameter.parameterName;
                items[1] = "Configuration";
                items[2] = ccTestParameter.from.ToString();
                items[3] = ccTestParameter.to.ToString();
                items[4] = ccTestParameter.parameterDataType.dataTypeName;
                items[5] = ccTestParameter.valueForTest.ToString();
                ListViewItem listViewItem = new ListViewItem(items);
                lvVariables.Items.Add(listViewItem);
                btnVarRemove.Enabled = true;
            }
            /*if (((SLTestWorkspace)testWorkspace).outputVariable != null)
            {
                tbOutVarName.Text = ((SLTestWorkspace)testWorkspace).outputVariable.parameterName;
                tbOutVarFrom.Text = ((SLTestWorkspace)testWorkspace).outputVariable.from.ToString();
                tbOutVarTo.Text = ((SLTestWorkspace)testWorkspace).outputVariable.to.ToString();
                cmbOutVarDataType.Text = ((SLTestWorkspace)testWorkspace).outputVariable.parameterDataType.dataTypeName;
            }
            tbSimulationTime.Text = testWorkspace.GetSimulationTime().ToString();
            modelRunningTimeCurrentMilisec = testWorkspace.GetModelRunningTime();
        }*/

        private bool CheckAndSetTestSBParameters()
        {
            /*if (tbOutVarName.Text == "")
            {
                tbOutVarName.Focus();
                tbOutVarName.SelectAll();
                return false;
            }
            float outVarFrom;
            if (tbOutVarFrom.Text == "" ||
                !float.TryParse(tbOutVarFrom.Text, out outVarFrom))
            {
                tbOutVarFrom.Focus();
                tbOutVarFrom.SelectAll();
                return false;
            }
            float outVarTo;
            if (tbOutVarTo.Text == "" ||
                !float.TryParse(tbOutVarTo.Text, out outVarTo))
            {
                tbOutVarFrom.Focus();
                tbOutVarFrom.SelectAll();
                return false;
            }
            if (cmbOutVarDataType.SelectedIndex==-1)
            {
                cmbOutVarDataType.Focus();
                cmbOutVarDataType.SelectAll();
                return false;
            }*/

            testWorkspace.calibrationVariables.Clear();
            ((SLTestWorkspace)testWorkspace).inputVariables.Clear();

            for (int i = 0; i < lvVariables.Items.Count; ++i)
            {
                if (lvVariables.Items[i].SubItems[1].Text.Equals("Input"))
                    ((SLTestWorkspace)testWorkspace).AddInputVariable(
                        new TestParameter(lvVariables.Items[i].SubItems[0].Text,
                            ParameteresType.InputVariable,
                            float.Parse(lvVariables.Items[i].SubItems[2].Text),
                            float.Parse(lvVariables.Items[i].SubItems[3].Text),
                            float.Parse(lvVariables.Items[i].SubItems[5].Text),
                            lvVariables.Items[i].SubItems[4].Text));
                else if (lvVariables.Items[i].SubItems[1].Text.Equals("Configuration"))
                    testWorkspace.AddCalibrationVariable(
                        new TestParameter(lvVariables.Items[i].SubItems[0].Text,
                            ParameteresType.CalibrationVariable,
                            float.Parse(lvVariables.Items[i].SubItems[2].Text),
                            float.Parse(lvVariables.Items[i].SubItems[3].Text),
                            float.Parse(lvVariables.Items[i].SubItems[5].Text),
                            lvVariables.Items[i].SubItems[4].Text));
            }
            /*((SLTestWorkspace)testWorkspace).outputVariable=new TestParameter(tbOutVarName.Text,
                            ParameteresType.OutputVariable,
                            float.Parse(tbOutVarFrom.Text),
                            float.Parse(tbOutVarTo.Text),
                            cmbOutVarDataType.Text);*/

            testWorkspace.SetSimulationTime(
                Int16.Parse(tbSimulationTime.Text));
            return true;
        }


        private void lvCalibrationVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvVariables.SelectedIndices.Count <= 0)
                return;
            tbVarName.Text = lvVariables.SelectedItems[0].SubItems[0].Text;
            tbVarType.Text = lvVariables.SelectedItems[0].SubItems[1].Text;
            tbVarDT.Text = lvVariables.SelectedItems[0].SubItems[2].Text;
            tbVarFrom.Text = lvVariables.SelectedItems[0].SubItems[3].Text;
            tbVarMinTest.Text = tbVarFrom.Text;
            tbVarTo.Text = lvVariables.SelectedItems[0].SubItems[4].Text;
            tbVarMaxTest.Text = tbVarTo.Text;
            if (String.Equals(tbVarType.Text, "Configuration"))
            {
                cbUseDefForConfig.Enabled = true;
                cbUseDefForConfig.Checked = false;
            }
            else
            {
                cbUseDefForConfig.Enabled = false;
                cbUseDefForConfig.Checked = false;
            }
        }

        /*private void btnVarAdd_Click(object sender, EventArgs e)
        {
            if (tbVarName.Text == "")
            {
                tbVarName.Focus();
                tbVarName.SelectAll();
                return;
            }
            if (cmbType.SelectedIndex == -1)
            {
                cmbType.Focus();
                cmbType.SelectAll();
                return;
            }
            float varFrom;
            if (tbVarFrom.Text == "" ||
                !float.TryParse(tbVarFrom.Text, out varFrom))
            {
                tbVarFrom.Focus();
                tbVarFrom.SelectAll();
                return;
            }
            float varTo;
            if (tbVarTo.Text == "" ||
                !float.TryParse(tbVarTo.Text, out varTo))
            {
                tbVarTo.Focus();
                tbVarTo.SelectAll();
                return;
            }
            if (cmbDataType.SelectedIndex == -1)
            {
                cmbDataType.Focus();
                cmbDataType.SelectAll();
                return;
            }
            float varTestValue;
            if (tbVarTestValue.Text == "" ||
                !float.TryParse(tbVarTestValue.Text, out varTestValue) ||
                (varTestValue < varFrom) ||
                (varTestValue > varTo))
            {
                tbVarTestValue.Focus();
                tbVarTestValue.SelectAll();
                return;
            }
            string[] items = new string[6];
            items[0] = tbVarName.Text;
            items[1] = cmbType.Text;
            items[2] = tbVarFrom.Text;
            items[3] = tbVarTo.Text;
            items[4] = cmbDataType.Text;
            items[5] = tbVarTestValue.Text;
            ListViewItem listViewItem = new ListViewItem(items);
            bool repeatitive = false;
            for (int i = 0; i < lvVariables.Items.Count; ++i)
                if (lvVariables.Items[i].SubItems[0].Text == tbVarName.Text)
                {
                    repeatitive = true;
                    lvVariables.Items[i].SubItems[1].Text = cmbType.Text;
                    lvVariables.Items[i].SubItems[2].Text = tbVarFrom.Text;
                    lvVariables.Items[i].SubItems[3].Text = tbVarTo.Text;
                    lvVariables.Items[i].SubItems[4].Text = cmbDataType.Text;
                    lvVariables.Items[i].SubItems[5].Text = tbVarTestValue.Text;
                    break;
                }
            if (!repeatitive)
                lvVariables.Items.Add(listViewItem);
            btnVarRemove.Enabled = true;
            //ModelTestParametersChanged();

        }*/

        public override WizardForm CreateNextForm(TestWorkspace testWorkspace)
        {
            //if (SettingFilesManager.softwareRunningMode == SoftwareModeEnum.NormalMode)
                return new ModelUnderTestSLSettings((SLTestWorkspace)testWorkspace);
            //else
                //return new ModelUnderTestAdvancedSBSettingsForm((CCTestWorkspace)testWorkspace);
        }

        private void loadVariables()
        {
            tbSimulationTime.Text = testWorkspace.GetSimulationTime().ToString();
            lvVariables.Items.Clear();
            
            if (cmbVarType.SelectedIndex == 0 || cmbVarType.SelectedIndex == 1)
            {
                for (int i = 0; i < ((SLTestWorkspace)testWorkspace).inputVariables.Count; ++i)
                {
                    TestParameter inputVar = ((SLTestWorkspace)testWorkspace).inputVariables[i];
                    string[] items = new string[6];
                    items[0] = inputVar.blockInfo.blockTag;
                    items[1] = "Input";
                    items[2] = inputVar.parameterDataType.dataTypeName.ToString();
                    items[3] = inputVar.parameterDataType.minDataType.ToString();
                    items[4] = inputVar.parameterDataType.maxDataType.ToString();
                    items[5] = inputVar.blockInfo.blockPath.ToString();
                    ListViewItem listViewItem = new ListViewItem(items);
                    lvVariables.Items.Add(listViewItem);
                }
            }
            if (cmbVarType.SelectedIndex == 0 || cmbVarType.SelectedIndex == 2)
            {
                for (int i = 0; i < ((SLTestWorkspace)testWorkspace).calibrationVariables.Count; ++i)
                {
                    TestParameter calibVar = ((SLTestWorkspace)testWorkspace).calibrationVariables[i];
                    string[] items = new string[6];
                    items[0] = calibVar.blockInfo.blockTag;
                    items[1] = "Configuration";
                    items[2] = calibVar.parameterDataType.dataTypeName.ToString();
                    items[3] = calibVar.parameterDataType.minDataType.ToString();
                    items[4] = calibVar.parameterDataType.maxDataType.ToString();
                    items[5] = calibVar.blockInfo.blockPath.ToString();
                    ListViewItem listViewItem = new ListViewItem(items);
                    lvVariables.Items.Add(listViewItem);
                }
            }
            if (cmbVarType.SelectedIndex == 0 || cmbVarType.SelectedIndex == 3)
            {
                for (int i = 0; i < ((SLTestWorkspace)testWorkspace).outputVariables.Count; ++i)
                {
                    TestParameter outVar = ((SLTestWorkspace)testWorkspace).outputVariables[i];
                    string[] items = new string[6];
                    items[0] = outVar.blockInfo.blockTag;
                    items[1] = "Outuput";
                    items[2] = outVar.parameterDataType.dataTypeName.ToString();
                    items[3] = outVar.parameterDataType.minDataType.ToString();
                    items[4] = outVar.parameterDataType.maxDataType.ToString();
                    items[5] = outVar.blockInfo.blockPath.ToString();
                    ListViewItem listViewItem = new ListViewItem(items);
                    lvVariables.Items.Add(listViewItem);
                }
            }
        }

        private void extractModelInfo()
        {
            ExtractInfoForm extractInfoForm = new ExtractInfoForm();
            ErrorResult errorResult = extractInfoForm.ExtractInfo(testWorkspace);
            if (errorResult.errorCode != ErrorCode.Success)
                return;
            string extractInfoDir=String.Format("{0}\\{1}-Files\\", testWorkspace.modelSettings.GetSimulinkModelDirectory(),testWorkspace.modelSettings.GetSimulinkModelNameWithNoExtension());
            SettingFilesManager.LoadExtractionInfo(((SLTestWorkspace)testWorkspace),
                extractInfoDir, "ExtractInfo.xml");

            loadVariables();
        }


        private void btnRunModel_Click(object sender, EventArgs e)
        {
            /*if (!CheckAndSetTestSBParameters())
                return;
            TestRunProgressForm testRunProgressForm = new TestRunProgressForm();
            SLTestCase sbTestCase = new SLTestCase();
            for (int i = 0; i < ((SLTestWorkspace)testWorkspace).inputVariables.Count; ++i)
            {
                TestParameter tp=((SLTestWorkspace)testWorkspace).inputVariables[i];
                sbTestCase.inputVarsInitialValues.Add(tp.parameterName,tp.valueForTest);
                sbTestCase.inputVarsFinalValues.Add(tp.parameterName,tp.valueForTest);
                sbTestCase.inputVarsStepTimes.Add(tp.parameterName,((SLTestWorkspace)testWorkspace).GetSimulationTime()/2);
            }
            for (int i = 0; i < testWorkspace.calibrationVariables.Count; ++i)
            {
                TestParameter tp=((SLTestWorkspace)testWorkspace).calibrationVariables[i];
                sbTestCase.calibrationVars.Add(tp.parameterName, tp.valueForTest);
            }
            
            ErrorResult errorResult = testRunProgressForm.TestRunModel(testWorkspace, sbTestCase);
            if (errorResult.errorCode != ErrorCode.Success)
            {
                if (errorResult.errorCode != ErrorCode.TestRunCanceled)
                    MessageBox.Show("Error in Running the Model with this Information!",
                        "Error Running the Model", MessageBoxButtons.OK);
                //return;
            }
            modelRunningTimeCurrentMilisec = errorResult.errorParemeter;*/
        }
        
        private void SimulinkTestForm_Shown(object sender, EventArgs e)
        {
            extractModelInfo();
            lvVariables.Items[0].Selected = true;
            lvVariables.Focus();
        }

        private void lvVariables_DoubleClick(object sender, EventArgs e)
        {
            string blockPath = lvVariables.SelectedItems[0].SubItems[5].Text;
            HighlightBlcokRun highlightBlocRun = new HighlightBlcokRun(blockPath);
            highlightBlocRun.RunSync();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            lvVariables_DoubleClick(null, null);
        }

        

        private void cmbVarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadVariables();
            if (lvVariables.Items.Count > 0)
            {
                lvVariables.Items[0].Selected = true;
                //lvVariables.Items[0].Focused = true;
                lvVariables.Focus();
            }

        }

        private void cbUseDefForConfig_CheckedChanged(object sender, EventArgs e)
        {
            if(cbUseDefForConfig.Checked)
                tbVarMinTest.Enabled = tbVarMaxTest.Enabled = false;
            else
                tbVarMinTest.Enabled = tbVarMaxTest.Enabled = true;
        }
    }
}
