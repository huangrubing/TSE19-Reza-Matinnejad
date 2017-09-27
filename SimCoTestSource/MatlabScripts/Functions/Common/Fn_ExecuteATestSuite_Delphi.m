function [TestSuiteOutput,tscov,tccovs]=Fn_ExecuteATestSuite_Delphi(delphiModel,orgmodelname,testsuite,ReportCov,InputTypesVar,NoSteps,NoOutputs,SimTime,SimStep,InputTypesModeVar,IsSignedVal,WordLengthVal,SlopeVal,BiasVal,FractionLengthVal)

  
  NoTestCases=size(testsuite.TestCases,2);
  if(exist('OutputIndex','var'))
    TestSuiteOutput=zeros(NoTestCases,NoSteps+1);
  else
    TestSuiteOutput=zeros(NoTestCases,NoOutputs,NoSteps+1);
  end
  for tccnt=1:NoTestCases,
    if(ReportCov)
      [OrgOutput,tccov]=Fn_ExecuteATestCase_Delphi(delphiModel,orgmodelname,testsuite.TestCases(tccnt),true,InputTypesVar,'externalinputdata','yout',SimTime,SimStep,InputTypesModeVar,IsSignedVal,WordLengthVal,SlopeVal,BiasVal,FractionLengthVal);
      tccovs{tccnt}=tccov;
      if(tccnt==1)
        tscov=tccov;
      else
        tscov=tscov+tccov;
      end
    else
      OrgOutput=Fn_ExecuteATestCase_Delphi(delphiModel,orgmodelname,testsuite.TestCases(tccnt),false,InputTypesVar,'externalinputdata','yout',SimTime,SimStep,InputTypesModeVar,IsSignedVal,WordLengthVal,SlopeVal,BiasVal,FractionLengthVal);
    end
    if(exist('OutputIndex','var'))
      TestSuiteOutput(tccnt,:)=OrgOutput(OutputIndex,:);
    else      
      TestSuiteOutput(tccnt,:,:)=OrgOutput(:,:);
    end
  end
  clear testsuite;
end