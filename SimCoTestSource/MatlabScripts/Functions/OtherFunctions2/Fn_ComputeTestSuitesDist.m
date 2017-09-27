function [TestSuiteDist,corrTestCase]=Fn_ComputeTestSuitesDist(TestSuiteOutput1,TestSuiteOutput2,MaxDist,OutputIndex)

  
  NoTestCases=size(TestSuiteOutput1,1);
  NoTestCasesPrime=size(TestSuiteOutput2,1);
  if(NoTestCases~=NoTestCasesPrime)
    return;
  end
  NoOutputs=size(TestSuiteOutput1,2);
  NoOutputsPrime=size(TestSuiteOutput2,2);
  if(NoOutputs~=NoOutputsPrime)
    return;
  end
  if(exist('OutputIndex','var'))
    corrTestCase=0;
    TestSuiteDist=0;
  else
    corrTestCase=zeros(NoOutputs,1);
    TestSuiteDist=zeros(NoOutputs,1);
  end
  for tccnt=1:NoTestCases,
    if(exist('OutputIndex','var'))
      TestCaseDist=norm(TestSuiteOutput1(tccnt,OutputIndex,:)-TestSuiteOutput2(tccnt,OutputIndex,:))/MaxDist(OutputIndex);
      if(TestCaseDist>TestSuiteDist)
        corrTestCase=tccnt;
        TestSuiteDist=TestCaseDist;
      end
    else
      for ocnt=1:NoOutputs,        
        TestCaseDist=norm(squeeze(TestSuiteOutput1(tccnt,ocnt,:))-squeeze(TestSuiteOutput2(tccnt,ocnt,:)))/MaxDist(ocnt);
        if(TestCaseDist>=TestSuiteDist(ocnt))
          corrTestCase(ocnt)=tccnt;
          TestSuiteDist(ocnt)=TestCaseDist;
        end
      end
    end
  end
end