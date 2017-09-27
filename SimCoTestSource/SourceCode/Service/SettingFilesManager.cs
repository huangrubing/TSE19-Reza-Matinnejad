using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiLTester.SourceCode.Bussiness.Settings;
using System.Xml;
using System.IO;
using MiLTester.SourceCode.Bussiness.Workspace;
using MiLTester.SourceCode.Bussiness.Workspace.Parameters;

namespace MiLTester.SourceCode.Service
{
    public enum SoftwareModeEnum
    {
        NormalMode,
        MaintenanceMode
    }

    public static class SettingFilesManager
    {
        public static SoftwareModeEnum softwareRunningMode = SoftwareModeEnum.NormalMode;

        public static string SettingsFolderPath =
            Application.StartupPath + "\\MiLTesterFiles\\Settings\\";

        private static string ProgramSettingsFileName = "ProgramSettings.xml";

        private static string ModelSettingsFileName = "ModelSettings.xml";

        private static string CCSettingsFileName = "CCSettings.xml";

        private static string SBSettingsFileName = "SBSettings.xml";

        private static string AdvancedCCSettingsFileName = "AdvancedCCSettings.xml";

        private static string AdvancedSBSettingsFileName = "AdvancedSBSettings.xml";


        public static bool modelSettingsExists(string folderPath)
        {
            if (File.Exists(folderPath + ModelSettingsFileName))
                return true;
            return false;
        }

        public static bool programSettingsExists(string folderPath)
        {
            if (File.Exists(folderPath + ProgramSettingsFileName))
                return true;
            return false;
        }

        public static bool CCSettingsExists(string folderPath)
        {
            if (File.Exists(folderPath + CCSettingsFileName))
                return true;
            return false;
        }

        public static bool SBSettingsExists(string folderPath)
        {
            if (File.Exists(folderPath + SBSettingsFileName))
                return true;
            return false;
        }

        public static bool AdvancedCCSettingsExists(string folderPath)
        {
            if (File.Exists(folderPath + AdvancedCCSettingsFileName))
                return true;
            return false;
        }

        public static bool AdvancedSBSettingsExists(string folderPath)
        {
            if (File.Exists(folderPath + AdvancedSBSettingsFileName))
                return true;
            return false;
        }

