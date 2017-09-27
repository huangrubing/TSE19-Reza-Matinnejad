function [SingleStateSearchResults]=Fn_MiLTester_GenerateSingleStateSearchResults(InputValues,ObjectiveFunction,AlgorithmRounds,AlgorithmIterations,ObjectiveFunctionIndex)
  
  SingleStateSearchResults=zeros(AlgorithmRounds*AlgorithmIterations,3+size(InputValues,3));
  for i=1:AlgorithmRounds,
    for j=1:AlgorithmIterations,
      SingleStateSearchResults((i-1)*AlgorithmIterations+j,1)=i;
      SingleStateSearchResults((i-1)*AlgorithmIterations+j,2)=j;
      for k=1:size(InputValues,3),
        SingleStateSearchResults((i-1)*AlgorithmIterations+j,2+k)=InputValues(i,j,k);
      end
      SingleStateSearchResults((i-1)*AlgorithmIterations+j,3+size(InputValues,3))=ObjectiveFunction(i,j,ObjectiveFunctionIndex);
    end
  end
end