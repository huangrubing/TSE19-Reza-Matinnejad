function []=Fn_WriteSLDVTestSuiteCoverage(NoMutants,filesdirectory,DMUT,SLDVTestSuitesCov,CovMode)
 
  fSLDVTestSuitesCov=fopen(sprintf('%s/sldvtestsuitecov_%s.txt',filesdirectory,CovMode),'wt');
  for m=1:NoMutants,
    fprintf(fSLDVTestSuitesCov,'%s %d\n',DMUT(m).name,SLDVTestSuitesCov(m));   
  end
  fclose(fSLDVTestSuitesCov);
end