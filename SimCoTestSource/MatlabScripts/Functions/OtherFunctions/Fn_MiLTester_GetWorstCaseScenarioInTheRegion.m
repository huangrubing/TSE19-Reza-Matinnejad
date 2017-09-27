function [WorstCaseScenarioInTheRegion]=Fn_MiLTester_GetWorstCaseScenarioInTheRegion(InputValues,ObjectiveFunction,AlgorithmRounds,AlgorithmIterations,ObjectiveFunctionIndex,RegionIndexX,RegionIndexY)
  
  WorstCaseScenarioInTheRegion=zeros(2+size(InputValues,3),1);
  WorstRound=1;
  WorstIteration=1;
  WorstObjectiveFunction=ObjectiveFunction(WorstRound,WorstIteration,ObjectiveFunctionIndex);
  for i=1:AlgorithmRounds,
    for j=1:AlgorithmIterations,
     if(WorstObjectiveFunction<ObjectiveFunction(i,j,ObjectiveFunctionIndex))
       WorstObjectiveFunction=ObjectiveFunction(i,j,ObjectiveFunctionIndex);
       WorstRound=i;
       WorstIteration=j;
     end 
    end
  end
  WorstCaseScenarioInTheRegion(1)=RegionIndexX;

  WorstCaseScenarioInTheRegion(2)=RegionIndexY;
  for k=1:size(InputValues,3),
    WorstCaseScenarioInTheRegion(k+2)=InputValues(WorstRound,WorstIteration,k);
  end
  WorstCaseScenarioInTheRegion=transpose(WorstCaseScenarioInTheRegion);
end