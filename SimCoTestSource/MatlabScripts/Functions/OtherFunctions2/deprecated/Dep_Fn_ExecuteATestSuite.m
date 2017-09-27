function [TestSuiteDist,TestSuiteOutput]=Dep_Fn_ExecuteATestSuite(orgmodelname,mutModelName,InputTypesVar,NoSteps,NoOutputs,testsuite,SimTime,SimStep,MaxDist,OutputIndex)

  NoTestCases=size(testsuite.TestCases,2);
  if(exist('OutputIndex','var'))
    TestSuiteDist=0;
    TestSuiteOutput=zeros(NoTestCases,NoSteps+1);
  else
    TestSuiteDist=zeros(NoOutputs,1);
    TestSuiteOutput=zeros(NoTestCases,NoOutputs,NoSteps+1);
  end
  for tccnt=1:NoTestCases,
    Output=Fn_ExecuteATestCase(orgmodelname,testsuite.TestCases(tccnt),InputTypesVar,'externalinputdata','yout',SimTime,SimStep);
    MOutput=Fn_ExecuteATestCase(mutModelName,testsuite.TestCases(tccnt),InputTypesVar,'externalinputdata','yout',SimTime,SimStep);
    if(exist('OutputIndex','var'))  
      TestSuiteOutput(tccnt,:)=MOutput(OutputIndex,:);
      TestCaseDist=norm(MOutput(OutputIndex,:)-Output(OutputIndex,:))/MaxDist(OutputIndex);
      if(TestCaseDist>TestSuiteDist)
        TestSuiteDist=TestCaseDist;
      end
    else      
      TestSuiteOutput(tccnt,:,:)=MOutput(:,:);
      for ocnt=1:NoOutputs,
        TestCaseDist=norm(MOutput(ocnt,:)-Output(ocnt,:))/MaxDist(ocnt);
        if(TestCaseDist>TestSuiteDist(ocnt))
          TestSuiteDist(ocnt)=TestCaseDist;
        end
      end
    end
  end
end