        public static ModelSettings LoadModelSettings(string folderPath)
        {
            ModelSettings modelSettings = new
                ModelSettings();
            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.ValidationType = ValidationType.None;

            XmlReader settingsReader = XmlReader.Create(folderPath + ModelSettingsFileName, xmlSettings);
            while (settingsReader.Read())
            {
                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "MatlabExePath")
                {
                    settingsReader.Read();
                    modelSettings.MatlabExePath = settingsReader.Value;
                    settingsReader.Read();
                }
                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "SimulinkModelPath")
                {
                    settingsReader.Read();
                    modelSettings.SimulinkModelPath = settingsReader.Value;
                    settingsReader.Read();
                }
                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "MatlabScript")
                {
                    settingsReader.Read();
                    modelSettings.MatlabScriptsPaths.Add(settingsReader.Value);
                    settingsReader.Read();
                }
                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "MatlabPath")
                {
                    settingsReader.Read();
                    modelSettings.MatlabPaths.Add(settingsReader.Value);
                    settingsReader.Read();
                }
            }
            settingsReader.Close();
            return modelSettings;
        }

        public static void SaveModelSettings(string folderPath,
            ModelSettings modelSettings)
        {
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            XmlWriter settingsWriter = XmlWriter.Create(folderPath + ModelSettingsFileName, xmlSettings);

            settingsWriter.WriteStartElement("body");

            settingsWriter.WriteStartElement("MatlabExePath");
            settingsWriter.WriteValue(modelSettings.MatlabExePath);
            settingsWriter.WriteEndElement();

            settingsWriter.WriteStartElement("SimulinkModelPath");
            settingsWriter.WriteValue(modelSettings.SimulinkModelPath);
            settingsWriter.WriteEndElement();

            for (int i = 0; i < modelSettings.MatlabScriptsPaths.Count; ++i)
            {
                settingsWriter.WriteStartElement("MatlabScript");
                settingsWriter.WriteValue(modelSettings.MatlabScriptsPaths[i]);
                settingsWriter.WriteEndElement();
            }

            for (int i = 0; i < modelSettings.MatlabPaths.Count; ++i)
            {
                settingsWriter.WriteStartElement("MatlabPath");
                settingsWriter.WriteValue(modelSettings.MatlabPaths[i]);
                settingsWriter.WriteEndElement();
            }

            settingsWriter.WriteEndElement();
            settingsWriter.Close();
        }

        public static ProgramSettings LoadProgramSettings(string folderPath)
        {
            ProgramSettings programSettings = new
                ProgramSettings();
            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.ValidationType = ValidationType.None;

            XmlReader settingsReader = XmlReader.Create(folderPath + ProgramSettingsFileName, xmlSettings);
            while (settingsReader.Read())
            {
                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "TestWorkspacesLastPath")
                {
                    settingsReader.Read();
                    programSettings.TestWorkspacesLastPath = settingsReader.Value;
                    settingsReader.Read();
                }
            }
            settingsReader.Close();
            return programSettings;
        }

        public static void SaveProgramSettings(string folderPath,
            ProgramSettings programSettings)
        {
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            XmlWriter settingsWriter = XmlWriter.Create(folderPath + ProgramSettingsFileName, xmlSettings);

            settingsWriter.WriteStartElement("body");

            settingsWriter.WriteStartElement("TestWorkspacesLastPath");
            settingsWriter.WriteValue(programSettings.TestWorkspacesLastPath);
            settingsWriter.WriteEndElement();

            settingsWriter.WriteEndElement();
            settingsWriter.Close();
        }

        public static CCSettings LoadCCSettings(string folderPath)
        {
            CCSettings ccSettings = new
                CCSettings(false);

            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.ValidationType = ValidationType.None;

            XmlReader settingsReader = XmlReader.Create(folderPath + CCSettingsFileName, xmlSettings);
            while (settingsReader.Read())
            {
                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "HeatMapDiagramDivisionFactor")
                {
                    settingsReader.Read();
                    ccSettings.heatMapDiagramDivisionFactor = Int16.Parse(settingsReader.Value);
                    settingsReader.Read();
                }
                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "NumberOfPointsInEachRegion")
                {
                    settingsReader.Read();
                    ccSettings.numberOfPointsInEachRegion = Int16.Parse(settingsReader.Value);
                    settingsReader.Read();
                }
                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "ReportPotentialAnomalies")
                {
                    settingsReader.Read();
                    ccSettings.reportPotentialAnomalies = Boolean.Parse(settingsReader.Value);
                    settingsReader.Read();
                }
                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "ReportWorstTestCases")
                {
                    settingsReader.Read();
                    ccSettings.reportWorstTestCases = Boolean.Parse(settingsReader.Value);
                    settingsReader.Read();
                }
                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "NumberOfWorstTestCases")
                {
                    settingsReader.Read();
                    ccSettings.numberOfWorstTestCases = Int16.Parse(settingsReader.Value);
                    settingsReader.Read();
                }
                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "IncludeOrExcludeRegions")
                {
                    settingsReader.Read();
                    ccSettings.includeOrExcludeRegions = Boolean.Parse(settingsReader.Value);
                    settingsReader.Read();
                }
                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "Region")
                {
                    do
                        settingsReader.Read();
                    while (settingsReader.Name != "IndexI");
                    settingsReader.Read();
                    int indexI = Int16.Parse(settingsReader.Value);
                    do
                        settingsReader.Read();
                    while (settingsReader.Name != "IndexJ");
                    settingsReader.Read();
                    int indexJ = Int16.Parse(settingsReader.Value);
                    ccSettings.normalOrIncludedExcludedRegion[indexI][indexJ] = false;
                    settingsReader.Read();
                }
                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "UnionOrIntersectionOfSliders")
                {
                    settingsReader.Read();
                    ccSettings.unionOrIntersectionOfRegions = Boolean.Parse(settingsReader.Value);
                    settingsReader.Read();
                }
                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "Requirement")
                {
                    settingsReader.Read();
                    ccSettings.Requirements[settingsReader.Value] = true;
                    settingsReader.Read();
                }
            }
            settingsReader.Close();
            return ccSettings;
        }

        public static void SaveCCSettings(string folderPath, CCSettings ccSettings)
        {
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            XmlWriter settingsWriter = XmlWriter.Create(folderPath + CCSettingsFileName, xmlSettings);

            settingsWriter.WriteStartElement("body");

            settingsWriter.WriteStartElement("HeatMapDiagramDivisionFactor");
            settingsWriter.WriteValue(ccSettings.heatMapDiagramDivisionFactor);
            settingsWriter.WriteEndElement();

            settingsWriter.WriteStartElement("NumberOfPointsInEachRegion");
            settingsWriter.WriteValue(ccSettings.numberOfPointsInEachRegion);
            settingsWriter.WriteEndElement();

            settingsWriter.WriteStartElement("ReportPotentialAnomalies");
            settingsWriter.WriteValue(ccSettings.reportPotentialAnomalies);
            settingsWriter.WriteEndElement();

            settingsWriter.WriteStartElement("ReportWorstTestCases");
            settingsWriter.WriteValue(ccSettings.reportWorstTestCases);
            settingsWriter.WriteEndElement();

            settingsWriter.WriteStartElement("NumberOfWorstTestCases");
            settingsWriter.WriteValue(ccSettings.numberOfWorstTestCases);
            settingsWriter.WriteEndElement();

            settingsWriter.WriteStartElement("IncludeOrExcludeRegions");
            settingsWriter.WriteValue(ccSettings.includeOrExcludeRegions);
            settingsWriter.WriteEndElement();

            for (int i = 0; i < CCSettings.MaxHMDivisionFactor; ++i)
                for (int j = 0; j < CCSettings.MaxHMDivisionFactor; ++j)
                {
                    if (!ccSettings.normalOrIncludedExcludedRegion[i][j])
                    {
                        settingsWriter.WriteStartElement("Region");
                        settingsWriter.WriteStartElement("IndexI");
                        settingsWriter.WriteValue(i);
                        settingsWriter.WriteEndElement();
                        settingsWriter.WriteStartElement("IndexJ");
                        settingsWriter.WriteValue(j);
                        settingsWriter.WriteEndElement();
                        settingsWriter.WriteEndElement();
                    }
                }

            settingsWriter.WriteStartElement("UnionOrIntersectionOfSliders");
            settingsWriter.WriteValue(ccSettings.unionOrIntersectionOfRegions);
            settingsWriter.WriteEndElement();

            foreach (string req in ccSettings.Requirements.Keys)
            {
                if (ccSettings.Requirements[req])
                {
                    settingsWriter.WriteStartElement("Requirement");
                    settingsWriter.WriteValue(req);
                    settingsWriter.WriteEndElement();
                }
            }
            settingsWriter.WriteEndElement();
            settingsWriter.Close();
        }

        public static SLSettings LoadSBSettings(string folderPath)
        {
            SLSettings sbSettings = new
                SLSettings(false);

            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.ValidationType = ValidationType.None;

            XmlReader settingsReader = XmlReader.Create(folderPath + SBSettingsFileName, xmlSettings);
            while (settingsReader.Read())
            {
                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "Criterion")
                {
                    do
                        settingsReader.Read();
                    while (settingsReader.Name != "Name");
                    settingsReader.Read();
                    string criterionName = settingsReader.Value;
                    do
                        settingsReader.Read();
                    while (settingsReader.Name != "Budget");
                    settingsReader.Read();
                    int budget = Int16.Parse(settingsReader.Value);
                    sbSettings.Criteria[criterionName] = budget;
                    settingsReader.Read();
                }
            }
            settingsReader.Close();
            return sbSettings;
        }

        public static void SaveSBSettings(string folderPath, SLSettings sbSettings)
        {
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            XmlWriter settingsWriter = XmlWriter.Create(folderPath + SBSettingsFileName, xmlSettings);

            settingsWriter.WriteStartElement("body");

            foreach (string criName in sbSettings.Criteria.Keys)
            {
                settingsWriter.WriteStartElement("Criterion");

                settingsWriter.WriteStartElement("Name");
                settingsWriter.WriteValue(criName);
                settingsWriter.WriteEndElement();

                settingsWriter.WriteStartElement("Budget");
                settingsWriter.WriteValue(sbSettings.Criteria[criName].ToString());
                settingsWriter.WriteEndElement();

                settingsWriter.WriteEndElement();
            }

            settingsWriter.WriteEndElement();
            settingsWriter.Close();
        }


        public static AdvancedSBSettings LoadAdvancedSBSettings(string folderPath)
        {
            AdvancedSBSettings adsbSettings = new
                AdvancedSBSettings();

            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.ValidationType = ValidationType.None;

            XmlReader settingsReader = XmlReader.Create(folderPath + AdvancedSBSettingsFileName, xmlSettings);
            while (settingsReader.Read())
            {
                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "Candidates")
                {
                    settingsReader.Read();
                    adsbSettings.candidates =
                        Int16.Parse(settingsReader.Value);
                    settingsReader.Read();
                }
            }
            settingsReader.Close();
            return adsbSettings;
        }

        public static AdvancedCCSettings LoadAdvancedCCSettings(string folderPath)
        {
            AdvancedCCSettings adccSettings = new
                AdvancedCCSettings();

            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.ValidationType = ValidationType.None;

            XmlReader settingsReader = XmlReader.Create(folderPath + AdvancedCCSettingsFileName, xmlSettings);
            while (settingsReader.Read())
            {
                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "RandomExplorationAlgorithm")
                {
                    settingsReader.Read();
                    adccSettings.randomExplorationAlgorithm =
                        (RandomExplorationAlgorithmsEnum)Enum.Parse(typeof(RandomExplorationAlgorithmsEnum), settingsReader.Value, true); ;
                    settingsReader.Read();
                }

                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "EscapeRandomExploration")
                {
                    settingsReader.Read();
                    adccSettings.escapeRandomExploration = bool.Parse(settingsReader.Value);
                    settingsReader.Read();
                }

                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "LocalSearchAlgorithm")
                {
                    settingsReader.Read();
                    adccSettings.singelStateSearchAlgorithm =
                        (SingelStateSearchAlgorithmsEnum)Enum.Parse(typeof(SingelStateSearchAlgorithmsEnum), settingsReader.Value, true); ;
                    settingsReader.Read();
                }

                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "AlgorithmIterations")
                {
                    settingsReader.Read();
                    adccSettings.algorithmIterations =
                        Int16.Parse(settingsReader.Value);
                    settingsReader.Read();
                }

                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "AlgorithmRounds")
                {
                    settingsReader.Read();
                    adccSettings.algorithmRounds =
                        Int16.Parse(settingsReader.Value);
                    settingsReader.Read();
                }
                if (settingsReader.NodeType == XmlNodeType.Element &&
                    settingsReader.Name == "AlgorithmType")
                {
                    settingsReader.Read();
                    adccSettings.algorithmType =
                        (SingelStateSearchAlgorithmTypeEnum)Enum.Parse(typeof(SingelStateSearchAlgorithmTypeEnum), settingsReader.Value, true);
                    settingsReader.Read();
                }
            }
            settingsReader.Close();
            return adccSettings;
        }

        public static void SaveAdvancedCCSettings(string folderPath, AdvancedCCSettings adCCSettings)
        {
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            XmlWriter settingsWriter = XmlWriter.Create(folderPath + AdvancedCCSettingsFileName, xmlSettings);

            settingsWriter.WriteStartElement("body");

            settingsWriter.WriteStartElement("RandomExplorationAlgorithm");
            settingsWriter.WriteValue(adCCSettings.randomExplorationAlgorithm.ToString());
            settingsWriter.WriteEndElement();

            settingsWriter.WriteStartElement("EscapeRandomExploration");
            settingsWriter.WriteValue(adCCSettings.escapeRandomExploration.ToString());
            settingsWriter.WriteEndElement();

            settingsWriter.WriteStartElement("LocalSearchAlgorithm");
            settingsWriter.WriteValue(adCCSettings.singelStateSearchAlgorithm.ToString());
            settingsWriter.WriteEndElement();

            settingsWriter.WriteStartElement("AlgorithmIterations");
            settingsWriter.WriteValue(adCCSettings.algorithmIterations.ToString());
            settingsWriter.WriteEndElement();

            settingsWriter.WriteStartElement("AlgorithmRounds");
            settingsWriter.WriteValue(adCCSettings.algorithmRounds.ToString());
            settingsWriter.WriteEndElement();

            settingsWriter.WriteStartElement("AlgorithmType");
            settingsWriter.WriteValue(adCCSettings.algorithmType.ToString
                ());
            settingsWriter.WriteEndElement();

            settingsWriter.WriteEndElement();
            settingsWriter.Close();
        }

        public static void SaveAdvancedSBSettings(string folderPath, AdvancedSBSettings adSBSettings)
        {
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            XmlWriter settingsWriter = XmlWriter.Create(folderPath + AdvancedSBSettingsFileName, xmlSettings);

            settingsWriter.WriteStartElement("body");

            settingsWriter.WriteStartElement("Candidates");
            settingsWriter.WriteValue(adSBSettings.candidates.ToString());
            settingsWriter.WriteEndElement();

            settingsWriter.WriteEndElement();
            settingsWriter.Close();
        }

        public static void LoadStaticChecks(SLTestWorkspace testWorkspace, string folderPath, string fileName)
        {
            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.ValidationType = ValidationType.None;
            XmlReader infoReader = XmlReader.Create(folderPath + fileName, xmlSettings);
            while (infoReader.Read())
            {
                StaticCheckBlock staticCheckBlock;

                if (infoReader.NodeType == XmlNodeType.Element &&
                    infoReader.Name == "NoStOF")
                {
                    do
                        infoReader.Read();
                    while (infoReader.Name != "Tag");
                    infoReader.Read();
                    string blockTag = infoReader.Value;

                    do
                        infoReader.Read();
                    while (infoReader.Name != "Path");
                    infoReader.Read();
                    staticCheckBlock = new StaticCheckBlock(StaticCheckType.STOF, new BlockInfo(infoReader.Value, blockTag));
                    infoReader.Read();
                    testWorkspace.staticChecksBlcoks.Add(staticCheckBlock);
                }
                else if (infoReader.NodeType == XmlNodeType.Element &&
                    infoReader.Name == "GoToNoFrom")
                {
                    do
                        infoReader.Read();
                    while (infoReader.Name != "Tag");
                    infoReader.Read();
                    string blockTag = infoReader.Value;

                    do
                        infoReader.Read();
                    while (infoReader.Name != "Path");
                    infoReader.Read();
                    staticCheckBlock = new StaticCheckBlock(StaticCheckType.GNoF, new BlockInfo(infoReader.Value, blockTag));
                    infoReader.Read();
                    testWorkspace.staticChecksBlcoks.Add(staticCheckBlock);
                }
                else if (infoReader.NodeType == XmlNodeType.Element &&
                    infoReader.Name == "FromNoGoTo")
                {
                    do
                        infoReader.Read();
                    while (infoReader.Name != "Tag");
                    infoReader.Read();
                    string blockTag = infoReader.Value;

                    do
                        infoReader.Read();
                    while (infoReader.Name != "Path");
                    infoReader.Read();
                    staticCheckBlock = new StaticCheckBlock(StaticCheckType.FNoG, new BlockInfo(infoReader.Value, blockTag));
                    infoReader.Read();
                    testWorkspace.staticChecksBlcoks.Add(staticCheckBlock);
                }
                else if (infoReader.NodeType == XmlNodeType.Element &&
                    infoReader.Name == "TblAllTheSame")
                {
                    do
                        infoReader.Read();
                    while (infoReader.Name != "Tag");
                    infoReader.Read();
                    string blockTag = infoReader.Value;

                    do
                        infoReader.Read();
                    while (infoReader.Name != "Path");
                    infoReader.Read();
                    staticCheckBlock = new StaticCheckBlock(StaticCheckType.TblAllTheSame, new BlockInfo(infoReader.Value, blockTag));
                    infoReader.Read();
                    testWorkspace.staticChecksBlcoks.Add(staticCheckBlock);
                }
                else if (infoReader.NodeType == XmlNodeType.Element &&
                    infoReader.Name == "TblOneVal")
                {
                    do
                        infoReader.Read();
                    while (infoReader.Name != "Tag");
                    infoReader.Read();
                    string blockTag = infoReader.Value;

                    do
                        infoReader.Read();
                    while (infoReader.Name != "Path");
                    infoReader.Read();
                    staticCheckBlock = new StaticCheckBlock(StaticCheckType.TblOneVal, new BlockInfo(infoReader.Value, blockTag));
                    infoReader.Read();
                    testWorkspace.staticChecksBlcoks.Add(staticCheckBlock);
                }
                else if (infoReader.NodeType == XmlNodeType.Element &&
                    infoReader.Name == "ParMultVal")
                {
                    do
                        infoReader.Read();
                    while (infoReader.Name != "Tag");
                    infoReader.Read();
                    string blockTag = infoReader.Value;

                    do
                        infoReader.Read();
                    while (infoReader.Name != "Path");
                    infoReader.Read();
                    staticCheckBlock = new StaticCheckBlock(StaticCheckType.ParMultVal, new BlockInfo(infoReader.Value, blockTag));
                    infoReader.Read();
                    testWorkspace.staticChecksBlcoks.Add(staticCheckBlock);
                }



            }
            infoReader.Close();
            return;
        }


        public static void LoadExtractionInfo(SLTestWorkspace testWorkspace, string folderPath, string fileName)
        {
            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.ValidationType = ValidationType.None;
            XmlReader infoReader = XmlReader.Create(folderPath + fileName, xmlSettings);
            while (infoReader.Read())
            {

                if (infoReader.NodeType == XmlNodeType.Element &&
                    infoReader.Name == "SimInfo")
                {
                    do
                        infoReader.Read();
                    while (infoReader.Name != "SimTime");
                    infoReader.Read();
                    float simTimeMs = float.Parse(infoReader.Value);

                    infoReader.Read();

                    testWorkspace.SetSimulationTime(simTimeMs);
                }

                if (infoReader.NodeType == XmlNodeType.Element &&
                    infoReader.Name == "Input")
                {
                    ParameterDataType parameterDataType;

                    do
                        infoReader.Read();
                    while (infoReader.Name != "Name");
                    infoReader.Read();
                    string blcokName = infoReader.Value;

                    do
                        infoReader.Read();
                    while (infoReader.Name != "DataTypeName");
                    infoReader.Read();
                    string dataTypeName = infoReader.Value;

                    if (!dataTypeName.Equals("TbBOOLEAN"))
                    {
                        do
                            infoReader.Read();
                        while (infoReader.Name != "IsSigned");
                        infoReader.Read();
                        bool isSigned = Convert.ToBoolean(Int16.Parse(infoReader.Value));

                        do
                            infoReader.Read();
                        while (infoReader.Name != "WordLength");
                        infoReader.Read();
                        int wordLength = Int16.Parse(infoReader.Value);

                        do
                            infoReader.Read();
                        while (infoReader.Name != "FractionLength");
                        infoReader.Read();
                        int fracLength = Int16.Parse(infoReader.Value);

                        do
                            infoReader.Read();
                        while (infoReader.Name != "MinType");
                        infoReader.Read();
                        float minDataType = (float)Double.Parse(infoReader.Value);

                        do
                            infoReader.Read();
                        while (infoReader.Name != "MaxType");
                        infoReader.Read();
                        float maxDataType = (float)Double.Parse(infoReader.Value);

                        parameterDataType = new ParameterDataType(dataTypeName, isSigned, wordLength, fracLength, minDataType, maxDataType);
                    }
                    else
                        parameterDataType = new ParameterDataType(dataTypeName);

                    BlockInfo blockInfo;
                    do
                        infoReader.Read();
                    while (infoReader.Name != "Path");
                    infoReader.Read();
                    string bloackPath = infoReader.Value;

                    do
                        infoReader.Read();
                    while (infoReader.Name != "PortNum");
                    infoReader.Read();
                    int blockPortNum = Int16.Parse(infoReader.Value);

                    infoReader.Read();

                    blockInfo = new BlockInfo(bloackPath, blcokName, blockPortNum);


                    testWorkspace.inputVariables.Add(new TestParameter(blockInfo, parameterDataType));
                }


                if (infoReader.NodeType == XmlNodeType.Element &&
                    infoReader.Name == "Calib")
                {
                    ParameterDataType parameterDataType;

                    do
                        infoReader.Read();
                    while (infoReader.Name != "Name");
                    infoReader.Read();
                    string blcokName = infoReader.Value;

                    do
                        infoReader.Read();
                    while (infoReader.Name != "DataTypeName");
                    infoReader.Read();
                    string dataTypeName = infoReader.Value;

                    if (!dataTypeName.Equals("TbBOOLEAN"))
                    {
                        do
                            infoReader.Read();
                        while (infoReader.Name != "IsSigned");
                        infoReader.Read();
                        bool isSigned = Convert.ToBoolean(Int16.Parse(infoReader.Value));

                        do
                            infoReader.Read();
                        while (infoReader.Name != "WordLength");
                        infoReader.Read();
                        int wordLength = Int16.Parse(infoReader.Value);

                        do
                            infoReader.Read();
                        while (infoReader.Name != "FractionLength");
                        infoReader.Read();
                        int fracLength = Int16.Parse(infoReader.Value);

                        do
                            infoReader.Read();
                        while (infoReader.Name != "MinType");
                        infoReader.Read();
                        float minDataType = (float)Double.Parse(infoReader.Value);

                        do
                            infoReader.Read();
                        while (infoReader.Name != "MaxType");
                        infoReader.Read();
                        float maxDataType = (float)Double.Parse(infoReader.Value);

                        parameterDataType = new ParameterDataType(dataTypeName, isSigned, wordLength, fracLength, minDataType, maxDataType);
                    }
                    else
                        parameterDataType = new ParameterDataType(dataTypeName);

                    BlockInfo blockInfo;
                    do
                        infoReader.Read();
                    while (infoReader.Name != "Path");
                    infoReader.Read();
                    string bloackPath = infoReader.Value;

                    infoReader.Read();

                    blockInfo = new BlockInfo(bloackPath, blcokName);


                    testWorkspace.calibrationVariables.Add(new TestParameter(blockInfo, parameterDataType));
                }


                if (infoReader.NodeType == XmlNodeType.Element &&
                   infoReader.Name == "Output")
                {
                    ParameterDataType parameterDataType;

                    do
                        infoReader.Read();
                    while (infoReader.Name != "Name");
                    infoReader.Read();
                    string blcokName = infoReader.Value;

                    do
                        infoReader.Read();
                    while (infoReader.Name != "DataTypeName");
                    infoReader.Read();
                    string dataTypeName = infoReader.Value;

                    if (!dataTypeName.Equals("TbBOOLEAN"))
                    {
                        do
                            infoReader.Read();
                        while (infoReader.Name != "IsSigned");
                        infoReader.Read();
                        bool isSigned = Convert.ToBoolean(Int16.Parse(infoReader.Value));

                        do
                            infoReader.Read();
                        while (infoReader.Name != "WordLength");
                        infoReader.Read();
                        int wordLength = Int16.Parse(infoReader.Value);

                        do
                            infoReader.Read();
                        while (infoReader.Name != "FractionLength");
                        infoReader.Read();
                        int fracLength = Int16.Parse(infoReader.Value);

                        do
                            infoReader.Read();
                        while (infoReader.Name != "MinType");
                        infoReader.Read();
                        float minDataType = (float)Double.Parse(infoReader.Value);

                        do
                            infoReader.Read();
                        while (infoReader.Name != "MaxType");
                        infoReader.Read();
                        float maxDataType = (float)Double.Parse(infoReader.Value);

                        parameterDataType = new ParameterDataType(dataTypeName, isSigned, wordLength, fracLength, minDataType, maxDataType);
                    }
                    else
                        parameterDataType = new ParameterDataType(dataTypeName);

                    BlockInfo blockInfo;
                    do
                        infoReader.Read();
                    while (infoReader.Name != "Path");
                    infoReader.Read();
                    string bloackPath = infoReader.Value;

                    do
                        infoReader.Read();
                    while (infoReader.Name != "PortNum");
                    infoReader.Read();
                    int blockPortNum = Int16.Parse(infoReader.Value);

                    infoReader.Read();

                    blockInfo = new BlockInfo(bloackPath, blcokName, blockPortNum);


                    testWorkspace.outputVariables.Add(new TestParameter(blockInfo, parameterDataType));
                }

            }
            infoReader.Close();
            return;
        }
    }
}
