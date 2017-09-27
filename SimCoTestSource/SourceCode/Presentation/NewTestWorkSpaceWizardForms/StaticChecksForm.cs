using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Bussiness.Workspace;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns;
using MiLTester.SourceCode.Service;
using MiLTester.SourceCode.Presentation.Results;

namespace MiLTester.SourceCode.Presentation.NewTestWorkSpaceWizardForms
{
    public partial class StaticChecksForm : WizardForm
    {
        public StaticChecksForm(TestWorkspace testWorkspace)
        {
            this.testWorkspace = testWorkspace;
            InitializeComponent();
            for (int i = 0; i < clbBlocks.Items.Count; i++)
              clbBlocks.SetItemChecked(i, true);
            for (int i = 0; i < clbParams.Items.Count; i++)
              clbParams.SetItemChecked(i, true); 
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        }

        public override WizardForm CreateNextForm(TestWorkspace testWorkspace)
        {
            return new SimulinkTestForm(testWorkspace);
        }


        private void checks_Click(object sender, EventArgs e)
        {
            ((SLTestWorkspace)testWorkspace).staticChecksBlcoks.Clear();
            StaticChecksRun staticChecksRun = new StaticChecksRun(testWorkspace);
            staticChecksRun.RunSync();

            string statChecksDir = String.Format("{0}\\{1}-Files\\", testWorkspace.modelSettings.GetSimulinkModelDirectory(), testWorkspace.modelSettings.GetSimulinkModelNameWithNoExtension());
            SettingFilesManager.LoadStaticChecks(((SLTestWorkspace)testWorkspace),
                statChecksDir, "StChecksBlocks.xml");
            bool[] blcoksCheck = new bool[clbBlocks.Items.Count];
            for (int i = 0; i < clbBlocks.Items.Count; i++)
                blcoksCheck[i]=clbBlocks.GetItemChecked(i);
            bool[] paramsCheck = new bool[clbParams.Items.Count];
            for (int i = 0; i < clbParams.Items.Count; i++)
                paramsCheck[i] = clbParams.GetItemChecked(i);
            CheckResultsForm checkResultsForm = new CheckResultsForm((SLTestWorkspace)testWorkspace, blcoksCheck, paramsCheck);
            checkResultsForm.ShowDialog();
        }
    }
}
