function [ObjectiveFunctionValue]=Fn_MiLTester_Stability_ObjectiveFunction(ActualValues)


    
    indexActualFinalStart=length(ActualValues)-round((length(ActualValues)/10));
    indexActualFinalEnd=length(ActualValues);

    StabilityArray=ActualValues(indexActualFinalStart:indexActualFinalEnd);
    ObjectiveFunctionValue=std(StabilityArray);
end

