function [AdMinVals,AdMaxVals]=Fn_AdaptMinMaxValues(NoVars,TypesVar,MinVals,MaxVals) 

  AdMinVals=zeros(size(MinVals));
  AdMaxVals=zeros(size(MaxVals));
  for i=1:NoVars,
    if(strcmp(TypesVar{i},'f'))
      AdMinVals(i)=MinVals(i)-(MaxVals(i)-MinVals(i))/4;    
      AdMaxVals(i)=MaxVals(i)+(MaxVals(i)-MinVals(i))/4;
    elseif(strcmp(TypesVar{i},'e'))
      AdMinVals(i)=MinVals(i)-0.5;   
      AdMaxVals(i)=MaxVals(i)+0.499;   
    else
      AdMinVals(i)=MinVals(i);    
      AdMaxVals(i)=MaxVals(i);
    end
  end  
end