function [testsuite]=Fn_GenerateARandomTestSuite(NoInputVars,InputNamesVar,InputTypesVar,InputMinVals,InputMaxVals,TestSuiteComplexity,TestSuiteSize,SimTime,SimStep)

  [AdpInputMinVals,AdpInputMaxVals]=Fn_AdaptMinMaxValues(NoInputVars,InputTypesVar,InputMinVals,InputMaxVals);
  for tccnt=1:TestSuiteSize,
    curTimeValues=repmat(SimTime,NoInputVars,max(TestSuiteComplexity(tccnt,:)));
    for icnt=1:NoInputVars,
      testsuite.TestCases(tccnt).inputNames{icnt}=InputNamesVar{icnt};
      timePoints=TestSuiteComplexity(tccnt,icnt)-1;
      if(timePoints>0)
        testsuite.TestCases(tccnt).timeRawValues{icnt,1}=sort(rand(1,timePoints)*SimTime);
        curTimeValues(icnt,1:timePoints)=round(testsuite.TestCases(tccnt).timeRawValues{icnt,1}/SimStep)*SimStep;
      end
      for j=1:TestSuiteComplexity(tccnt,icnt),
        RawValue=AdpInputMinVals(icnt)+(AdpInputMaxVals(icnt)-AdpInputMinVals(icnt))*rand(1);
        if(j==1)
          testsuite.TestCases(tccnt).dataRawValues{icnt,1}=RawValue;
        else
          testsuite.TestCases(tccnt).dataRawValues{icnt,1}=[testsuite.TestCases(tccnt).dataRawValues{icnt,1}, RawValue];
        end
        ApprValue=Fn_RawToAppropriateValue(RawValue,InputTypesVar{icnt},InputMinVals(icnt),InputMaxVals(icnt));
        if(j==1)
          testsuite.TestCases(tccnt).dataValues{icnt,1}=ApprValue;
        else
          testsuite.TestCases(tccnt).dataValues{icnt,1}=[testsuite.TestCases(tccnt).dataValues{icnt,1}, ApprValue];
        end
      end
    end
    testsuite.TestCases(tccnt).timeValues=sort(unique([curTimeValues(:)',0,SimTime]));
    for icnt=1:NoInputVars,
      curDataValues=testsuite.TestCases(tccnt).dataValues{icnt,1};
      l=1;
      for k=1:size(testsuite.TestCases(tccnt).timeValues,2),
        if(testsuite.TestCases(tccnt).timeValues(k)>=curTimeValues(icnt,l) && ...
            testsuite.TestCases(tccnt).timeValues(k)~=SimTime)
          l=l+1;
        end
        if(k==1)
          testsuite.TestCases(tccnt).dataValues{icnt,1}=curDataValues(l);
        else
          testsuite.TestCases(tccnt).dataValues{icnt,1}=[testsuite.TestCases(tccnt).dataValues{icnt,1}, curDataValues(l)];
        end
      end
    end
  end
end