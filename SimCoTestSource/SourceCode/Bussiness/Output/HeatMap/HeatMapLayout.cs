using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Bussiness.Output.HeatMap.GUI;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Threading;

namespace MiLTester.SourceCode.Bussiness.Output.HeatMap
{
    public static class HeatMapLayout
    {
        public static void CreateHeatMapLayoutDiagram(Panel containerPanel, int AxesDivisionFactor, bool IncludeorExclude)
        {
            HeatMapLayout.AxesDivisionFactor = AxesDivisionFactor;
            containerPanel.BackColor = Color.Transparent;
            containerPanel.Controls.Clear();
            Size regionSize = new Size(containerPanel.Size.Width / AxesDivisionFactor,
                        containerPanel.Size.Width / AxesDivisionFactor);
            heatMapLayoutPanels = new HeatMapLayoutRegionPanel[AxesDivisionFactor][];
            for (int i = 0; i < AxesDivisionFactor; ++i)
                heatMapLayoutPanels[i] = new HeatMapLayoutRegionPanel[AxesDivisionFactor];
            for(int i=0;i<AxesDivisionFactor;++i)
                for(int j=0;j<AxesDivisionFactor;++j)
                {
                    HeatMapLayoutRegionPanel heatMapLayoutPanel = new HeatMapLayoutRegionPanel(IncludeorExclude);
                    heatMapLayoutPanel.Size = regionSize;
                    heatMapLayoutPanel.Location = new Point(regionSize.Width*i,
                        regionSize.Height * j);
                    heatMapLayoutPanel.BackColor = Color.White;
                    heatMapLayoutPanel.BorderStyle = BorderStyle.FixedSingle;
                    heatMapLayoutPanel.BackgroundImageLayout = ImageLayout.Zoom;
                    heatMapLayoutPanel.Visible = false;
                    heatMapLayoutPanel.Parent = containerPanel;
                    heatMapLayoutPanels[i][j] = heatMapLayoutPanel;
                }
            for (int i = 0; i < AxesDivisionFactor; ++i)
                for (int j = 0; j < AxesDivisionFactor; ++j)
                    heatMapLayoutPanels[i][j].Show();
        }

        public static void HighlightPoint(float x, float y)
        {
            highlightingImage.Location = new Point((int)((containerPanel.Size.Width / AxesDivisionFactor) * AxesDivisionFactor * x)-(highlightingImage.Width/2),
                containerPanel.Size.Height - (int)((containerPanel.Size.Height / AxesDivisionFactor) * AxesDivisionFactor * y) - (highlightingImage.Height / 2));
            highlightingImage.BringToFront();
            highlightingImage.Show();
        }

        public static void CreateHeatMapLayoutDiagram(Panel newContainerPanel, int AxesDivisionFactor,
            HeatMap heatMapDiagram, string selectedRequirement, float rangeStart, float rangeStop,
            IHeatMapTestCaseRunListener heatMapTestCaseRunListener)
        {

            HeatMapLayout.AxesDivisionFactor = AxesDivisionFactor;
            newContainerPanel.BackColor = Color.White;
            newContainerPanel.Controls.Clear();
            Size regionSize = new Size(newContainerPanel.Size.Width / AxesDivisionFactor,
                        newContainerPanel.Size.Width / AxesDivisionFactor);
            heatMapLayoutPanels = new HeatMapLayoutRegionPanel[AxesDivisionFactor][];
            for (int i = 0; i < AxesDivisionFactor; ++i)
                heatMapLayoutPanels[i] = new HeatMapLayoutRegionPanel[AxesDivisionFactor];
            for (int i = 0; i < AxesDivisionFactor; ++i)
                for (int j = 0; j < AxesDivisionFactor; ++j)
                {
                    HeatMapLayoutRegionPanel heatMapLayoutPanel = new HeatMapLayoutRegionPanel(
                        i, j, rangeStart, rangeStop, AxesDivisionFactor, heatMapTestCaseRunListener);

                    heatMapLayoutPanel.Size = regionSize;
                    heatMapLayoutPanel.Location = new Point(regionSize.Width * i,
                        regionSize.Height * j);
                    heatMapLayoutPanel.BackColor = HeatMapLayout.GenerateGrayColorBasedOnTheRatio(
                        heatMapDiagram.GetGrayColorRatio(i, AxesDivisionFactor - 1 - j, AxesDivisionFactor, selectedRequirement));
                    heatMapLayoutPanel.BorderStyle = BorderStyle.None;
                    heatMapLayoutPanel.BackgroundImageLayout = ImageLayout.Zoom;
                    heatMapLayoutPanel.Visible = false;
                    heatMapLayoutPanel.Parent = newContainerPanel;
                    heatMapLayoutPanels[i][j] = heatMapLayoutPanel;
                }
            for (int i = 0; i < AxesDivisionFactor; ++i)
                for (int j = 0; j < AxesDivisionFactor; ++j)
                    heatMapLayoutPanels[i][j].Show();
            containerPanel = newContainerPanel;
            highlightingImage = new Panel();
            highlightingImage.Size = new Size(regionSize.Width/3,regionSize.Height/3);
            highlightingImage.Parent = newContainerPanel;
            highlightingImage.BackgroundImageLayout = ImageLayout.Zoom;
            highlightingImage.BackColor = Color.Yellow;
            highlightingImage.DoubleClick += heatMapTestCaseRunListener.RunSelectedTestCase;
            highlightingImage.BorderStyle = BorderStyle.None;
            highlightingImage.Visible = false;
        }

