function DesiredPosSignal=Fn_MiLTester_CreateDesiredValueInputSignal(InitialDsrdVal,FinalDsrdVal,SimulationTime,SimulationTimeStep)

   DesiredPosSignal.signals.dimensions=1;
   SimulationSteps=int16(SimulationTime/SimulationTimeStep);
   DesiredPosSignal.time=zeros(SimulationSteps+1,1);% one extra place for zero
   DesiredPosSignal.signals.values=zeros(SimulationSteps+1,1);
   simulationCurrentTime=0;
   for i=1:(SimulationSteps/2),
     DesiredPosSignal.time(i,1) = simulationCurrentTime;
     simulationCurrentTime = simulationCurrentTime + SimulationTimeStep;  
   end
   for i=(SimulationSteps/2)+1:(SimulationSteps+1),
     DesiredPosSignal.time(i,1) = simulationCurrentTime;
     simulationCurrentTime = simulationCurrentTime + SimulationTimeStep;  
   end
   %Initial Flap Position
   for i=1:(SimulationSteps/2), 
     DesiredPosSignal.signals.values(i,1) = InitialDsrdVal;
   end
   %Final Flap Position
   for i=(SimulationSteps/2)+1:(SimulationSteps+1),
     DesiredPosSignal.signals.values(i,1) = FinalDsrdVal;
   end
end 