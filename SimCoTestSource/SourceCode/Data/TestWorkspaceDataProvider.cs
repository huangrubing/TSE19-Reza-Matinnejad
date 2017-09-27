using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MiLTester.SourceCode.Bussiness.Workspace;
using System.Xml;
using MiLTester.SourceCode.Bussiness.Workspace.Parameters;
using MiLTester.SourceCode.Service;
using MiLTester.SourceCode.Bussiness.Output.HeatMap;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabRuns;
using System.Text.RegularExpressions;
using MiLTester.SourceCode.Bussiness.Workspace.TestCases;
using MiLTester.SourceCode.Common;

namespace MiLTester.SourceCode.Data
{
    public class TestWorkspaceDataProvider
    {
        private string workspacesDirectory;
        private ITestWorkspaceAddRemoveListener testWorkspaceAddRemoveListener;
        private static TestWorkspaceDataProvider testWorkspaceDataProvider = null;
        
        public static TestWorkspaceDataProvider GetTestWorkspaceDataProvider()
        {
            return testWorkspaceDataProvider;
        }

        public static TestWorkspaceDataProvider CreateTestWorkspaceDataProvider(string workspacesDirectory,
            ITestWorkspaceAddRemoveListener testWorkspaceAddRemoveListener)
        {
            TestWorkspaceDataProvider.testWorkspaceDataProvider = new TestWorkspaceDataProvider(workspacesDirectory, testWorkspaceAddRemoveListener);
            return TestWorkspaceDataProvider.testWorkspaceDataProvider;
        }

        public TestWorkspaceDataProvider(string workspacesDirectory, 
            ITestWorkspaceAddRemoveListener testWorkspaceAddRemoveListener)
        {
            this.workspacesDirectory = workspacesDirectory;
            this.testWorkspaceAddRemoveListener = testWorkspaceAddRemoveListener;
        }

        public void DeleteTestWorkspace(TestWorkspace testWorkspace)
        {
            string testWorkspacePath = GetWorkspacePath(testWorkspace.ToString());
            Directory.Delete(testWorkspacePath, true);
            
            testWorkspaceAddRemoveListener.TestWorkspaceRemoved(testWorkspace);
        }

        public void ExportTestWorkspace(TestWorkspace testWorkspace,string targetDirectory)
        {
            string testWorkspacePath = GetWorkspacePath(testWorkspace.ToString());
            string targetWorkspacePath = targetDirectory + "\\" + testWorkspace.ToString() + "\\";
            Directory.CreateDirectory(targetWorkspacePath);
            UtilityClass.CopyDirectory(testWorkspacePath, targetWorkspacePath);
        }

        public ErrorResult ImportTestWorkspace(string sourceDirectory)
        {
            ErrorResult errorResult = new ErrorResult();
            string workspacesPath = GetWorkspacesPath();
            int startIndexOfDirectoryName = sourceDirectory.LastIndexOf('\\');
            string directoryName = sourceDirectory.Substring(startIndexOfDirectoryName + 1);
            if (Directory.Exists(workspacesPath + directoryName))
            {
                errorResult.errorCode = ErrorCode.DupicateWorkspaceName; 
                return errorResult;
            }
            Directory.CreateDirectory(workspacesPath + directoryName);
            UtilityClass.CopyDirectory(sourceDirectory + "\\", workspacesPath + directoryName + "\\");
            testWorkspaceAddRemoveListener.TestWorkspaceAdded(LoadTestWorkspace(directoryName));
            errorResult.errorCode = ErrorCode.Success;
            return errorResult;
        }

        public void RenameTestWorkspace(TestWorkspace testWorkspace,string newTestWorkspaceName)
        {
            string testWorkspacePath = GetWorkspacePath(testWorkspace.ToString());
            string testWorkspaceNewPath = GetWorkspacePath(newTestWorkspaceName);
            Directory.Move(testWorkspacePath, testWorkspaceNewPath);
            testWorkspaceAddRemoveListener.TestWorkspaceRenamed(testWorkspace, newTestWorkspaceName);
            testWorkspace.Rename(newTestWorkspaceName);
        }

