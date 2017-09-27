function [TestSuiteDistForAllTCs]=Fn_ComputeTestSuitesDistForAllTCs(TestSuiteOutput1,TestSuiteOutput2,MaxDist,OutputIndex)

  
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
    TestSuiteDistForAllTCs=zeros(NoTestCases,1);
  else
    TestSuiteDistForAllTCs=zeros(NoTestCases,NoOutputs);
  end
  for tccnt=1:NoTestCases,
    if(exist('OutputIndex','var'))
      TestSuiteDistForAllTCs(tccnt)=norm(squeeze(TestSuiteOutput1(tccnt,OutputIndex,:))-squeeze(TestSuiteOutput2(tccnt,OutputIndex,:)))/MaxDist(OutputIndex);
    else
      for ocnt=1:NoOutputs,        
        TestSuiteDistForAllTCs(tccnt,ocnt)=norm(squeeze(TestSuiteOutput1(tccnt,ocnt,:))-squeeze(TestSuiteOutput2(tccnt,ocnt,:)))/MaxDist(ocnt);
      end
    end
  end
end