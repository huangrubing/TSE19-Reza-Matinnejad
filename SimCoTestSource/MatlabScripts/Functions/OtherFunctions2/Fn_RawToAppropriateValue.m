function [AppropriateVal]=Fn_RawToAppropriateValue(RawVal,TypeStr,MinVal,MaxVal)

  if(strcmp(TypeStr,'f'))
    if(RawVal < MinVal)
      AppropriateVal=MinVal;
    elseif(RawVal>MaxVal)
      AppropriateVal=MaxVal;
    else
      AppropriateVal=RawVal;
    end
  else
    if(strcmp(TypeStr,'e') || strcmp(TypeStr,'TbBOOLEAN') || strcmp(TypeStr,'boolean') || strcmp(TypeStr,'TbBOOLEANF') || strcmp(TypeStr,'TbBOOLEANT'))
      AppropriateVal=round(RawVal);
    end
  end
end 