        public bool IsTestWorkspacePath(string workpsacePath)
        {
            if(!File.Exists(workpsacePath + "\\" + "ModelSettings.xml"))
                return false;
            if (!Directory.Exists(workpsacePath + "\\" + "Results"))
                return false;
            return true;
        }

        public bool IsWorkspaceNameUnique(string workpsaceName)
        {
            List<string> workspaceNames = GetTestWorkspaceList();
            if (workspaceNames.Contains(workpsaceName))
                return false;
            return true;

        }

        public List<string> GetTestWorkspaceList()
        {
            List<string> workspaceList=new List<string>();
            string workspacesPath = GetWorkspacesPath();
            if (!Directory.Exists(workspacesPath))
                return workspaceList;
            string[] workspacesListString = Directory.GetDirectories(workspacesPath);
            for (int i=0;i<workspacesListString.Count();++i)
            {
                int startIndexOfFileName = workspacesListString[i].LastIndexOf('\\');
                workspacesListString[i] = workspacesListString[i].Substring(startIndexOfFileName + 1);
                workspaceList.Add(workspacesListString[i]);
            }
            return workspaceList;
        }
        
        public TestWorkspace LoadTestWorkspace(string testWorkspaceName)
        {
            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.ValidationType = ValidationType.None;

            XmlReader workspaceReader = XmlReader.Create(
                GetWorkspaceInfoFilePath(testWorkspaceName), xmlSettings);
            FunctionTypeEnum functionType = FunctionTypeEnum.Continuous_Controller;
            TestWorkspace testWorkspace = null;
            while (workspaceReader.Read())
            {
                if (workspaceReader.NodeType == XmlNodeType.Element &&
                    workspaceReader.Name == "FunctionType")
                {
                    workspaceReader.Read();
                    functionType = 
                        (FunctionTypeEnum)Enum.Parse(typeof(FunctionTypeEnum), workspaceReader.Value, true);
                    switch (functionType)
                    {
                        case FunctionTypeEnum.Continuous_Controller:
                            testWorkspace = new CCTestWorkspace(testWorkspaceName);
                            break;
                        case FunctionTypeEnum.State_Based_Controller:
                            testWorkspace = new SLTestWorkspace(testWorkspaceName);
                            break;
                        case FunctionTypeEnum.Input_Output:
                            testWorkspace = new IOTestWorkspace(testWorkspaceName);
                            break;
                    }
                    workspaceReader.Read();
                }
                if (workspaceReader.NodeType == XmlNodeType.Element &&
                    workspaceReader.Name == "SimulationTime")
                {
                    workspaceReader.Read();
                    testWorkspace.SetSimulationTime(Int16.Parse(workspaceReader.Value));
                    workspaceReader.Read();
                }
                if (workspaceReader.NodeType == XmlNodeType.Element &&
                    workspaceReader.Name == "ModelRunningTime")
                {
                    workspaceReader.Read();
                    testWorkspace.SetModelRunningTime(Int16.Parse(workspaceReader.Value));
                    workspaceReader.Read();
                }
            }
            workspaceReader.Close();
            switch (testWorkspace.functionType)
            {
                case FunctionTypeEnum.Continuous_Controller:
                    testWorkspace.modelSettings = SettingFilesManager.LoadModelSettings(
                        GetWorkspacePath(testWorkspaceName));
                    LoadCCTestWorkspace((CCTestWorkspace)testWorkspace);
                    break;
                case FunctionTypeEnum.State_Based_Controller:
                    testWorkspace.modelSettings = SettingFilesManager.LoadModelSettings(
                        GetWorkspacePath(testWorkspaceName));
                    LoadSBTestWorkspace((SLTestWorkspace)testWorkspace);
                    break;
                case FunctionTypeEnum.Input_Output:
                    break;
            }
            return testWorkspace;
        }


