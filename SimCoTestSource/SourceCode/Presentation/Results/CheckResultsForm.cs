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
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns;

namespace MiLTester.SourceCode.Presentation.Results
{
    public partial class CheckResultsForm : Form
    {
        public CheckResultsForm(SLTestWorkspace slTestWorkspace,bool[] blocksChecks,bool[] paramsChecks)
        {
            InitializeComponent();
            bool blockCheck = false;
            for (int i=0;i<slTestWorkspace.staticChecksBlcoks.Count;++i)
            {
                string checkType="";
                switch(slTestWorkspace.staticChecksBlcoks[i].staticCheckType)
                {
                    case StaticCheckType.STOF:
                        if (!blocksChecks[0])
                            continue;
                        checkType="Saturate on overflow not cechekd!";
                        blockCheck = true;
                        break;
                    case StaticCheckType.FNoG:
                        if (!blocksChecks[1])
                            continue;
                        checkType="From without GoTo";
                        blockCheck = true;
                        break;
                     case StaticCheckType.GNoF:
                        if (!blocksChecks[2])
                            continue;
                        checkType="GoTo without From";
                        blockCheck = true;
                        break;
                     case StaticCheckType.NoSigRes:
                        if (!blocksChecks[3])
                            continue;
                        checkType = "Signal not resolved";
                        blockCheck = true;
                        break;
                     case StaticCheckType.ParMultVal:
                        if (!paramsChecks[0])
                            continue;                        
                        checkType = "Parameter with Multiple Values";
                        blockCheck = false;
                        break;
                     case StaticCheckType.TblOneVal:
                        if (!paramsChecks[1])
                            continue; 
                        checkType = "Table with one Value";
                        blockCheck = false;
                        break;

                     case StaticCheckType.TblAllTheSame:
                        if (!paramsChecks[2])
                            continue; 
                        checkType = "Table with values all the same";
                        blockCheck = false;
                        break;
                     case StaticCheckType.HighLowConf:
                        if (!paramsChecks[3])
                            continue; 
                        checkType = "High low conflict";
                        blockCheck = false;
                        break;
                }
                string[] items = new string[3];
                items[0] = checkType;
                items[1] = slTestWorkspace.staticChecksBlcoks[i].blockInfo.blockTag;
                items[2] = slTestWorkspace.staticChecksBlcoks[i].blockInfo.blockPath;
                ListViewItem listViewItem = new ListViewItem(items);
                if(blockCheck)
                    lvBlocksCheckResults.Items.Add(listViewItem);    
                else
                    lvParamsCheckResults.Items.Add(listViewItem);    
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            /*CloseOpenWindowsRun closeOpenWindowsRun = new CloseOpenWindowsRun();
            closeOpenWindowsRun.RunSync();*/
            Close();
        }

        private void lvCheckResults_DoubleClick(object sender, EventArgs e)
        {
            string blockPath=lvBlocksCheckResults.SelectedItems[0].SubItems[2].Text;
            HighlightBlcokRun highlightBlocRun = new HighlightBlcokRun(blockPath);
            highlightBlocRun.RunSync();


        }

        private void lvParamsCheckResults_DoubleClick(object sender, EventArgs e)
        {
            string blockPath = lvParamsCheckResults.SelectedItems[0].SubItems[2].Text;
            HighlightBlcokRun highlightBlocRun = new HighlightBlcokRun(blockPath);
            highlightBlocRun.RunSync();
        }

        private void btnOpenBlock_Click(object sender, EventArgs e)
        {
            lvCheckResults_DoubleClick(null, null);
        }

        private void btnOpenParam_Click(object sender, EventArgs e)
        {
            lvParamsCheckResults_DoubleClick(null, null);
        }
    }
}
