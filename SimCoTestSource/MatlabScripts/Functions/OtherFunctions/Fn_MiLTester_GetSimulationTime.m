function [SimulationTime]=Fn_MiLTester_GetSimulationTime()

    hAcs = getActiveConfigSet(gcs);
    SimulationTimeStr=get_param(hAcs, 'StopTime');
    SimulationTime=str2double(SimulationTimeStr);
end