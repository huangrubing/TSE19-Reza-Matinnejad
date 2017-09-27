function [ChangedMaxVals]=Fn_ChangedFixedPointMaxVals(NoVars,MaxVals,TypesVar,TypesModeVar,FractionLengthVal);
  ChangedMaxVals=MaxVals;
  for i=1:NoVars,
    if(strcmp(TypesVar{i},'f'))
      if(strcmp(TypesModeVar{i},'Binary'))
        ChangedMaxVals(i)=MaxVals(i)-(2/(2^FractionLengthVal(i)));
      end
    end
  end
end