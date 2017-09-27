function [minType,maxType]=Fn_getminmaxfix(isSigned,wordLength,fractionLength)
 if(~isSigned)
   minType=0;
 else
   minType=-(2^(wordLength-(fractionLength+1)));
 end
 if(~isSigned)
   maxType=(2^(wordLength-fractionLength))-(1/(2^(fractionLength)));
 else
   maxType=(2^(wordLength-(fractionLength+1)))-(1/(2^(fractionLength)));  
 end
end