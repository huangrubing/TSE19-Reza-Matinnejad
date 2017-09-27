function [testsuite]=Fn_CompleteARandomTestSuiteWithCalibs(testsuite,NoParams,CalNamesVar,CalTypesVar,CalMinVals,CalMaxVals)

  [AdpCalMinVals,AdpCalMaxVals]=Fn_AdaptMinMaxValues(NoParams,CalTypesVar,CalMinVals,CalMaxVals);
  TestSuiteSize=size(testsuite.TestCases,2);
  for tccnt=1:TestSuiteSize,
    testsuite.TestCases(tccnt).paramValues=zeros(1,NoParams);
    for parcnt=1:NoParams,
      testsuite.TestCases(tccnt).paramNames{parcnt}=CalNamesVar{parcnt};
      testsuite.TestCases(tccnt).paramRawValues(parcnt)=AdpCalMinVals(parcnt)+(AdpCalMaxVals(parcnt)-AdpCalMinVals(parcnt))*rand(1);
      testsuite.TestCases(tccnt).paramValues(parcnt)=Fn_RawToAppropriateValue(testsuite.TestCases(tccnt).paramRawValues(parcnt),CalTypesVar{parcnt},CalMinVals(parcnt),CalMaxVals(parcnt));
    end
  end
end