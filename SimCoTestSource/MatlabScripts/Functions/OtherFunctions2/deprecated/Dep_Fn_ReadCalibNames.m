function [NoCalibs,CalNamesVar,CalTypesVar,CalMinVals,CalMaxVals]=Dep_Fn_ReadCalibNames(filesdirectory,inputfilename)
  
  %read calibration names
  fcalibnames=fopen(sprintf('%s/%s',filesdirectory,inputfilename),'rt');
  cnt=1;
  nextline=fgetl(fcalibnames);
  while(ischar(nextline))
    nextline=textscan(nextline,'%s');  
    varcnt=1;
    CalNamesVar{cnt}=nextline{1}{varcnt};
    varcnt=varcnt+1;
    CalTypesVar{cnt}=nextline{1}{varcnt};
    varcnt=varcnt+1;
    if(strcmp(CalTypesVar{cnt},'f'))
      CalMinVar{cnt}=str2double(nextline{1}{varcnt});
      varcnt=varcnt+1;
      CalMaxVar{cnt}=str2double(nextline{1}{varcnt});
    elseif(strcmp(CalTypesVar{cnt},'e'))
      CalMinVar{cnt}=str2double(nextline{1}{varcnt})-0.499;
      varcnt=varcnt+1;
      CalMaxVar{cnt}=str2double(nextline{1}{varcnt})+0.499;
    elseif(strcmp(CalTypesVar{cnt},'TbBOOLEAN'))
      CalMinVar{cnt}=0;
      CalMaxVar{cnt}=1;
    end    
    nextline=fgetl(fcalibnames);
    cnt=cnt+1;
  end
  fclose(fcalibnames); 
  NoCalibs=0;
  if(exist('CalNamesVar','var'))
    NoCalibs=length(CalNamesVar);
    CalMinVals=zeros(NoCalibs,1);
    CalMaxVals=zeros(NoCalibs,1);  
    for i=1:NoCalibs,
      CalMinVals(i)=CalMinVar{i};    
      CalMaxVals(i)=CalMaxVar{i};
    end 
  end
end