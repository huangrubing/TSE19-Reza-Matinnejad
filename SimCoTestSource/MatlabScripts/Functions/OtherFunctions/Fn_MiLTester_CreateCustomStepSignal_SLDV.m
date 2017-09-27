function CustomStepSignal = Fn_MiLTester_CreateCustomStepSignal_SLDV(Val,Time,SimulationTime,SimulationTimeStep)


   Time=sort(Time);
   CustomStepSignal.dimensions = 1;
   SimulationSteps = int16(SimulationTime/SimulationTimeStep);
   CustomStepSignal.time = zeros(SimulationSteps+1,1); 
   CustomStepSignal.values = zeros(SimulationSteps+1,1);
   simulationCurrentTime = 0;
   assert(Time(1)==0);
   %if(length(Val)>1)
   %  assert(Val(length(Val))==Val(length(Val)-1));
   %   display('here');
   %end
   CntVal=1;
   for i=1:length(CustomStepSignal.time),
     CustomStepSignal.time(i,1) = simulationCurrentTime;
     CustomStepSignal.values(i,1) = Val(1,CntVal);
     simulationCurrentTime = simulationCurrentTime + SimulationTimeStep;
     if(CntVal<length(Val) && (simulationCurrentTime > Time(1,CntVal+1)))
       CntVal=CntVal+1;
     end
   end
end 