        private void LoadSBTestWorkspace(SLTestWorkspace sbTestWorkspace)
        {
            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.ValidationType = ValidationType.None;
            string testWorkspaceName = sbTestWorkspace.ToString();
            sbTestWorkspace.slSettings = SettingFilesManager.LoadSBSettings(
                GetWorkspacePath(testWorkspaceName));
            sbTestWorkspace.advancedSBSettings = SettingFilesManager.LoadAdvancedSBSettings(
                GetWorkspacePath(testWorkspaceName));
            XmlReader workspaceReader = XmlReader.Create(
                GetWorkspaceInfoFilePath(testWorkspaceName), xmlSettings);
            while (workspaceReader.Read())
            {
                if (workspaceReader.NodeType == XmlNodeType.Element &&
                    workspaceReader.Name == "Parameter")
                {
                    do
                        workspaceReader.Read();
                    while (workspaceReader.Name != "Name");
                    workspaceReader.Read();
                    string paremeterName = workspaceReader.Value;
                    do
                        workspaceReader.Read();
                    while (workspaceReader.Name != "Type");
                    workspaceReader.Read();
                    ParameteresType paremeterType =
                        (ParameteresType)Enum.Parse(typeof(ParameteresType), workspaceReader.Value, true);
                    do
                        workspaceReader.Read();
                    while (workspaceReader.Name != "From");
                    workspaceReader.Read();
                    float from = float.Parse(workspaceReader.Value);

                    do
                        workspaceReader.Read();
                    while (workspaceReader.Name != "To");
                    workspaceReader.Read();
                    float to = float.Parse(workspaceReader.Value);
                    float valueForTest = 0;
                    if (paremeterType != ParameteresType.OutputVariable)
                    {
                        do
                            workspaceReader.Read();
                        while (workspaceReader.Name != "ValueForTest");
                        workspaceReader.Read();
                        valueForTest = float.Parse(workspaceReader.Value);
                    }
                    string dataType="";
                    do
                        workspaceReader.Read();
                    while (workspaceReader.Name != "DataType");
                    workspaceReader.Read();
                    dataType = workspaceReader.Value;
                    if (paremeterType == ParameteresType.InputVariable)
                        sbTestWorkspace.AddInputVariable(new TestParameter(paremeterName,
                            paremeterType, from, to, valueForTest, dataType));
                    else if (paremeterType == ParameteresType.CalibrationVariable)
                        sbTestWorkspace.AddCalibrationVariable(new TestParameter(paremeterName,
                            paremeterType, from, to, valueForTest, dataType));
                    else if (paremeterType == ParameteresType.OutputVariable)
                        sbTestWorkspace.outputVariable=new TestParameter(paremeterName,
                            paremeterType, from, to, dataType);
                    workspaceReader.Read();
                }
            }
            workspaceReader.Close();
            return;
        }


