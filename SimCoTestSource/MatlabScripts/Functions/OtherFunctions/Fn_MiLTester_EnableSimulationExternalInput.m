function []=Fn_MiLTester_EnableSimulationExternalInput()
    hAcs = getActiveConfigSet(gcs);
    set_param(hAcs, 'LoadExternalInput', 'on');
end