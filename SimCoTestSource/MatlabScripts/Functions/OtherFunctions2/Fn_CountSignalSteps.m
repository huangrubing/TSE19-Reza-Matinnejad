function [signalSteps]=Fn_CountSignalSteps(Val)

   signalSteps=1;
   for i=2:length(Val),
     if(Val(i)~=Val(i-1))
       signalSteps=signalSteps+1;
     end
   end
end 