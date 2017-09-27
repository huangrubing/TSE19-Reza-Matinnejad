function [TestSuiteOD]=Fn_ComputeTestSuiteOD(distancemethod,TestSuiteOutputOrFeatures)

  NoTestCases=size(TestSuiteOutputOrFeatures,1); 
  if(ndims(TestSuiteOutputOrFeatures)<=2)
    TestSuiteAllODs=inf(NoTestCases,NoTestCases);
    for tccnt1=1:NoTestCases,
      for tccnt2=tccnt1+1:NoTestCases,
        if(strcmp(distancemethod,'vector'))
          TestSuiteAllODs(tccnt1,tccnt2)=Fn_MyNorm(squeeze(TestSuiteOutputOrFeatures(tccnt1,:))-squeeze(TestSuiteOutputOrFeatures(tccnt2,:)));
          TestSuiteAllODs(tccnt2,tccnt1)=TestSuiteAllODs(tccnt1,tccnt2);
        elseif(strcmp(distancemethod,'features'))
          TestSuiteAllODs(tccnt1,tccnt2)=Fn_MyNorm(squeeze(TestSuiteOutputOrFeatures(tccnt1,:))-squeeze(TestSuiteOutputOrFeatures(tccnt2,:)));
          TestSuiteAllODs(tccnt2,tccnt1)=TestSuiteAllODs(tccnt1,tccnt2);
        end
      end
    end
    TestSuiteOD=mean(min(TestSuiteAllODs(:,:))); 
    %TestSuiteOD=min(min(TestSuiteAllODs(:,:))); 
  else
    NoOutputs=size(TestSuiteOutputOrFeatures,2); 
    TestSuiteOD=zeros(NoOutputs,1);
    TestSuiteAllODs=inf(NoOutputs,NoTestCases,NoTestCases);
    for ocnt=1:NoOutputs,      
      for tccnt1=1:NoTestCases,
        for tccnt2=tccnt1+1:NoTestCases,
          if(strcmp(distancemethod,'vector'))
            TestSuiteAllODs(ocnt,tccnt1,tccnt2)=norm(squeeze(TestSuiteOutputOrFeatures(tccnt1,ocnt,:))-squeeze(TestSuiteOutputOrFeatures(tccnt2,ocnt,:)));
            TestSuiteAllODs(ocnt,tccnt2,tccnt1)=TestSuiteAllODs(ocnt,tccnt1,tccnt2);
          elseif(strcmp(distancemethod,'features'))
            TestSuiteAllODs(ocnt,tccnt1,tccnt2)=norm(squeeze(TestSuiteOutputOrFeatures(tccnt1,ocnt,:))-squeeze(TestSuiteOutputOrFeatures(tccnt2,ocnt,:)));
            TestSuiteAllODs(ocnt,tccnt2,tccnt1)=TestSuiteAllODs(ocnt,tccnt1,tccnt2);
          end
        end
      end
      TestSuiteOD(ocnt)=mean(min(TestSuiteAllODs(ocnt,:,:)));
      %TestSuiteOD(ocnt)=min(min(TestSuiteAllODs(ocnt,:,:)));
    end
  end
end