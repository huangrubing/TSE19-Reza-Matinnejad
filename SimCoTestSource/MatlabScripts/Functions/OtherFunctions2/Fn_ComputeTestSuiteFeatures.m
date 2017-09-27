function [TestSuiteFeatures]=Fn_ComputeTestSuiteFeatures(TestSuiteOutput)

  NoFeatures=9;
  NoTestCases=size(TestSuiteOutput,1);
  if(ndims(TestSuiteOutput)<=2)
    NoSteps=size(TestSuiteOutput,2);
    TestSuiteFeatures=zeros(NoTestCases,NoFeatures);
    cln={':'};
  else
    NoOutputs=size(TestSuiteOutput,2);
    NoSteps=size(TestSuiteOutput,3);
    TestSuiteFeatures=zeros(NoTestCases,NoOutputs,NoFeatures);
    cln={':',':'};
  end
  TestSuiteFeatures(cln{:},1)=abs(TestSuiteOutput(cln{:},1));
  TestSuiteFeatures(cln{:},2)=TestSuiteOutput(cln{:},2);
  for cnt=2:NoSteps-1,
    BackCR=Fn_BackCR(TestSuiteOutput,cln,cnt);
    ForwCR=Fn_ForwCR(TestSuiteOutput,cln,cnt);
    BackCRSign=Fn_BackCRSign(BackCR);
    ForwCRSign=Fn_ForwCRSign(ForwCR);
    LocOpt=Fn_LocOpt(BackCRSign,ForwCRSign);
    StrLocOpt=Fn_StrLocOpt(BackCRSign,ForwCRSign);
    TestSuiteFeatures(cln{:},1)=TestSuiteFeatures(cln{:},1)+abs(TestSuiteOutput(cln{:},cnt));
    TestSuiteFeatures(cln{:},2)=TestSuiteFeatures(cln{:},2)+TestSuiteOutput(cln{:},cnt);
    TestSuiteFeatures(cln{:},3)=TestSuiteFeatures(cln{:},3)+abs(BackCR);
    TestSuiteFeatures(cln{:},4)=TestSuiteFeatures(cln{:},4)+BackCRSign;
    TestSuiteFeatures(cln{:},5)=max(TestSuiteFeatures(cln{:},5),abs(BackCR));
    TestSuiteFeatures(cln{:},6)=max(TestSuiteFeatures(cln{:},6),min(abs(BackCR),abs(ForwCR)));
    TestSuiteFeatures(cln{:},7)=max(TestSuiteFeatures(cln{:},7),abs(BackCR).*LocOpt);
    TestSuiteFeatures(cln{:},8)=max(TestSuiteFeatures(cln{:},8),abs(BackCR).*StrLocOpt);
    TestSuiteFeatures(cln{:},9)=max(TestSuiteFeatures(cln{:},9),min(abs(BackCR),abs(ForwCR)).*StrLocOpt);
   end
  TestSuiteFeatures(cln{:},1)=TestSuiteFeatures(cln{:},1)+abs(TestSuiteOutput(cln{:},NoSteps));
  TestSuiteFeatures(cln{:},2)=TestSuiteFeatures(cln{:},2)+abs(TestSuiteOutput(cln{:},NoSteps));
  TestSuiteFeatures(cln{:},3)=TestSuiteFeatures(cln{:},3)+abs(BackCR);
  %TestSuiteFeatures(cln{:},4)=TestSuiteFeatures(cln{:},4)+BackCRSign;
  %TestSuiteFeatures(cln{:},5)=max(TestSuiteFeatures(cln{:},5),abs(BackCR));    
end
function [BackCR]=Fn_BackCR(TestSuiteOutput,cln,cnt)
  BackCR=TestSuiteOutput(cln{:},cnt)-TestSuiteOutput(cln{:},cnt-1);
end
function [ForwCR]=Fn_ForwCR(TestSuiteOutput,cln,cnt)
  ForwCR=TestSuiteOutput(cln{:},cnt+1)-TestSuiteOutput(cln{:},cnt);
end
function [BackCRSign]=Fn_BackCRSign(BackCR)
  BackCRSign=BackCR./abs(BackCR);
  BackCRSign(find(isnan(BackCRSign)))=0;
end
function [ForwCRSign]=Fn_ForwCRSign(ForwCR)
  ForwCRSign=ForwCR./abs(ForwCR);
  ForwCRSign(find(isnan(ForwCRSign)))=0;
end
function [LocOpt]=Fn_LocOpt(BackCRSign,ForwCRSign)
  LocOpt=(BackCRSign~=ForwCRSign);
end
function [StrLocOpt]=Fn_StrLocOpt(BackCRSign,ForwCRSign)
  StrLocOpt=(BackCRSign~=0&(BackCRSign==(-ForwCRSign)));
end