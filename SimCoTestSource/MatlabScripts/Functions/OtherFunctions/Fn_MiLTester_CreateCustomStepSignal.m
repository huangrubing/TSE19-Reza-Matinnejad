function CustomStepSignal = Fn_MiLTester_CreateCustomStepSignal(Val,Time,SimulationTime,SimulationTimeStep)


   Time=sort(Time);
   CustomStepSignal.signals.dimensions = 1;
   SimulationSteps = int16(SimulationTime/SimulationTimeStep);
   CustomStepSignal.time = zeros(SimulationSteps+1,1); 
   CustomStepSignal.signals.values = zeros(SimulationSteps+1,1);
   simulationCurrentTime = 0;
   
   CntVal=1;
   for i=1:length(CustomStepSignal.time),
     CustomStepSignal.time(i,1) = simulationCurrentTime;
     CustomStepSignal.signals.values(i,1) = Val(1,CntVal);
     simulationCurrentTime = simulationCurrentTime + SimulationTimeStep;
     if(CntVal<length(Val) && simulationCurrentTime>Time(1,CntVal))
       CntVal=CntVal+1;
     end
   end
end 