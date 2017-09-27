using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Bussiness.Settings;
using MiLTester.SourceCode.Bussiness.Workspace.Parameters;
using MiLTester.SourceCode.Service;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabCommands;
using System.Windows.Forms;
using System.IO;
using MiLTester.SourceCode.Bussiness.RunEngine;
using MiLTester.SourceCode.Common;

namespace MiLTester.SourceCode.Bussiness.Workspace
{
    public class CCTestWorkspace : TestWorkspace
    {
        public CCTestWorkspace(String workspaceName)
            : base(workspaceName, FunctionTypeEnum.Continuous_Controller)
        {
            if (SettingFilesManager.CCSettingsExists(SettingFilesManager.SettingsFolderPath))
            {
                ccSettings = SettingFilesManager.LoadCCSettings(SettingFilesManager.SettingsFolderPath);
                advancedCCSettings = SettingFilesManager.LoadAdvancedCCSettings(SettingFilesManager.SettingsFolderPath);
            }
            else
            {
                ccSettings = new CCSettings(true);
                advancedCCSettings = new AdvancedCCSettings();
            }   
        }
        public List<TestParameter> GetAllCCTestParameteres()
        {
            List<TestParameter> allCCTestParameteres = new List<TestParameter>();
            allCCTestParameteres.Add(desiredVariable);
            allCCTestParameteres.Add(actualVariable);
            foreach(TestParameter calibrationVar in calibrationVariables)
                allCCTestParameteres.Add(calibrationVar);
            return allCCTestParameteres;
        }


        public void ResetCalibrationVariables()
        {
            calibrationVariables.Clear();
        }

        public void SetCalibrationVairables(List<TestParameter> calibrationVariables)
        {
            this.calibrationVariables = calibrationVariables;
        }

        public List<TestParameter> GetCalibrationVairables()
        {
            return calibrationVariables;
        }

        public void SetDesiredValueVariable(TestParameter desiredVariable)
        {
            this.desiredVariable=desiredVariable;
        }

        public TestParameter GetDesiredValueVariable()
        {
            return desiredVariable;
        }

        public void SetActualValueVariable(TestParameter actualVariable)
        {
            this.actualVariable = actualVariable;
        }
        
        public TestParameter GetActualValueVariable()
        {
            return actualVariable;
        }

        public string GetCalibrationVariableMinimumsStr()
        {
            string calibrationVariableMinimumsStr = "";
            for (int i = 0; i < calibrationVariables.Count - 1; ++i)
                calibrationVariableMinimumsStr += calibrationVariables[i].from.ToString() + ' ';
            if (calibrationVariables.Count > 0)
                calibrationVariableMinimumsStr += calibrationVariables[calibrationVariables.Count - 1].from.ToString();
            return calibrationVariableMinimumsStr;
        }

        public string GetCalibrationVariableMaximumsStr()
        {
            string calibrationVariableMaximumsStr = "";
            for (int i = 0; i < calibrationVariables.Count - 1; ++i)
                calibrationVariableMaximumsStr += calibrationVariables[i].to.ToString() + ' ';
            if (calibrationVariables.Count > 0)
                calibrationVariableMaximumsStr += calibrationVariables[calibrationVariables.Count - 1].to.ToString();
            return calibrationVariableMaximumsStr;
        }


        public override TimeSpan GetTestEstimatedRunningTime()
        {
            return GetRandomExplorationEstimatedRunningTime() +
                GetSingleStateSearchEstimatedRunningTime();
        }

        public TimeSpan GetRandomExplorationEstimatedRunningTime()
        {
            long miliSecondsOfTest = 0;
            if (ccSettings.GetNumberOfSelectedRequirements() > 0)
            {
                miliSecondsOfTest = (long)(ccSettings.heatMapDiagramDivisionFactor * ccSettings.heatMapDiagramDivisionFactor *
                    ccSettings.numberOfPointsInEachRegion * modelRunningTime);
                if (advancedCCSettings.randomExplorationAlgorithm == RandomExplorationAlgorithmsEnum.AdaptiveRandomSearch)
                    miliSecondsOfTest = (long)(1.5 * miliSecondsOfTest);
                else
                    miliSecondsOfTest = (long)(3 * miliSecondsOfTest);
                miliSecondsOfTest += ccSettings.GetNumberOfSelectedRequirements() * 1000;//for creating heatmaps
                if (ccSettings.reportPotentialAnomalies)
                    miliSecondsOfTest += ccSettings.GetNumberOfSelectedRequirements() * 1000;
            }
            TimeSpan testTunningTime = new TimeSpan(0, 0, (int)(miliSecondsOfTest / 1000));
            return testTunningTime;
        }

        public TimeSpan GetRandomExplorationEstimatedRunningTime(CCSettings givenCCSettings)
        {
            long miliSecondsOfTest = 0;
            if (givenCCSettings.GetNumberOfSelectedRequirements() > 0)
            {
                miliSecondsOfTest = (long)(givenCCSettings.heatMapDiagramDivisionFactor * givenCCSettings.heatMapDiagramDivisionFactor *
                    givenCCSettings.numberOfPointsInEachRegion * modelRunningTime);
                if (advancedCCSettings.randomExplorationAlgorithm == RandomExplorationAlgorithmsEnum.AdaptiveRandomSearch)
                    miliSecondsOfTest = (long)(1.5 * miliSecondsOfTest);
                else
                    miliSecondsOfTest = (long)(3 * miliSecondsOfTest);
                miliSecondsOfTest += givenCCSettings.GetNumberOfSelectedRequirements() * 1000;//for creating heatmaps
                if (givenCCSettings.reportPotentialAnomalies)
                    miliSecondsOfTest += givenCCSettings.GetNumberOfSelectedRequirements() * 1000;
            }
            TimeSpan testTunningTime = new TimeSpan(0, 0, (int)(miliSecondsOfTest / 1000));
            return testTunningTime;
        }
        