        private void LoadCCTestWorkspace(CCTestWorkspace ccTestWorkspace)
        {
            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.ValidationType = ValidationType.None;
            string testWorkspaceName = ccTestWorkspace.ToString();
            ccTestWorkspace.ccSettings = SettingFilesManager.LoadCCSettings(
                GetWorkspacePath(testWorkspaceName));
            ccTestWorkspace.advancedCCSettings = SettingFilesManager.LoadAdvancedCCSettings(
                GetWorkspacePath(testWorkspaceName));
            XmlReader workspaceReader = XmlReader.Create(
                GetWorkspaceInfoFilePath(testWorkspaceName), xmlSettings);
            while (workspaceReader.Read())
            {
                if (workspaceReader.NodeType == XmlNodeType.Element &&
                    workspaceReader.Name == "Parameter")
                {
                    do
                        workspaceReader.Read();
                    while (workspaceReader.Name != "Name");
                    workspaceReader.Read();
                    string paremeterName = workspaceReader.Value;
                    do
                        workspaceReader.Read();
                    while (workspaceReader.Name != "Type");
                    workspaceReader.Read();
                    ParameteresType paremeterType = 
                        (ParameteresType)Enum.Parse(typeof(ParameteresType), workspaceReader.Value, true);
                    do
                        workspaceReader.Read();
                    while (workspaceReader.Name != "From");
                    workspaceReader.Read();
                    float from = float.Parse(workspaceReader.Value);
                    
                    do
                        workspaceReader.Read();
                    while (workspaceReader.Name != "To");
                    workspaceReader.Read();
                    float to = float.Parse(workspaceReader.Value);

                    do
                        workspaceReader.Read();
                    while (workspaceReader.Name != "ValueForTest");
                    workspaceReader.Read();
                    float valueForTest = float.Parse(workspaceReader.Value);
                    
                    if(paremeterType==ParameteresType.DesiredVariable)
                        ccTestWorkspace.SetDesiredValueVariable(new TestParameter(paremeterName,
                            paremeterType, from, to));
                    else if(paremeterType==ParameteresType.ActualVariable)
                        ccTestWorkspace.SetActualValueVariable(new TestParameter(paremeterName,
                            paremeterType, from, to));
                    else if (paremeterType == ParameteresType.CalibrationVariable)
                        ccTestWorkspace.AddCalibrationVariable(new TestParameter(paremeterName,
                            paremeterType, from, to, valueForTest));
                    workspaceReader.Read();
                }
            }
            workspaceReader.Close();
            return;
        }


        private void SaveCCTestWorkspaceData(CCTestWorkspace cctestWorkspace, XmlWriter xmlTestWorkspaceWriter)
        {
            foreach (TestParameter ccTestParameter in cctestWorkspace.GetAllCCTestParameteres())
            {
                xmlTestWorkspaceWriter.WriteStartElement("Parameter");
                xmlTestWorkspaceWriter.WriteStartElement("Name");
                xmlTestWorkspaceWriter.WriteValue(ccTestParameter.parameterName);
                xmlTestWorkspaceWriter.WriteEndElement();
                xmlTestWorkspaceWriter.WriteStartElement("Type");
                xmlTestWorkspaceWriter.WriteValue(ccTestParameter.parameteresType.ToString());
                xmlTestWorkspaceWriter.WriteEndElement();
                xmlTestWorkspaceWriter.WriteStartElement("From");
                xmlTestWorkspaceWriter.WriteValue(ccTestParameter.from);
                xmlTestWorkspaceWriter.WriteEndElement();
                xmlTestWorkspaceWriter.WriteStartElement("To");
                xmlTestWorkspaceWriter.WriteValue(ccTestParameter.to);
                xmlTestWorkspaceWriter.WriteEndElement();
                xmlTestWorkspaceWriter.WriteStartElement("ValueForTest");
                xmlTestWorkspaceWriter.WriteValue(ccTestParameter.valueForTest);
                xmlTestWorkspaceWriter.WriteEndElement();
                xmlTestWorkspaceWriter.WriteEndElement();
            }
            return;
        }

        public void SaveInfoExtractionResultsToTestWorkspace(string testWorkspaceName, string directoryPath)
        {
            /*string workspaceResultsPath = GetWorkspaceResultsPath(testWorkspaceName);
            if (!Directory.Exists(workspaceResultsPath))
                Directory.CreateDirectory(workspaceResultsPath);
            int startIndexOfFileName = directoryPath.LastIndexOf('\\');
            string directoryName = directoryPath.Substring(startIndexOfFileName + 1);
            Directory.Move(directoryPath, workspaceResultsPath + directoryName);*/
        }

