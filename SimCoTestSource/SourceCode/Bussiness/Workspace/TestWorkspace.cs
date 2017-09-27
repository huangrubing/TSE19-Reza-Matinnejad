using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Bussiness.Settings;
using MiLTester.SourceCode.Service;
using MiLTester.SourceCode.Common;
using MiLTester.SourceCode.Bussiness.Workspace.Parameters;

namespace MiLTester.SourceCode.Bussiness.Workspace
{
    public enum FunctionTypeEnum
    {
        Continuous_Controller,
        State_Based_Controller,
        Input_Output
    };

    public class TestWorkspace : ICloneable
    {

        public TestWorkspace(String workspaceName, FunctionTypeEnum functionType)
        {
            this.workspaceName = workspaceName;
            this.functionType = functionType;
            if(SettingFilesManager.modelSettingsExists(SettingFilesManager.SettingsFolderPath))
                modelSettings = SettingFilesManager.LoadModelSettings(SettingFilesManager.SettingsFolderPath);
            else
                modelSettings = new ModelSettings();
        }

        public void SetModelRunningTime(int modelRunningTimeMiliSeconds)
        {
            this.modelRunningTime=modelRunningTimeMiliSeconds;
        }

        public virtual TimeSpan GetTestEstimatedRunningTime()
        {
            return new TimeSpan(0, 0, 0);
        }

        public int GetModelRunningTime()
        {
            return modelRunningTime;
        }
        
        public override string ToString()
        {
            return workspaceName;
        }

        public void AddCalibrationVariable(TestParameter ccTestParameter)
        {
            calibrationVariables.Add(ccTestParameter);
        }


        public string GetCalibrationVariableNamesStr()
        {
            string calibrationVariableNamesStr = "";
            for (int i = 0; i < calibrationVariables.Count - 1; ++i)
                calibrationVariableNamesStr += "'" + calibrationVariables[i].parameterName + "' ";
            if (calibrationVariables.Count > 0)
                calibrationVariableNamesStr += "'" + calibrationVariables[calibrationVariables.Count - 1].parameterName.ToString() + "'";
            return calibrationVariableNamesStr;
        }

        public string GetCalibrationVariableValuesStr()
        {
            string calibrationVariableValuesStr = "";
            for (int i = 0; i < calibrationVariables.Count - 1; ++i)
                calibrationVariableValuesStr += calibrationVariables[i].valueForTest.ToString() + ',';
            if (calibrationVariables.Count > 0)
                calibrationVariableValuesStr += calibrationVariables[calibrationVariables.Count - 1].valueForTest.ToString();
            return calibrationVariableValuesStr;
        }


        public string GetDetailsString()
        {

            string details = "Workspace Name: " + workspaceName + "\r\n" +
                "Function Type: " + functionType.ToString() + "\r\n" +
                "Simulink Model: " + modelSettings.GetSimulinkModelName() + "\r\n" +
                "Simulink Model Path: " + modelSettings.SimulinkModelPath+ "" + "\r\n\r\n";

            details += "Simulation Time: " + simulationTime.ToString() + " Seconds\r\n";
            details += "Model Running Time: " + modelRunningTime.ToString() + " MiliSeconds\r\n";
            details = details + GetTestParametersDetailsString();
            details = details + GetTestSettingsDetailsString();
            return details;
        }

        public void Rename(string newTestWorkspaceName)
        {
            workspaceName = newTestWorkspaceName;
        }

        public virtual string GetTestParametersDetailsString()
        {
            return "";
        }

        public virtual string GetTestSettingsDetailsString()
        {
            return "";
        }

        public void SetSimulationTime(float obsercationTimeinMiliSeconds)
        {
            this.simulationTime = obsercationTimeinMiliSeconds;
        }

        public float GetSimulationTime()
        {
            return simulationTime;
        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }

        public void SetWorkspaceName(string workspaceName)
        {
            this.workspaceName = workspaceName;
        }

        public virtual ErrorResult TestRunModel()
        {
            ErrorResult errorResult = new ErrorResult();
            errorResult.errorCode = ErrorCode.Success;
            return errorResult;
        }

        public List<TestParameter> calibrationVariables = new List<TestParameter>();


        public bool CreatedFromTemplate = false;
        protected int modelRunningTime = 0;
        protected float simulationTime = 2;
        private String workspaceName = "";
        public FunctionTypeEnum functionType;
        public ModelSettings modelSettings; 
    }
}
