
diary('[MiLTester_CodeRootVal]\Temp\output.log');
try
  addpath('[MiLTester_CodeRootVal]\Functions\ObjectiveFunctions');
  addpath('[MiLTester_CodeRootVal]\Functions\OtherFunctions');
  addpath('[MiLTester_CodeRootVal]\Functions\Common')
  wsstr=who; 
  if(length(wsstr)<=0)
	run('SC_MiLTester_ModelSettingsScript');
  end
  cd \;
  open_system('[MiLTester_SimulinkModelPathVal]');
  %Fn_MiLTester_SetSimulationTime([MiLTester_SimulationTimeVal]); 
  Fn_ExecuteATestCaseFromXML('[MiLTester_ModelComltName]','[MiLTester_FilesDirectory]','[MiLTester_TestSuiteFilepath]',[MiLTester_DsrdTCNo],[MiLTester_DsrdOutNo],[MiLTester_SimulationTimeVal],[MiLTester_SimulationStepTimesVal]);
 catch exc
  display(getReport(exc));
  display('Error in model test run!');
end
diary off;