        public void SaveSearchResultsToTestWorkspace(string testWorkspaceName, string directoryPath)
        {
            string workspaceResultsPath = GetWorkspaceResultsPath(testWorkspaceName);
            if (!Directory.Exists(workspaceResultsPath))
            Directory.CreateDirectory(workspaceResultsPath);
            int startIndexOfFileName = directoryPath.LastIndexOf('\\');
            string directoryName = directoryPath.Substring(startIndexOfFileName + 1);
            Directory.Move(directoryPath, workspaceResultsPath + directoryName);
        }


        public Dictionary<string, Dictionary<string, List<SLTestCase>>> LoadTestSuitesToSLTestWorkspace(string testWorkspaceName)
        {
            Dictionary<string, Dictionary<string, List<SLTestCase>>> testSuites =
                new Dictionary<string, Dictionary<string, List<SLTestCase>>>();
            string workspaceResultsPath = GetWorkspaceResultsPath(testWorkspaceName);
            if (!Directory.Exists(workspaceResultsPath))
                return testSuites;
            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.ValidationType = ValidationType.None;
            
            List<string> criteriaDirectories = new List<string>(Directory.EnumerateDirectories(workspaceResultsPath));
            foreach (string criterionDirectory in criteriaDirectories)
            {
                int startIndexOfCriDirName = criterionDirectory.LastIndexOf('\\');
                string criterionDirectoryName = criterionDirectory.Substring(startIndexOfCriDirName + 1);
                
                Dictionary<string, List<SLTestCase>> criterionTestSuites=new Dictionary<string, List<SLTestCase>>();
                List<string> outputDirectories = new List<string>(Directory.EnumerateDirectories(criterionDirectory));
                
                foreach (string outputDirectory in outputDirectories)
                {

                    int startIndexOfOutDirName = outputDirectory.LastIndexOf('\\');
                    string outptuDirectoryName = outputDirectory.Substring(startIndexOfOutDirName + 1);

                    List<SLTestCase> outputTestCases=new List<SLTestCase>();
                    string testSuiteFilePath = outputDirectory + "\\TestSuite.xml";
                    if (!File.Exists(testSuiteFilePath))
                        continue;
                    XmlReader workspaceReader = XmlReader.Create(
                        testSuiteFilePath, xmlSettings);
                    while (workspaceReader.Read())
                    {
                        if (workspaceReader.NodeType == XmlNodeType.Element &&
                            workspaceReader.Name == "TestCase")
                        {
                            SLTestCase slTestCase = new SLTestCase();
                            string varName,varType;
                            while (workspaceReader.Read())
                            {
                                if (workspaceReader.NodeType == XmlNodeType.Element &&
                                    workspaceReader.Name == "Input")
                                {
                                    do
                                        workspaceReader.Read();
                                    while (workspaceReader.Name != "VarName");
                                    workspaceReader.Read();
                                    varName = workspaceReader.Value;
                                    do
                                        workspaceReader.Read();
                                    while (workspaceReader.Name != "Type");
                                    workspaceReader.Read();
                                    varType = workspaceReader.Value;

                                    if (varType.Equals("Input"))
                                    {
                                        do
                                            workspaceReader.Read();
                                        while (workspaceReader.Name != "NoSegments");
                                        workspaceReader.Read();
                                        int noSegs = Int16.Parse(workspaceReader.Value);
                                        SLSignal slSignal = new SLSignal();
                                        for (int i = 0; i <= noSegs; ++i)
                                        {
                                            do
                                                workspaceReader.Read();
                                            while (workspaceReader.Name != "StepTime");
                                            workspaceReader.Read();
                                            float stepTime=float.Parse(workspaceReader.Value);
                                            slSignal.signalStepTimes.Add(stepTime);

                                            do
                                                workspaceReader.Read();
                                            while (workspaceReader.Name != "Value");
                                            workspaceReader.Read();
                                            float sigValue=float.Parse(workspaceReader.Value);

                                            slSignal.signalValues.Add(sigValue);
                                        }
                                        slTestCase.inputSignals.Add(varName,slSignal);
                                    }
                                    else if (varType.Equals("Calibration"))
                                    {
                                        do
                                            workspaceReader.Read();
                                        while (workspaceReader.Name != "Value");
                                        workspaceReader.Read();
                                        slTestCase.calibrationVars.Add(varName, float.Parse(workspaceReader.Value));
                                    }
                                }
                                else if (workspaceReader.NodeType == XmlNodeType.EndElement &&
                                    workspaceReader.Name == "TestCase")
                                {
                                    outputTestCases.Add(slTestCase);
                                    break;
                                }
                            }
                        }
                        
                    }
                    criterionTestSuites.Add(outptuDirectoryName, outputTestCases);
                }
                testSuites.Add(criterionDirectoryName, criterionTestSuites);
            }
            return testSuites;
        }

