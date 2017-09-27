function [HeatMaps]=Fn_MiLTester_GenerateHeatMapDiagrams(InputValues,ObjectiveFunction,numObjecctiveFunctions,InputSize,divisionFactor,rangeStart,rangeStop)
  
  HeatMaps=zeros(divisionFactor*divisionFactor,4+numObjecctiveFunctions);
  pointCounter=zeros(divisionFactor,divisionFactor);
  for i=1:InputSize,
    index1=floor(((InputValues(i,1)-rangeStart)*divisionFactor)/(rangeStop-rangeStart))+1;
    if(index1==(divisionFactor+1))
      index1=divisionFactor;
    end
    index2=floor(((InputValues(i,2)-rangeStart)*divisionFactor)/(rangeStop-rangeStart))+1;
    if(index2==(divisionFactor+1))
      index2=divisionFactor;
    end
    pointCounter(index1,index2)=pointCounter(index1,index2)+1;
    for j=1:numObjecctiveFunctions,
      HeatMaps((index1-1)*(divisionFactor)+index2,j+4)=HeatMaps((index1-1)*(divisionFactor)+index2,j+4)+ObjectiveFunction(i,j);
    end  
  end
  for index1=1:divisionFactor,
    for index2=1:divisionFactor,
      HeatMaps((index1-1)*(divisionFactor)+index2,1)=index1-1;
      HeatMaps((index1-1)*(divisionFactor)+index2,2)=index2-1;
      HeatMaps((index1-1)*(divisionFactor)+index2,3)=rangeStart+(index1-1)*((rangeStop-rangeStart)/divisionFactor)+((rangeStop-rangeStart)/(2*divisionFactor));
      HeatMaps((index1-1)*(divisionFactor)+index2,4)=rangeStart+(index2-1)*((rangeStop-rangeStart)/divisionFactor)+((rangeStop-rangeStart)/(2*divisionFactor));
      for j=1:numObjecctiveFunctions,
        HeatMaps((index1-1)*(divisionFactor)+index2,j+4)=HeatMaps((index1-1)*(divisionFactor)+index2,j+4)/pointCounter(index1,index2);
      end 
    end
  end
end