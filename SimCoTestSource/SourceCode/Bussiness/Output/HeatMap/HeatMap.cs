using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Bussiness.Output.HeatMap.GUI;

namespace MiLTester.SourceCode.Bussiness.Output.HeatMap
{

    public class HeatMap
    {
        public void AddPoint(HeatMapPoint heatMapPoint)
        {
            HeatMapData.Add(heatMapPoint);
        }
        
        public void FinalizeAddingPoints()
        {
            foreach (string requirementName in HeatMapData[0].objectiveFunctionValues.Keys)
                maximumValueOfObjectiveFunctions[requirementName] = minimumValueOfObjectiveFunctions[requirementName] = 
                    HeatMapData[0].objectiveFunctionValues[requirementName];
            foreach (HeatMapPoint heatMapPoint in HeatMapData)
            {
                foreach (string requirementName in heatMapPoint.objectiveFunctionValues.Keys)
                {
                    if(maximumValueOfObjectiveFunctions[requirementName] <
                        heatMapPoint.objectiveFunctionValues[requirementName])
                        maximumValueOfObjectiveFunctions[requirementName] = heatMapPoint.objectiveFunctionValues[requirementName];
                    if (minimumValueOfObjectiveFunctions[requirementName] >
                        heatMapPoint.objectiveFunctionValues[requirementName])
                        minimumValueOfObjectiveFunctions[requirementName] = heatMapPoint.objectiveFunctionValues[requirementName];
                }
            }
        }

        public float GetGrayColorRatio(int indexInitialDesired, int indexFinalDesired, int axisDivisionFactr, string requirementName)
        {
            float grayColorRatio;
            HeatMapPoint correspondingHeatMapPoint=HeatMapData.Find(
                delegate(HeatMapPoint heatMapPoint){
                    return (heatMapPoint.indexX == indexInitialDesired) && (heatMapPoint.indexY == indexFinalDesired);
                });
            
            grayColorRatio=correspondingHeatMapPoint.objectiveFunctionValues[requirementName];
            grayColorRatio-=minimumValueOfObjectiveFunctions[requirementName];
            if((maximumValueOfObjectiveFunctions[requirementName]-minimumValueOfObjectiveFunctions[requirementName])!=0)
                grayColorRatio/=(maximumValueOfObjectiveFunctions[requirementName]-minimumValueOfObjectiveFunctions[requirementName]);
            else
                grayColorRatio= 0;
            return grayColorRatio;
        }

        private Dictionary<string,float> maximumValueOfObjectiveFunctions = new Dictionary<string,float>();
        private Dictionary<string, float> minimumValueOfObjectiveFunctions = new Dictionary<string, float>();
        private List<HeatMapPoint> HeatMapData = new List<HeatMapPoint>();
    }
}
