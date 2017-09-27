function [ObjectiveFunctionValue]=Fn_MiLTester_Liveness_ObjectiveFunction(DesiredValueSignal,ActualValues)

    indexDesiredFinalEnd=length(DesiredValueSignal);
    
    indexActualFinalStart=length(ActualValues)-round((length(ActualValues)/10));
    indexActualFinalEnd=length(ActualValues);
    ObjectiveFunctionValue=0;
    for i=indexActualFinalStart:indexActualFinalEnd,
        ObjectiveFunctionValueTemp=abs(DesiredValueSignal(indexDesiredFinalEnd)...
            -ActualValues(i));
        if(ObjectiveFunctionValueTemp>ObjectiveFunctionValue)
            ObjectiveFunctionValue=ObjectiveFunctionValueTemp;
        end
    end
end

