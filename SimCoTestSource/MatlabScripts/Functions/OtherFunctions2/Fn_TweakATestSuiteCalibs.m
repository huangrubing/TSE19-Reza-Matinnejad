function [testsuite]=Fn_TweakATestSuiteCalibs(testsuite,TweakSigma,NoParams,CalTypesVar,CalMinVals,CalMaxVals)
  

  [AdpCalMinVals,AdpCalMaxVals]=Fn_AdaptMinMaxValues(NoParams,CalTypesVar,CalMinVals,CalMaxVals);
  TestSuiteSize=size(testsuite.TestCases,2);
  for tccnt=1:TestSuiteSize,
    for parcnt=1:NoParams,
      CurValue=testsuite.TestCases(tccnt).paramRawValues(parcnt);
      NewValueIsInMinMaxRange=false;
      while(~NewValueIsInMinMaxRange)
        NewValue=CurValue+Fn_MiLTester_My_Normal_Rnd(0,TweakSigma*(AdpCalMaxVals(parcnt)-AdpCalMinVals(parcnt)));
        NewValueIsInMinMaxRange=true;
        if(NewValue>AdpCalMaxVals(parcnt) || NewValue<AdpCalMinVals(parcnt))
          NewValueIsInMinMaxRange=false;
        end
      end
      testsuite.TestCases(tccnt).paramRawValues(parcnt)=NewValue;
      testsuite.TestCases(tccnt).paramValues(parcnt)=Fn_RawToAppropriateValue(NewValue,CalTypesVar{parcnt},CalMinVals(parcnt),CalMaxVals(parcnt));
    end
  end
end