        public Dictionary<string,List<CCTestCase>> LoadWorstTestCasesToCCTestWorkspace(string testWorkspaceName)
        {
            Dictionary<string, List<CCTestCase>> worstTestCases = new Dictionary<string, List<CCTestCase>>();
            string singleStateSearchResultsPath = GetWorkspaceSingleStateSearchResultsPath(testWorkspaceName);
            if(!Directory.Exists(singleStateSearchResultsPath))
                return worstTestCases;
            List<string> requirementDirectories = new List<string>(Directory.EnumerateDirectories(singleStateSearchResultsPath));
            foreach (string requirementDirectory in requirementDirectories)
            {
                int startIndexOfFileName = requirementDirectory.LastIndexOf('\\');
                string requirementDirectoryName = requirementDirectory.Substring(startIndexOfFileName + 1);
                worstTestCases.Add(requirementDirectoryName, new List<CCTestCase>());
                List<string> regionsDirectories = new List<string>(Directory.EnumerateDirectories(requirementDirectory));
                foreach (string regionsDirectory in regionsDirectories)
                {
                    string worstTestCasesFilePath = regionsDirectory + "\\WorstCaseScenarioInTheRegion.csv";
                    if (!File.Exists(worstTestCasesFilePath))
                        continue;
                    string[] worstTestCasesFileLines = System.IO.File.ReadAllLines(worstTestCasesFilePath);
                    MatchCollection wordMatches = Regex.Matches(worstTestCasesFileLines[0], @"[^,]+");
                    if (wordMatches.Count != 4)
                        continue;
                    MatchCollection valueMatches = Regex.Matches(worstTestCasesFileLines[1], @"[^,]+");
                    if (valueMatches.Count != 4)
                        continue;
                    HeatMapRegion heatMapRegion = new HeatMapRegion();
                    heatMapRegion.indexX = Int16.Parse(valueMatches[0].Value);
                    heatMapRegion.indexY = Int16.Parse(valueMatches[1].Value);
                    CCTestCase ccTestCase = new CCTestCase();
                    ccTestCase.initialDesired = float.Parse(valueMatches[2].Value);
                    ccTestCase.finalDesired = float.Parse(valueMatches[3].Value);
                    ccTestCase.heatMapRegion = heatMapRegion;
                    worstTestCases[requirementDirectoryName].Add(ccTestCase);
                }
            }
            return worstTestCases;
        }

