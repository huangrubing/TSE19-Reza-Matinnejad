function [minType,maxType]=Fn_GetMinMaxFix_SlopeMode(isSigned,wordLength,slope,bias)
 if(~isSigned)
   minType=bias;
 else
   minType=-(2^(wordLength-1))*slope+bias;
 end
 if(~isSigned)
   maxType=(2^wordLength-1)*slope+bias;
 else
   maxType=(2^(wordLength-1)-1)*slope+bias;  
 end
end