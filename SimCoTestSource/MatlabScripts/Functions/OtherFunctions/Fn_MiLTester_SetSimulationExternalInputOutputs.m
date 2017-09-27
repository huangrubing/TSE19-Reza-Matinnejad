function []=Fn_MiLTester_SetSimulationExternalInputOutputs(externalinputname,externaltimename,externaloutputname)
    hAcs = getActiveConfigSet(gcs);
    set_param(hAcs, 'LoadExternalInput', 'on');
    set_param(hAcs, 'ExternalInput', externalinputname);
    set_param(hAcs,'SaveTime', 'on');
    set_param(hAcs, 'TimeSaveName', externaltimename);
    set_param(hAcs,'SaveOutput', 'on');
    set_param(hAcs, 'OutputSaveName', externaloutputname);
    set_param(hAcs, 'LimitDataPoints', 'off');
    set_param(hAcs,'SaveFormat', 'StructureWithTime');    
end