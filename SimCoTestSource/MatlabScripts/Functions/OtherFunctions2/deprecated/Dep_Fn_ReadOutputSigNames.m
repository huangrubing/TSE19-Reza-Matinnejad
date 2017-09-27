function [NoOutputVars,OutputNamesVar,OutputTypesVar,OututMinVals,OutputMaxVals]=Dep_Fn_ReadOutputSigNames(filesdirectory)
   %read output singals names  (from workspace)
  
  foutputsigsnames=fopen(sprintf('%s/%s',filesdirectory,'outputsigsnames.txt'),'rt');
  cnt=1;
  nextline=fgetl(foutputsigsnames);
  while(ischar(nextline))
    nextline=textscan(nextline,'%s');
    varcnt=1;
    OutputNamesVar{cnt}=nextline{1}{varcnt};
    varcnt=varcnt+1;
    OutputTypesVar{cnt}=nextline{1}{varcnt};
    varcnt=varcnt+1;
    if(strcmp(OutputTypesVar{cnt},'f'))
      OututMinVals(cnt)=str2double(nextline{1}{varcnt});
      varcnt=varcnt+1;
      OutputMaxVals(cnt)=str2double(nextline{1}{varcnt});
    end    
    nextline=fgetl(foutputsigsnames);
    cnt=cnt+1;
  end
  fclose(foutputsigsnames);
 
  NoOutputVars=0;
  if(exist('OutputNamesVar','var'))
    NoOutputVars=length(OutputNamesVar);
  end
end