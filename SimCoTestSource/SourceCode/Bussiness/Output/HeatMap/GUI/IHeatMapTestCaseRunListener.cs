using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiLTester.SourceCode.Bussiness.Output.HeatMap.GUI
{
    public interface IHeatMapTestCaseRunListener
    {
        void ShowCurrentPoint(float xTestCase,float yTestCase);
        void RunSelectedTestCase();
        void RunSelectedTestCase(object sender, EventArgs e);
    }
}