        public HeatMap LoadHeatMapDiagramToTestWorkspace(string testWorkspaceName)
        {
            string workspaceResultsPath = GetWorkspaceRandomExplorationResultsPath(testWorkspaceName);
            string heatMapDiagramsFilePath = workspaceResultsPath + RandomExplorationRun.heatMapDiagramsFileName;
            if (!File.Exists(heatMapDiagramsFilePath))
                return null;
            string[] heatMapDiagramsFileLines = System.IO.File.ReadAllLines(heatMapDiagramsFilePath);
            MatchCollection wordMatches = Regex.Matches(heatMapDiagramsFileLines[0], @"[^,]+");
            if (wordMatches.Count != (4+5))
                return null;
            string[] objectiveFunctionsName = new string[5];
            for(int i=0;i<5;++i)
                objectiveFunctionsName[i] = wordMatches[i+4].Value;
            HeatMap heatMap = new HeatMap();
            for (int l = 1; l < heatMapDiagramsFileLines.Count(); ++l)
            {
                MatchCollection valueMatches = Regex.Matches(heatMapDiagramsFileLines[l], @"[^,]+");
                if (valueMatches.Count != (4 + 5))
                    return null;
                HeatMapPoint heatMapPoint = new HeatMapPoint();
                heatMapPoint.indexX = Int16.Parse(valueMatches[0].Value);
                heatMapPoint.indexY = Int16.Parse(valueMatches[1].Value);
                heatMapPoint.x = float.Parse(valueMatches[2].Value);
                heatMapPoint.y = float.Parse(valueMatches[3].Value);
                for (int i = 4; i < valueMatches.Count; ++i)
                    heatMapPoint.objectiveFunctionValues.Add(objectiveFunctionsName[i-4], 
                        float.Parse(valueMatches[i].Value));
                heatMap.AddPoint(heatMapPoint);
            }
            heatMap.FinalizeAddingPoints();
            return heatMap;
        }
        
        public List<HeatMapRegion> LoadHeatMapRegionsToTestWorkspace(string testWorkspaceName)
        {
            List<HeatMapRegion> heatMapRegions=new List<HeatMapRegion>();
            string workspaceResultsPath = GetWorkspaceRandomExplorationResultsPath(testWorkspaceName);
            string heatMapRegionsFilePath = workspaceResultsPath + RandomExplorationRun.heatMapRegionsFileName;
            if (!File.Exists(heatMapRegionsFilePath))
                return null;
            string[] heatMapRegionsFileLines = System.IO.File.ReadAllLines(heatMapRegionsFilePath);
            MatchCollection wordMatches = Regex.Matches(heatMapRegionsFileLines[0], @"[^,]+");
            if (wordMatches.Count != (6 + 3*5))
                return null;
            string[] objectiveFunctionsName = new string[5];
            for (int i = 0; i < 5; ++i)
                objectiveFunctionsName[i] = wordMatches[6+i*3].Value;
            HeatMap heatMap = new HeatMap();
            for (int l = 1; l < heatMapRegionsFileLines.Count(); ++l)
            {
                MatchCollection valueMatches = Regex.Matches(heatMapRegionsFileLines[l], @"[^,]+");
                if (valueMatches.Count != (6 + 3*5))
                    return null;
                for (int i = 0; i < 5; ++i)
                {
                    HeatMapRegion heatMapRegion = new HeatMapRegion();
                    heatMapRegion.indexX = Int16.Parse(valueMatches[0].Value);
                    heatMapRegion.indexY = Int16.Parse(valueMatches[1].Value);
                    heatMapRegion.xStart = float.Parse(valueMatches[2].Value);
                    heatMapRegion.xEnd = float.Parse(valueMatches[3].Value);
                    heatMapRegion.yStart = float.Parse(valueMatches[4].Value);
                    heatMapRegion.yEnd = float.Parse(valueMatches[5].Value);
                    heatMapRegion.requirementName=objectiveFunctionsName[i];
                    HeatMapPoint heatMapPoint = new HeatMapPoint();
                    heatMapPoint.objectiveFunctionValues[heatMapRegion.requirementName] = 
                        float.Parse(valueMatches[6 + i * 3].Value);
                    heatMapPoint.x = float.Parse(valueMatches[7 + i * 3].Value);
                    heatMapPoint.y = float.Parse(valueMatches[8 + i * 3].Value);
                    heatMapRegion.worstCasePointFromRandomExploration = heatMapPoint;
                    heatMapRegion.objectiveFunctionAverageValue = heatMapPoint.objectiveFunctionValues[heatMapRegion.requirementName];
                    heatMapRegions.Add(heatMapRegion);
                }
            }
            return heatMapRegions;
        }


