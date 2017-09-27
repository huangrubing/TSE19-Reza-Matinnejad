function []=Fn_MiLTester_DisableSimulationExternalInput()
    hAcs = getActiveConfigSet(gcs);
    set_param(hAcs, 'LoadExternalInput', 'off');
end