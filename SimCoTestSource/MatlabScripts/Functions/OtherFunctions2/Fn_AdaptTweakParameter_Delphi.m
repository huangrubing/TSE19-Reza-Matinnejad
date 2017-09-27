function [TweakSigma]=Fn_AdaptTweakParameter_Delphi(ModelName,NoOutputs,acctscov,inittscovval,TweakSigma,TweakSigmaExploration,TweakSigmaExploitation) 

  for ocnt=1:NoOutputs,
    decisioncov=decisioninfo(acctscov{ocnt}, strrep(ModelName,'.mdl',''));
    dcmul=decisioncov(1)/decisioncov(2);
    if(inittscovval(ocnt)==1)
      dcmul=0;
    else
      dcmul=(dcmul-inittscovval(ocnt))/(1-inittscovval(ocnt));  
    end
    TweakSigma(ocnt)=TweakSigmaExploration-(TweakSigmaExploration-TweakSigmaExploitation)*dcmul;
  end
end