        public float GetSigmaForSingleStateSearch()
        {
            float ExploitSigma=((GetDesiredValueVariable().to - GetDesiredValueVariable().from) / ccSettings.heatMapDiagramDivisionFactor)/10;
            if(advancedCCSettings.algorithmType==SingelStateSearchAlgorithmTypeEnum.Exploitative)
                return ExploitSigma;
            else
                return 3*ExploitSigma;
        }

        public float GetAnnealingScheduleForSingleStateSearch()
        {
            return 1;
        }

        public float GetAnnealingStartTemprature()
        {
            return 200;
        }
        
        public TimeSpan GetSingleStateSearchEstimatedRunningTime()
        {
            long miliSecondsOfTest = 0;
            if (ccSettings.GetNumberOfSelectedRequirements() > 0)
            {
                if (ccSettings.reportWorstTestCases)
                    miliSecondsOfTest += ccSettings.GetNumberOfSelectedRequirements() * ccSettings.numberOfWorstTestCases
                        * advancedCCSettings.algorithmIterations * modelRunningTime * advancedCCSettings.algorithmRounds;
            }
            TimeSpan testTunningTime = new TimeSpan(0, 0, (int)(miliSecondsOfTest / 1000));
            return testTunningTime;
        }

        public TimeSpan GetSingleStateSearchEstimatedRunningTime(CCSettings givenCCSettings)
        {
            long miliSecondsOfTest = 0;
            if (givenCCSettings.GetNumberOfSelectedRequirements() > 0)
            {
                if (givenCCSettings.reportWorstTestCases)
                    miliSecondsOfTest += givenCCSettings.GetNumberOfSelectedRequirements() * givenCCSettings.numberOfWorstTestCases
                        * advancedCCSettings.algorithmIterations * modelRunningTime * advancedCCSettings.algorithmRounds;
            }
            TimeSpan testTunningTime = new TimeSpan(0, 0, (int)(miliSecondsOfTest / 1000));
            return testTunningTime;
        }

        public TimeSpan GetTestEstimatedRunningTimeWithThisSettings(CCSettings givenCCSettings)
        {
            return GetRandomExplorationEstimatedRunningTime(givenCCSettings) +
                GetSingleStateSearchEstimatedRunningTime(givenCCSettings);
        }
        
        public override string GetTestParametersDetailsString()
        {
            string parametersDetailsString = "Continous Controller Test Parameteres:\r\n";
            parametersDetailsString += "\t" + desiredVariable.ToString() + "\r\n";
            parametersDetailsString += "\t" + actualVariable.ToString() + "\r\n";
            for (int i = 0; i < calibrationVariables.Count; ++i)
                parametersDetailsString += "\t" + calibrationVariables[i].ToString() + "\r\n";
            return parametersDetailsString;
        }

        public override string GetTestSettingsDetailsString()
        {
            string ccSettingsDetailsString = "Continous Controller Test Settings:\r\n";
            ccSettingsDetailsString+=ccSettings.ToString();
            ccSettingsDetailsString += advancedCCSettings.ToString();
            return ccSettingsDetailsString;
        }

        public float GetInitialDesiredValue()
        {
            return initialDesiredValue;
        }

        public float GetFinalDesiredValue()
        {
            return finalDesiredValue;
        }

        public void SetInitialDesiredValue(float initialDesiredValue)
        {
            this.initialDesiredValue = initialDesiredValue;
        }
        
        public override object Clone()
        {
            return this.MemberwiseClone();
        }

        public void SetFinalDesiredValue(float finalDesiredValue)
        {
            this.finalDesiredValue = finalDesiredValue;
        }

        public int GetSearchVariablesCnt()
        {
            return 2;
        }

        public int GetRandomExplorationMaxAlgorithmIterations()
        {
            int maxAlgorithmIterations = 0;
            maxAlgorithmIterations = ccSettings.heatMapDiagramDivisionFactor * ccSettings.heatMapDiagramDivisionFactor;
            maxAlgorithmIterations *= ccSettings.numberOfPointsInEachRegion;
            if(advancedCCSettings.randomExplorationAlgorithm==RandomExplorationAlgorithmsEnum.AdaptiveRandomSearch)
                maxAlgorithmIterations *= 3;
            else
                maxAlgorithmIterations *= 5;
            return maxAlgorithmIterations;
        }

        public int GetRandomExplorationMinAlgorithmIterations()
        {
            int minAlgorithmIterations = 0;
            minAlgorithmIterations = ccSettings.heatMapDiagramDivisionFactor * ccSettings.heatMapDiagramDivisionFactor;
            minAlgorithmIterations *= ccSettings.numberOfPointsInEachRegion;
            return minAlgorithmIterations;
        }

        private float initialDesiredValue,finalDesiredValue;

        private TestParameter desiredVariable = null, actualVariable = null;

        public CCSettings ccSettings;
        public AdvancedCCSettings advancedCCSettings;
    }
}