        public void SaveTestWorkspace(TestWorkspace testWorkspace)
        {
            string testWorkspaceName = testWorkspace.ToString();
            string testWorkspacePath = GetWorkspacePath(testWorkspaceName);
            /////////////////////////////////////////////////////
            if (!Directory.Exists(testWorkspacePath))
                Directory.CreateDirectory(testWorkspacePath);
            SettingFilesManager.SaveModelSettings(testWorkspacePath,testWorkspace.modelSettings);
            SaveTestWorkspaceData(testWorkspace);
            testWorkspaceAddRemoveListener.TestWorkspaceAdded(testWorkspace);
        }

        private void SaveTestWorkspaceData(TestWorkspace testWorkspace)
        {
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            string workspaceName = testWorkspace.ToString();
            XmlWriter xmlTestWorkspaceWriter = XmlWriter.Create(
                GetWorkspaceInfoFilePath(workspaceName), xmlSettings);
            //-------------------------------------------------------------------
            xmlTestWorkspaceWriter.WriteStartElement("body");
            
            xmlTestWorkspaceWriter.WriteStartElement("FunctionType");
            xmlTestWorkspaceWriter.WriteValue(testWorkspace.functionType.ToString());
            xmlTestWorkspaceWriter.WriteEndElement();

            xmlTestWorkspaceWriter.WriteStartElement("SimulationTime");
            xmlTestWorkspaceWriter.WriteValue(testWorkspace.GetSimulationTime());
            xmlTestWorkspaceWriter.WriteEndElement();

            xmlTestWorkspaceWriter.WriteStartElement("ModelRunningTime");
            xmlTestWorkspaceWriter.WriteValue(testWorkspace.GetModelRunningTime());
            xmlTestWorkspaceWriter.WriteEndElement();
            
            switch (testWorkspace.functionType)
            {
                case FunctionTypeEnum.Continuous_Controller:
                    SaveCCTestWorkspaceData((CCTestWorkspace)testWorkspace,
                        xmlTestWorkspaceWriter);
                    SettingFilesManager.SaveCCSettings(GetWorkspacePath(workspaceName), 
                        ((CCTestWorkspace)testWorkspace).ccSettings);
                    SettingFilesManager.SaveAdvancedCCSettings(GetWorkspacePath(workspaceName), 
                        ((CCTestWorkspace)testWorkspace).advancedCCSettings);
                    break;
                case FunctionTypeEnum.State_Based_Controller:
                    break;
                case FunctionTypeEnum.Input_Output:
                    break;
            }

            xmlTestWorkspaceWriter.WriteEndElement();
            xmlTestWorkspaceWriter.Close();
            return;
        }


        private string GetWorkspacesPath()
        {
            return workspacesDirectory;
        }

        private string GetWorkspacePath(string testWorkspaceName)
        {
            return GetWorkspacesPath() + testWorkspaceName + "\\";
        }

        
        public string GetWorkspaceResultsPath(string testWorkspaceName)
        {
            return GetWorkspacePath(testWorkspaceName) + "Results\\";
        }


        private string GetWorkspaceRandomExplorationResultsPath(string testWorkspaceName)
        {
            return GetWorkspaceResultsPath(testWorkspaceName) + "RandomExploration\\";
        }

        private string GetWorkspaceSingleStateSearchResultsPath(string testWorkspaceName)
        {
            return GetWorkspaceResultsPath(testWorkspaceName) + "SingleStateSearch\\";
        }
        
        private string GetWorkspaceInfoFilePath(string testWorkspaceName)
        {
            return GetWorkspacePath(testWorkspaceName) + "WorkspaceInfo.xml";
        }
    }
}
