function []=Fn_WriteTestSuiteComplexity(NoMutants,NoInputVars,filesdirectory,DMUT,InputNamesVar,TestSuiteSizes,TestSuiteComplexity,CovMode)
 
  fTestSuiteComplexity=fopen(sprintf('%s/testsuitecomplexity_%s.txt',filesdirectory,CovMode),'wt');
  for m=1:NoMutants,
    for tccnt=1:TestSuiteSizes(m),
      for icnt=1:NoInputVars,
       fprintf(fTestSuiteComplexity,'%s %d %s %d\n',DMUT(m).name,tccnt,InputNamesVar{icnt},TestSuiteComplexity(m,tccnt,icnt));   
      end
    end
  end
  fclose(fTestSuiteComplexity);
end