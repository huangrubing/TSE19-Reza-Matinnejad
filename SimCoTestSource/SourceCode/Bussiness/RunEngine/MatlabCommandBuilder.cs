using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabCommands;
using MiLTester.SourceCode.Bussiness.Settings;
using MiLTester.SourceCode.Bussiness.Workspace.Parameters;

namespace MiLTester.SourceCode.Bussiness.RunEngine
{
    public static class MatlabCommandBuilder
    {
        public static MatlabCommand GetModelSettingsMatlabCommand(ModelSettings modelSettings)
        {
            CompositeMatlabCommand psc = new CompositeMatlabCommand();
            for (int i = 0; i < modelSettings.MatlabScriptsPaths.Count; ++i)
                psc.AddCommand(new SingleMatlabCommand("run('" +
                    modelSettings.MatlabScriptsPaths[i] + "')"));
            for (int i = 0; i < modelSettings.MatlabPaths.Count; ++i)
                psc.AddCommand(new SingleMatlabCommand("addpath('" +
                    modelSettings.MatlabPaths[i] + "')"));
            return psc;
        }

        public static MatlabCommand GeHighlightBlcokMatlabCommand(string simBlockPath)
        {
            CompositeMatlabCommand psc = new CompositeMatlabCommand();
            psc.AddCommand(new SingleMatlabCommand("hilite_system('" +
                 simBlockPath + "')"));
            return psc;
        }

        public static MatlabCommand GetCloseWindowsMatlabCommand()
        {
            CompositeMatlabCommand psc = new CompositeMatlabCommand();
            psc.AddCommand(new SingleMatlabCommand("bdclose('all')"));
            return psc;
        }

        public static MatlabCommand GetCCParametersMatlabCommand(List<TestParameter> ccTestParameters)
        {
            CompositeMatlabCommand mcc = new CompositeMatlabCommand();
            for (int i = 0; i < ccTestParameters.Count; ++i)
            {
                mcc.AddCommand(new SingleMatlabCommand(ccTestParameters[i].parameterName));
                if (ccTestParameters[i].parameteresType == ParameteresType.DesiredVariable ||
                    ccTestParameters[i].parameteresType == ParameteresType.ActualVariable)
                {
                    mcc.AddCommand(new SingleMatlabCommand(ccTestParameters[i].parameterName + ".time"));
                    mcc.AddCommand(new SingleMatlabCommand(ccTestParameters[i].parameterName + ".signals"));
                    mcc.AddCommand(new SingleMatlabCommand(ccTestParameters[i].parameterName + ".signals.values"));
                }
            }
            return mcc;
        }

        public static string CreateDesiredValueInputSignalFunction = "Fn_MiLTester_CreateDesiredValueInputSignal";
        //public static string SetSimulationTimeFunction = "Fn_MiLTester_SetSimulationTime";
        public static string MainScriptFileName = "SC_MiLTester_MainScript";
        public static string ModelSettingsScriptFileName = "SC_MiLTester_ModelSettingsScript";
        public static string CCParametersScriptFileName = "SC_MiLTester_CCParametersScript";

    }
}
