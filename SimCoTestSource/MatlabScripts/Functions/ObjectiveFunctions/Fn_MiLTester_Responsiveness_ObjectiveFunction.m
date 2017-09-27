function [ObjectiveFunctionValue]=Fn_MiLTester_Responsiveness_ObjectiveFunction(DesiredValueSignal,ActualValues,RangeStartVal,RangeStopVal,SimulationFixedStep)
    
    indexDesiredFinal=length(DesiredValueSignal);    
    indexActualInitial=round((length(ActualValues)-1)/2);
    indexActualFinal=length(ActualValues);    
    ObjectiveFunctionValue=computeResponsivenessObjective(DesiredValueSignal...
        (indexDesiredFinal),ActualValues,indexActualInitial+1,indexActualFinal,RangeStartVal,RangeStopVal,SimulationFixedStep);
end
function [responseTime]=computeResponsivenessObjective(DesiredValue,ActualValues,index1Actual,index2Actual,RangeStartVal,RangeStopVal,SimulationFixedStep)

    moreThan97NotSeenYet=1;
    responseTime=0;
    i=index1Actual;
    while(moreThan97NotSeenYet && i<=index2Actual)
        responseTime=responseTime+SimulationFixedStep;
        if(abs(DesiredValue-ActualValues(i))<=(0.03*(RangeStopVal-RangeStartVal)))               
            moreThan97NotSeenYet=0; 
        end
        i=i+1;        
    end
end