using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MiLTester.SourceCode.Common;

namespace MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns.RunOutput
{
    public class RandomExplorationRunOutput : MatlabRunOutput
    {
        public RandomExplorationRunOutput(string outputLogPath, 
            string randomExplorationResultsFilePath, string heatMapDiagramsFilePath,
            string heatMapRegionsFilePath, string randomExplorationResultsFolderPath)
        {
            this.outputLogPath = outputLogPath;
            this.randomExplorationResultsFilePath = randomExplorationResultsFilePath;
            this.heatMapDiagramsFilePath = heatMapDiagramsFilePath;
            this.heatMapRegionsFilePath = heatMapRegionsFilePath;
            this.randomExplorationResultsFolderPath = randomExplorationResultsFolderPath; 
        }

        public string GetRandomExplorationResultsFolderPath()
        {
            return randomExplorationResultsFolderPath;
        }

        public override ErrorResult CheckOutput()
        {
            bool SuccessOrError;
            IsReady(out SuccessOrError);
            ErrorResult errorResult = new ErrorResult();
            if (!SuccessOrError)
            {
                errorResult.errorCode = ErrorCode.TestRunError;
                return errorResult;
            }
            if (!File.Exists(randomExplorationResultsFilePath))
            {
                errorResult.errorCode = ErrorCode.RandomExplorationResultsNotFound;
                return errorResult;
            }
            if (!File.Exists(heatMapDiagramsFilePath))
            {
                errorResult.errorCode = ErrorCode.HeatMapDiagramsNotFound;
                return errorResult;
            }
            if (!File.Exists(heatMapRegionsFilePath))
            {
                errorResult.errorCode = ErrorCode.HeatMapRegionsNotFound;
                return errorResult;
            }
            errorResult.errorCode = ErrorCode.Success;
            return errorResult;
        }

        protected string randomExplorationResultsFolderPath;
        protected string randomExplorationResultsFilePath;
        protected string heatMapDiagramsFilePath;
        protected string heatMapRegionsFilePath;

    }
}
