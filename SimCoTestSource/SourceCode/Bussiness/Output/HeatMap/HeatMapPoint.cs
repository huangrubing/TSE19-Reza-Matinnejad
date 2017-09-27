using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiLTester.SourceCode.Bussiness.Output.HeatMap
{
    public class HeatMapPoint
    {
        public int indexX;
        public float x;
        public float xStart;
        public float xEnd;
        public int indexY;
        public float y;
        public float yStart;
        public float yEnd;
        public Dictionary<string, float> objectiveFunctionValues = new Dictionary<string, float>();
    }
}
