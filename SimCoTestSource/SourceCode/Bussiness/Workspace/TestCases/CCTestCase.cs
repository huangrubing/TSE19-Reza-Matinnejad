using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Bussiness.Output.HeatMap;
using MiLTester.SourceCode.Bussiness.Workspace.Parameters;

namespace MiLTester.SourceCode.Bussiness.Workspace.TestCases
{
    public class CCTestCase
    {
        public float initialDesired;
        public float finalDesired;
        public HeatMapRegion heatMapRegion;

        public Dictionary<string, float> configParams = new Dictionary<string, float>();

        public string GetCalibrationVariableValuesStr(List<TestParameter> calibrationVariables)
        {
            string calibrationVariableValuesStr = "";
            for (int i = 0; i < calibrationVariables.Count - 1; ++i)
                calibrationVariableValuesStr += configParams[calibrationVariables[i].ToString()] + ',';
            if (calibrationVariables.Count > 0)
                calibrationVariableValuesStr += configParams[calibrationVariables[calibrationVariables.Count - 1].ToString()].ToString();
            return calibrationVariableValuesStr;
        }


    }
}
