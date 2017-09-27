function [HeatMapRegions]=Fn_MiLTester_GenerateHeatMapRegions(InputValues,ObjectiveFunction,numObjecctiveFunctions,InputSize,divisionFactor,rangeStart,rangeStop)
  
  HeatMapRegions=zeros(divisionFactor*divisionFactor,6+numObjecctiveFunctions*3);
  pointCounter=zeros(divisionFactor,divisionFactor);
  WorstValue=zeros(numObjecctiveFunctions,divisionFactor,divisionFactor);
  WorstValueIndex=zeros(numObjecctiveFunctions,divisionFactor,divisionFactor);
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
      HeatMapRegions((index1-1)*(divisionFactor)+index2,7+(j-1)*3)=HeatMapRegions((index1-1)*(divisionFactor)+index2,7+(j-1)*3)+ObjectiveFunction(i,j);
      if(ObjectiveFunction(i,j)>=WorstValue(j,index1,index2))
        WorstValue(j,index1,index2)=ObjectiveFunction(i,j);
        WorstValueIndex(j,index1,index2)=i;
      end
    end
  end
  for index1=1:divisionFactor,
    for index2=1:divisionFactor,
      HeatMapRegions((index1-1)*(divisionFactor)+index2,1)=index1-1;
      HeatMapRegions((index1-1)*(divisionFactor)+index2,2)=index2-1;
      HeatMapRegions((index1-1)*(divisionFactor)+index2,3)=rangeStart+(index1-1)*((rangeStop-rangeStart)/divisionFactor);
      HeatMapRegions((index1-1)*(divisionFactor)+index2,4)=rangeStart+(index1-1)*((rangeStop-rangeStart)/divisionFactor)+((rangeStop-rangeStart)/(divisionFactor));
      HeatMapRegions((index1-1)*(divisionFactor)+index2,5)=rangeStart+(index2-1)*((rangeStop-rangeStart)/divisionFactor);
      HeatMapRegions((index1-1)*(divisionFactor)+index2,6)=rangeStart+(index2-1)*((rangeStop-rangeStart)/divisionFactor)+((rangeStop-rangeStart)/(divisionFactor));
      for j=1:numObjecctiveFunctions,
        HeatMapRegions((index1-1)*(divisionFactor)+index2,7+(j-1)*3)=HeatMapRegions((index1-1)*(divisionFactor)+index2,7+(j-1)*3)/pointCounter(index1,index2);
        HeatMapRegions((index1-1)*(divisionFactor)+index2,8+(j-1)*3)=InputValues(WorstValueIndex(j,index1,index2),1);
        HeatMapRegions((index1-1)*(divisionFactor)+index2,9+(j-1)*3)=InputValues(WorstValueIndex(j,index1,index2),2);
      end
    end
  end
end