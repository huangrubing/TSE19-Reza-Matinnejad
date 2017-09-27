function [SingleStateSearchRoundsComparison]=Fn_MiLTester_GenerateSingleStateSearchRoundsComparison(ObjectiveFunction,AlgorithmRounds,AlgorithmIterations,ObjectiveFunctionIndex)
  
  SingleStateSearchRoundsComparison=zeros(AlgorithmIterations,AlgorithmRounds+2);
  SingleStateSearchRoundsComparison(1,1)=1;
  for i=1:AlgorithmRounds,
    SingleStateSearchRoundsComparison(1,i+1)=ObjectiveFunction(i,1,ObjectiveFunctionIndex);
  end
  for j=2:AlgorithmIterations,
    SingleStateSearchRoundsComparison(j,1)=j; 
    for i=1:AlgorithmRounds,
      if(SingleStateSearchRoundsComparison(j-1,i+1)<ObjectiveFunction(i,j,ObjectiveFunctionIndex))
        SingleStateSearchRoundsComparison(j,i+1)=ObjectiveFunction(i,j,ObjectiveFunctionIndex);
      else
        SingleStateSearchRoundsComparison(j,i+1)=SingleStateSearchRoundsComparison(j-1,i+1);
      end
    end
  end
  for j=1:AlgorithmIterations,
    for i=1:AlgorithmRounds,
      SingleStateSearchRoundsComparison(j,AlgorithmRounds+2)=SingleStateSearchRoundsComparison(j,AlgorithmRounds+2)+SingleStateSearchRoundsComparison(j,i+1);
    end
    SingleStateSearchRoundsComparison(j,AlgorithmRounds+2)=SingleStateSearchRoundsComparison(j,AlgorithmRounds+2)/AlgorithmRounds;
  end
end