function [TestSuiteComplexity]=Fn_ReadTestSuiteComplexity(filesdirectory,NoMutants,NoInputVars,TestSuiteSizes,CovMode)

  if(exist(sprintf('%s/%s',filesdirectory,sprintf('testsuitecomplexity_%s.txt',CovMode)),'file'))
    ftestsuitecomplexity=fopen(sprintf('%s/%s',filesdirectory,sprintf('testsuitecomplexity_%s.txt',CovMode)),'rt');
    cnt=1;
    nextline=fgetl(ftestsuitecomplexity);
    while(ischar(nextline))
      nextline=textscan(nextline,'%s');
      varcnt=1;
      MutModelNames{cnt}=nextline{1}{varcnt};   
      varcnt=varcnt+1;
      TestCaseNumber{cnt}=nextline{1}{varcnt};  
      varcnt=varcnt+1;
      InuputSigNames{cnt}=nextline{1}{varcnt};  
      varcnt=varcnt+1;
      TestSuiteComplexityVar{cnt}=str2double(nextline{1}{varcnt});
      nextline=fgetl(ftestsuitecomplexity);
      cnt=cnt+1;
    end
    fclose(ftestsuitecomplexity); 
  end
  TestSuiteComplexity=ones(NoMutants,max(TestSuiteSizes),NoInputVars);  
  cnt=1;
  if(exist('TestSuiteComplexityVar','var'))
    for m=1:NoMutants,
      for tccnt=1:TestSuiteSizes(m,1),
        for icnt=1:NoInputVars,
          TestSuiteComplexity(m,tccnt,icnt)=TestSuiteComplexityVar{cnt};
          cnt=cnt+1;
        end
      end
    end
  end
end