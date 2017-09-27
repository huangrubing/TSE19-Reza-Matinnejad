function [NoVars,NamesVar,TypesVar,MinVals,MaxVals]=Dep_Fn_ReadInputSigNames(filesdirectory,inputfilename)

  
  finputsigsnames=fopen(sprintf('%s/%s',filesdirectory,inputfilename),'rt');
  cnt=1;
  nextline=fgetl(finputsigsnames);
  while(ischar(nextline))
    nextline=textscan(nextline,'%s');
    varcnt=1;
    NamesVar{cnt}=nextline{1}{varcnt};
    varcnt=varcnt+1;
    TypesVar{cnt}=nextline{1}{varcnt};
    varcnt=varcnt+1;
    if(strcmp(TypesVar{cnt},'f'))
      MinVar{cnt}=str2double(nextline{1}{varcnt});
      varcnt=varcnt+1;
      MaxVar{cnt}=str2double(nextline{1}{varcnt});
      varcnt=varcnt+1;
    elseif(strcmp(TypesVar{cnt},'e'))
      MinVar{cnt}=str2double(nextline{1}{varcnt});
      varcnt=varcnt+1;
      MaxVar{cnt}=str2double(nextline{1}{varcnt});
      varcnt=varcnt+1;
    elseif(strcmp(TypesVar{cnt},'TbBOOLEAN'))
      MinVar{cnt}=0;
      MaxVar{cnt}=1;
    elseif(strcmp(TypesVar{cnt},'TbBOOLEANT'))
      MinVar{cnt}=1;
      MaxVar{cnt}=1;
    elseif(strcmp(TypesVar{cnt},'TbBOOLEANF'))
      MinVar{cnt}=0;
      MaxVar{cnt}=0;
    end
    nextline=fgetl(finputsigsnames);
    cnt=cnt+1;
  end
  fclose(finputsigsnames);
  NoVars=0;
  if(exist('NamesVar','var'))
    NoVars=length(NamesVar);
    MinVals=zeros(NoVars,1);
    MaxVals=zeros(NoVars,1);  
    for i=1:NoVars,
      MinVals(i)=MinVar{i};    
      MaxVals(i)=MaxVar{i};
    end
  end
end