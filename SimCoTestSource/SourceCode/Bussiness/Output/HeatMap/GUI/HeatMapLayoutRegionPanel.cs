using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MiLTester.SourceCode.Bussiness.Output.HeatMap.GUI
{
    public enum HeatMapLayoutRegionTypeEnum
    {
        Neutral,
        Active
    }
    public class HeatMapLayoutRegionPanel : Panel
    {
        public enum HeatMapLayoutRegionStatusEnum
        {
            Normal,
            Included,
            Excluded            
        }

        public HeatMapLayoutRegionPanel(bool IncludeorExclude)
        {
            this.heatMapLayoutRegionType = HeatMapLayoutRegionTypeEnum.Active;
            this.IncludeorExclude = IncludeorExclude;
        }

        public HeatMapLayoutRegionPanel(int indexI, int indexJ, float rangeStart, float rangeStop, int divisionFactor,
            IHeatMapTestCaseRunListener heatMapTestCaseRunListener)
        {
            this.heatMapLayoutRegionType = HeatMapLayoutRegionTypeEnum.Neutral;
            this.rangeStart=rangeStart;
            this.rangeStop = rangeStop;
            this.indexI = indexI;
            this.indexJ = indexJ;
            this.divisionFactor = divisionFactor;
            this.heatMapTestCaseRunListener = heatMapTestCaseRunListener;
        }


        public void SetIncludeorExlucde(bool IncludeorExclude)
        {
            this.IncludeorExclude = IncludeorExclude;
            switch (heatMapLayoutRegionStatus)
            {
                case HeatMapLayoutRegionStatusEnum.Included:
                    heatMapLayoutRegionStatus = HeatMapLayoutRegionStatusEnum.Excluded;
                    this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\MiLTesterFiles\\Images\\Exclude.png");
                    break;
                case HeatMapLayoutRegionStatusEnum.Excluded:
                    heatMapLayoutRegionStatus = HeatMapLayoutRegionStatusEnum.Included;
                    this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\MiLTesterFiles\\Images\\Include.png");
                    break;
            }
        }
        
        public void ChangeToNormal()
        {
            heatMapLayoutRegionStatus = HeatMapLayoutRegionStatusEnum.Normal;
            this.BackgroundImage = null;
        }

        public void ChangeToIncludeorExlucde()
        {
            if (IncludeorExclude)
            {
                heatMapLayoutRegionStatus = HeatMapLayoutRegionStatusEnum.Included;
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\MiLTesterFiles\\Images\\Include.png");
            }
            else
            {
                heatMapLayoutRegionStatus = HeatMapLayoutRegionStatusEnum.Excluded;
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\MiLTesterFiles\\Images\\Exclude.png");
            }
        }
        
        public bool GetNormalOrIncludeExcluded()
        {
            if (heatMapLayoutRegionStatus == HeatMapLayoutRegionStatusEnum.Normal)
                return true;
            return false;
        }

        protected override void OnClick(EventArgs e)
        {
            if (heatMapLayoutRegionType == HeatMapLayoutRegionTypeEnum.Neutral)
                return;
            if (heatMapLayoutRegionStatus != HeatMapLayoutRegionStatusEnum.Normal)
                ChangeToNormal();
            else
                ChangeToIncludeorExlucde();
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            if (heatMapLayoutRegionType != HeatMapLayoutRegionTypeEnum.Neutral)
                return;
            heatMapTestCaseRunListener.RunSelectedTestCase();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (heatMapLayoutRegionType != HeatMapLayoutRegionTypeEnum.Neutral)
                return;
            float fractionInRegionX = ((float)e.X) / this.Width;
            float fractionInRegionY = ((float)e.Y) / this.Height;
            float xTestCase = ((rangeStop - rangeStart) * indexI) / divisionFactor + fractionInRegionX * ((rangeStop - rangeStart) / divisionFactor);
            float yTestCase = rangeStop - (((rangeStop - rangeStart) * indexJ) / divisionFactor + fractionInRegionY * ((rangeStop - rangeStart) / divisionFactor));
            heatMapTestCaseRunListener.ShowCurrentPoint(xTestCase, yTestCase);
        }


        public HeatMapLayoutRegionTypeEnum heatMapLayoutRegionType =
            HeatMapLayoutRegionTypeEnum.Neutral;
        private IHeatMapTestCaseRunListener heatMapTestCaseRunListener;
        private bool IncludeorExclude = false;
        private HeatMapLayoutRegionStatusEnum heatMapLayoutRegionStatus =
            HeatMapLayoutRegionStatusEnum.Normal;
        float rangeStart, rangeStop;
        int indexI, indexJ;
        int divisionFactor;
    }
}