        public static void ChangeLayoutRegionsToNormal(int rangeXStart, int rangeXEnd, int rangeYStart, int rangeYEnd)
        {
            if (rangeXStart >= rangeXEnd)
                return;
            if (rangeYStart >= rangeYEnd)
                return;
            for (int i = rangeXStart - 1; i < rangeXEnd - 1; ++i)
                for (int j = rangeYStart - 1; j < rangeYEnd - 1; ++j)
                    heatMapLayoutPanels[i][j].ChangeToNormal();
        }

        public static void ChangeLayoutRegionToIncludeorExlcude(int indexX, int indexY)
        {
            heatMapLayoutPanels[indexX][indexY].ChangeToIncludeorExlucde();
        }

        public static void ChangeLayoutRegionToNormal(int indexX, int indexY)
        {
            heatMapLayoutPanels[indexX][indexY].ChangeToNormal();
        }

        public static bool GetLayoutRegionNormalOrIncludeExcluded(int indexX, int indexY)
        {
            return heatMapLayoutPanels[indexX][indexY].GetNormalOrIncludeExcluded();
        }

        public static void ChangeLayoutRegionsToIncludeorExlcude(int rangeXStart, int rangeXEnd, int rangeYStart, int rangeYEnd)
        {
            if (rangeXStart >= rangeXEnd)
                return;
            if (rangeYStart >= rangeYEnd)
                return;
            for (int i = rangeXStart - 1; i < rangeXEnd - 1; ++i)
                for (int j = rangeYStart - 1; j < rangeYEnd - 1; ++j)
                    heatMapLayoutPanels[i][j].ChangeToIncludeorExlucde();
        }
        
        private static  Color GenerateGrayColorBasedOnTheRatio(float grayColorRatio)
        {
            int grayColor = (int)Math.Floor((1-grayColorRatio)*255);
            return Color.FromArgb(grayColor, grayColor, grayColor);            
        }

        private static  Color GenerateRandomGrayColor()
        {
            int randvalue = HeatMapLayout.rand.Next(0, 255);
            return Color.FromArgb(randvalue, randvalue, randvalue);            
        }
        
        public static void SetIncludeOrExcludeLayoutRegions(bool IncludeOrExclude)
        {
            for (int i = 0; i < HeatMapLayout.AxesDivisionFactor; ++i)
                for (int j = 0; j < HeatMapLayout.AxesDivisionFactor; ++j)
                    heatMapLayoutPanels[i][j].SetIncludeorExlucde(IncludeOrExclude);
        }

        static int AxesDivisionFactor = 0;
        static HeatMapLayoutRegionPanel[][] heatMapLayoutPanels;
        static Random rand = new Random();
        static Panel highlightingImage;
        static Panel containerPanel;
    }
}
