function [ObjectiveFunctionValue]=Fn_MiLTester_Smoothness_ObjectiveFunction(DesiredValueSignal,ActualValues,RangeStartVal,RangeStopVal)
    
    indexDesiredFinal=length(DesiredValueSignal);    
    indexActualInitial=round((length(ActualValues)-1)/2);
    indexActualFinal=length(ActualValues);
    
    ObjectiveFunctionValue=computeSmoothnessObjective(...
        DesiredValueSignal(indexDesiredFinal),ActualValues,indexActualInitial+1,indexActualFinal,RangeStartVal,RangeStopVal);
end
function [maxOvershoot]=computeSmoothnessObjective(DesiredValue,ActualValues,index1Actual,index2Actual,RangeStartVal,RangeStopVal)

    moreThan95ForTheFirstTime=0;
    maxOvershoot=0;
    for i=index1Actual:index2Actual,
        if(moreThan95ForTheFirstTime)
            if(abs(DesiredValue-ActualValues(i))>maxOvershoot)
                maxOvershoot=abs(DesiredValue-ActualValues(i));
            end
        else
           if(abs(DesiredValue-ActualValues(i))<=(0.05*(RangeStopVal-RangeStartVal)))
                moreThan95ForTheFirstTime=1;
           end
        end
    end
end