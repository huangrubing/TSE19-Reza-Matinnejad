function [SimulationTimeStep]=Fn_MiLTester_GetSimulationTimeStep()

    hAcs = getActiveConfigSet(gcs);
    SimulationTimeStepStr=get_param(hAcs, 'FixedStep');
    SimulationTimeStep=str2double(SimulationTimeStepStr);
end