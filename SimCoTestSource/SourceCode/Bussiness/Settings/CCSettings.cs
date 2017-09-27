using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabCommands;
using MiLTester.SourceCode.Bussiness.Output.HeatMap;

namespace MiLTester.SourceCode.Bussiness.Settings
{
    public class CCSettings
    {
        public CCSettings(bool withRequirementsChecked)
        {
            normalOrIncludedExcludedRegion = new bool[MaxHMDivisionFactor][];
            for (int i = 0; i < MaxHMDivisionFactor; ++i)
            {
                normalOrIncludedExcludedRegion[i] = new bool[MaxHMDivisionFactor];
                for (int j = 0; j < MaxHMDivisionFactor; ++j)
                    normalOrIncludedExcludedRegion[i][j] = true;
            }
            Requirements.Add("Stability", withRequirementsChecked);
            Requirements.Add("Liveness", withRequirementsChecked);
            Requirements.Add("Smoothness", withRequirementsChecked);
            Requirements.Add("NormalizedSmoothness", withRequirementsChecked);
            Requirements.Add("Responsiveness", withRequirementsChecked);
        }
        
        public int GetNumberOfSelectedRequirements()
        {
            int ReqCount=0;
            for(int i=0;i<Requirements.Count;++i)
                if(Requirements.ElementAt(i).Value)
                    ++ReqCount;
            return ReqCount;
        }

        public List<HeatMapRegion> GetWorstHeatMapRegions(List<HeatMapRegion> heatMapRegions,string requirementName)
        {
            List<HeatMapRegion> worstHeatMapRegions = new List<HeatMapRegion>();
            if (Requirements[requirementName])
            {
                List<HeatMapRegion> requirementHeatMapRegions = new List<HeatMapRegion>();
                foreach (HeatMapRegion heatMapRegion in heatMapRegions)
                    if (heatMapRegion.requirementName == requirementName)
                        requirementHeatMapRegions.Add(heatMapRegion);
                List<HeatMapRegion> sortedRequirementHeatMapRegions = sortHeatMapRegionsList(requirementHeatMapRegions);
                for (int i = 0; (i < sortedRequirementHeatMapRegions.Count) && 
                    (worstHeatMapRegions.Count < numberOfWorstTestCases); ++i)
                    if (includeOrExcludeRegions)
                    {
                        if (!normalOrIncludedExcludedRegion[sortedRequirementHeatMapRegions[i].indexX][heatMapDiagramDivisionFactor - 1 - sortedRequirementHeatMapRegions[i].indexY])
                            worstHeatMapRegions.Add(sortedRequirementHeatMapRegions[i]);
                    }
                    else
                    {
                        if (normalOrIncludedExcludedRegion[sortedRequirementHeatMapRegions[i].indexX][heatMapDiagramDivisionFactor - 1 - sortedRequirementHeatMapRegions[i].indexY])
                            worstHeatMapRegions.Add(sortedRequirementHeatMapRegions[i]);
                    }
            }
            return worstHeatMapRegions;
        }

        private List<HeatMapRegion> sortHeatMapRegionsList(List<HeatMapRegion> heatMapRegionsList)
        {
            List<HeatMapRegion> sortedList = new List<HeatMapRegion>();
            for (int i = 0; i < heatMapRegionsList.Count; ++i)
                sortedList.Add(heatMapRegionsList[i]);
            for (int i = 0; i < sortedList.Count - 1; ++i)
                for (int j = i + 1; j < sortedList.Count; ++j)
                    if (sortedList[i].objectiveFunctionAverageValue < sortedList[j].objectiveFunctionAverageValue)
                    {
                        HeatMapRegion heatMapRegionTemp = sortedList[i];
                        sortedList[i] = sortedList[j];
                        sortedList[j] = heatMapRegionTemp;
                    }
            return sortedList;
        }

        public override string ToString()
        {
            string ccSettingsDetails="\tHeatMaps generated with axes divided into "+heatMapDiagramDivisionFactor+" parts, and\r\n";
            ccSettingsDetails += "\t" + numberOfPointsInEachRegion + " test cases were run in each region.\r\n";
            if(reportPotentialAnomalies)
                ccSettingsDetails += "\tReport for anomliaes in HeatMaps was also requested.\r\n";
            if (reportWorstTestCases)
                ccSettingsDetails += "\tWorst test cases were also requested for " + numberOfWorstTestCases + " most critical regions.\r\n";
            ccSettingsDetails += "\t" + GetNumberOfSelectedRequirements() + " requirement(s) were selected for the test.\r\n";
            return ccSettingsDetails;
        }


        //HeatMaps
        public int numberOfPointsInEachRegion = 10;
        public bool reportPotentialAnomalies = true;
        public int heatMapDiagramDivisionFactor = 10;
        //Worst Test Cases
        public bool reportWorstTestCases = true;
        public int numberOfWorstTestCases = 3;
        public bool includeOrExcludeRegions = false;//false for Exclude,True for Include
        public bool unionOrIntersectionOfRegions = true;//false for Intersection,True for Union
        public bool[][] normalOrIncludedExcludedRegion;//true for Normal,false for Included/Excluded

        public Dictionary<string, bool> Requirements = new Dictionary<string, bool>();

        public static int MinWorstTestCases = 1;

        public static int MinHMDivisionFactor = 3;
        public static int MaxHMDivisionFactor = 12;
        public static int MinPointsInEachRegion = 5;
        public static int MaxPointsInEachRegion = 99;
    }
    
}
