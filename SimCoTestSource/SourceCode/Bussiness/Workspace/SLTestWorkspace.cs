using System;
using System.Collections.Generic;
using MiLTester.SourceCode.Bussiness.Settings;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Service;
using MiLTester.SourceCode.Bussiness.Workspace.Parameters;

namespace MiLTester.SourceCode.Bussiness.Workspace
{
    public class SLTestWorkspace : TestWorkspace
    {
        public SLTestWorkspace(String workspaceName)
            : base(workspaceName,FunctionTypeEnum.State_Based_Controller)
        {
            if (SettingFilesManager.SBSettingsExists(SettingFilesManager.SettingsFolderPath))
            {
                slSettings = SettingFilesManager.LoadSBSettings(SettingFilesManager.SettingsFolderPath);
                advancedSBSettings = SettingFilesManager.LoadAdvancedSBSettings(SettingFilesManager.SettingsFolderPath);
            }
            else
            {
                slSettings = new SLSettings(true);
                advancedSBSettings = new AdvancedSBSettings();
            } 

        }

        public override TimeSpan GetTestEstimatedRunningTime()
        {
            return new TimeSpan(0, 0, 3600);
        }



        public void AddInputVariable(TestParameter sbTestParameter)
        {
            inputVariables.Add(sbTestParameter);
        }

        public string GetInputVariableNamesStr()
        {
            string inputVariableNamesStr = "";
            for (int i = 0; i < inputVariables.Count - 1; ++i)
                inputVariableNamesStr += "'" + inputVariables[i].parameterName + "' ";
            if (inputVariables.Count > 0)
                inputVariableNamesStr += "'" + inputVariables[inputVariables.Count - 1].parameterName.ToString() + "'";
            return inputVariableNamesStr;
        }

        public override string GetTestParametersDetailsString()
        {
            string parametersDetailsString = "State-based Controllers Test Parameteres:\r\n";
            for (int i = 0; i < inputVariables.Count; ++i)
                parametersDetailsString += "\t" + inputVariables[i].ToString() + "\r\n";
            for (int i = 0; i < calibrationVariables.Count; ++i)
                parametersDetailsString += "\t" + calibrationVariables[i].ToString() + "\r\n";
            parametersDetailsString += "\t" + outputVariable.ToString() + "\r\n";
            return parametersDetailsString;
        }

        /*public string GetInputVariableInitialValuesStr()
        {
            string calibrationVariableValuesStr = "";
            for (int i = 0; i < calibrationVariables.Count - 1; ++i)
                calibrationVariableValuesStr += calibrationVariables[i].valueForTest.ToString() + ',';
            if (calibrationVariables.Count > 0)
                calibrationVariableValuesStr += calibrationVariables[calibrationVariables.Count - 1].valueForTest.ToString();
            return calibrationVariableValuesStr;
        }

        public string GetInputVariableFinalValuesStr()
        {
            string calibrationVariableValuesStr = "";
            for (int i = 0; i < calibrationVariables.Count - 1; ++i)
                calibrationVariableValuesStr += calibrationVariables[i].valueForTest.ToString() + ',';
            if (calibrationVariables.Count > 0)
                calibrationVariableValuesStr += calibrationVariables[calibrationVariables.Count - 1].valueForTest.ToString();
            return calibrationVariableValuesStr;
        }

        public string GetInputVariableStepTimesStr()
        {
            string calibrationVariableValuesStr = "";
            for (int i = 0; i < calibrationVariables.Count - 1; ++i)
                calibrationVariableValuesStr += calibrationVariables[i].valueForTest.ToString() + ',';
            if (calibrationVariables.Count > 0)
                calibrationVariableValuesStr += calibrationVariables[calibrationVariables.Count - 1].valueForTest.ToString();
            return calibrationVariableValuesStr;
        }*/

        public override string GetTestSettingsDetailsString()
        {
            string sbSettingsDetailsString = "State-based Controllers Test Settings:\r\n";
            sbSettingsDetailsString += slSettings.ToString();
            sbSettingsDetailsString += advancedSBSettings.ToString();
            return sbSettingsDetailsString;
        }


        public List<StaticCheckBlock> staticChecksBlcoks = new List<StaticCheckBlock>();

        public List<TestParameter> inputVariables = new List<TestParameter>();

        public List<TestParameter> outputVariables = new List<TestParameter>();

        public TestParameter outputVariable = null;
        
        public SLSettings slSettings;
        public AdvancedSBSettings advancedSBSettings;
    }

}
