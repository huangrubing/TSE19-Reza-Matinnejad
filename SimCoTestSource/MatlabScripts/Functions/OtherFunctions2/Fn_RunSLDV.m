function [testsuite]=Fn_RunSLDV(modelpath,modelname,timeout,covobjective)
%covobjective 'D' 'MCDC'

  opts = sldvoptions;
  opts.Mode = 'TestGeneration';
  if(strcmp(covobjective,'D'))
      opts.ModelCoverageObjectives = 'D';
  else
      opts.ModelCoverageObjectives = 'MCDC';
  end
  opts.SaveHarnessModel = 'off';
  opts.SaveReport = 'off';
  opts.DisplayReport = 'off';
  opts.DisplayReport = 'off';
  opts.MaxProcessTime = timeout;
  opts.TestSuiteOptimization='CombinedObjectives';
  load_system(modelname);
  Fn_MiLTester_DisableSimulationExternalInput();
  save_system(modelname,sprintf('%s/SLDV/%s_sldv.mdl',modelpath,strrep(modelname,'.mdl','')));
  %load_system(sprintf('%s/SLDV/%s_sldv.mdl',modelpath,strrep(modelname,'.mdl','')));
  [status,files] = sldvrun(sprintf('%s_sldv',strrep(modelname,'.mdl','')), opts);
  close_system(sprintf('%s_sldv.mdl',strrep(modelname,'.mdl','')));
  load_system(modelname);
  load(files.DataFile);
  testsuite=sldvData;
end