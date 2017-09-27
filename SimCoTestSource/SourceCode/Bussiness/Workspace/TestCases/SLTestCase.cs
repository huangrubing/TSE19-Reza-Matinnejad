using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Bussiness.Workspace.Parameters;

namespace MiLTester.SourceCode.Bussiness.Workspace.TestCases
{
    public class SLTestCase
    {

        public int dsrdOutNo;
        public int dsrdTCNo;
        public string filesDir;
        public string testSuiteDir;

        public Dictionary<string, SLSignal> inputSignals = new Dictionary<string, SLSignal>();

        public Dictionary<string, float> calibrationVars = new Dictionary<string, float>();

        public string GetCalibrationVariableValuesStr(List<TestParameter> calibrationVariables)
        {
            string calibrationVariableValuesStr = "";
            for (int i = 0; i < calibrationVariables.Count - 1; ++i)
                calibrationVariableValuesStr += calibrationVars[calibrationVariables[i].parameterName].ToString() + ',';
            if (calibrationVariables.Count > 0)
                calibrationVariableValuesStr += calibrationVars[calibrationVariables[calibrationVariables.Count - 1].parameterName].ToString();
            return calibrationVariableValuesStr;
        }


        /*public string GetInputVariableInitialValuesStr(List<TestParameter> inputVariables)
        {
            string inputVariableInitialValuesStr = "";
            for (int i = 0; i < inputVariables.Count - 1; ++i)
                inputVariableInitialValuesStr += inputVarsInitialValues[inputVariables[i].parameterName].ToString() + ',';
            if (inputVariables.Count > 0)
                inputVariableInitialValuesStr += inputVarsInitialValues[inputVariables[inputVariables.Count - 1].parameterName].ToString();
            return inputVariableInitialValuesStr;
        }

        public string GetInputVariableFinalValuesStr(List<TestParameter> inputVariables)
        {
            string inputVariableFinalValuesStr = "";
            for (int i = 0; i < inputVariables.Count - 1; ++i)
                inputVariableFinalValuesStr += inputVarsFinalValues[inputVariables[i].parameterName].ToString() + ',';
            if (inputVariables.Count > 0)
                inputVariableFinalValuesStr += inputVarsFinalValues[inputVariables[inputVariables.Count - 1].parameterName].ToString();
            return inputVariableFinalValuesStr;
        }

        public string GetInputVariableStepTimesStr(List<TestParameter> inputVariables)
        {
            string inputVariableStepTimesStr = "";
            for (int i = 0; i < inputVariables.Count - 1; ++i)
                inputVariableStepTimesStr += inputVarsStepTimes[inputVariables[i].parameterName].ToString() + ',';
            if (inputVariables.Count > 0)
                inputVariableStepTimesStr += inputVarsStepTimes[inputVariables[inputVariables.Count - 1].parameterName].ToString();
            return inputVariableStepTimesStr;
        }*/



    }
}
