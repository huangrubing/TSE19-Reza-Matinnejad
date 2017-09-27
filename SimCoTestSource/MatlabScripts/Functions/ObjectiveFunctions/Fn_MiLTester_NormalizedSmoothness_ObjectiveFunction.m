function [ObjectiveFunctionValue]=Fn_MiLTester_NormalizedSmoothness_ObjectiveFunction(DesiredValueSignal,ActualValues,RangeStartVal,RangeStopVal)
    
    indexDesiredInitial=1;
    indexDesiredFinal=length(DesiredValueSignal);    
    indexActualInitial=round((length(ActualValues)-1)/2);
    indexActualFinal=length(ActualValues);
    
    ObjectiveFunctionValue=computeSmoothnessObjective(...
        DesiredValueSignal(indexDesiredInitial),DesiredValueSignal(indexDesiredFinal),ActualValues,indexActualInitial+1,indexActualFinal,RangeStartVal,RangeStopVal);
end
function [maxOvershoot]=computeSmoothnessObjective(InitialDesiredValue,FinalDesiredValue,ActualValues,index1Actual,index2Actual,RangeStartVal,RangeStopVal)

    moreThan95ForTheFirstTime=0;
    maxOvershoot=0;
    for i=index1Actual:index2Actual,
        if(moreThan95ForTheFirstTime)
            if(abs(FinalDesiredValue-ActualValues(i))>maxOvershoot)
                maxOvershoot=abs(FinalDesiredValue-ActualValues(i));
            end
        else
           if(abs(FinalDesiredValue-ActualValues(i))<=(0.05*(RangeStopVal-RangeStartVal)))
                moreThan95ForTheFirstTime=1; 
           end
        end
    end
    if((InitialDesiredValue==FinalDesiredValue) || ...
        (abs(InitialDesiredValue-FinalDesiredValue)<(0.01*(RangeStopVal-RangeStartVal))))
        maxOvershoot=0;
    else
        maxOvershoot=maxOvershoot/(maxOvershoot+(abs(InitialDesiredValue-FinalDesiredValue)));
    end
end