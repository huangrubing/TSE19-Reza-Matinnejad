using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiLTester.SourceCode.Bussiness.Output.HeatMap
{
    public class HeatMapRegion
    {
        public int indexX;
        public float xStart;
        public float xEnd;
        public int indexY;
        public float yStart;
        public float yEnd;
        public string requirementName;
        public float objectiveFunctionAverageValue;
        public HeatMapPoint worstCasePointFromRandomExploration;
        public HeatMapPoint worstCasePointFromSingleStateSearch;
    }
}
