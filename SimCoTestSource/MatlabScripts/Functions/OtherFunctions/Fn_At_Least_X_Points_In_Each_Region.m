function [YesorNo]=Fn_At_Least_X_Points_In_Each_Region(InputValues,InputSize,numPoints,divisionFactor,rangeStart,rangeStop)

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
    end
    YesorNo=1;
    for i=1:divisionFactor,
        for j=1:divisionFactor,
            if(pointCounter(i,j)<numPoints)
                YesorNo=0;
                break;
            end            
        end
        if(YesorNo==0)
            break;
        end
    end
end