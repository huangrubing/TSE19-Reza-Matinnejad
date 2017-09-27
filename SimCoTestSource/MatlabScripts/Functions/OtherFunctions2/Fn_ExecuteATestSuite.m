function [TestSuiteDist,TestSuiteOutput,tscov]=Fn_ExecuteATestSuite(delphiModel,orgmodelname,mutModelName,testsuite,ReportCov,InputTypesVar,NoSteps,NoOutputs,SimTime,SimStep,MaxDist,OutputIndex)

  NoTestCases=size(testsuite.TestCases,2);
  if(exist('OutputIndex','var'))
    TestSuiteDist=0;
    TestSuiteOutput=zeros(NoTestCases,NoSteps+1);
  else
    TestSuiteDist=zeros(NoOutputs,1);
    TestSuiteOutput=zeros(NoTestCases,NoOutputs,NoSteps+1);
  end
  for tccnt=1:NoTestCases,
    Output=Fn_ExecuteATestCase(delphiModel,orgmodelname,testsuite.TestCases(tccnt),false,InputTypesVar,'externalinputdata','yout',SimTime,SimStep);
    if(ReportCov)
      [MOutput,tccov]=Fn_ExecuteATestCase(delphiModel,mutModelName,testsuite.TestCases(tccnt),true,InputTypesVar,'externalinputdata','yout',SimTime,SimStep);
      if(tccnt==1)
        tscov=tccov;
      else
        tscov=tscov+tccov;
      end
    else
      MOutput=Fn_ExecuteATestCase(delphiModel,mutModelName,testsuite.TestCases(tccnt),false,InputTypesVar,'externalinputdata','yout',SimTime,SimStep);
    end
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