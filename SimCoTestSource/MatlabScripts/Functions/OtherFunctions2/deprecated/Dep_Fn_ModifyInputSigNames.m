function []=Dep_Fn_ModifyInputSigNames(filesdirectory,InputMaxStepVals)
   %read input singals names  (from workspace)
  [NoInputVars,InputNamesVar,InputTypesVar,InputMinVals,InputMaxVals,EmptyInputMaxStepVals]=Fn_ReadInputSigNames(filesdirectory);
  finputsigsnames=fopen(sprintf('%s\\%s',filesdirectory,'inputsigsnames.txt'),'wt');
  for i=1:NoInputVars,
    if(strcmp(InputTypesVar{i},'TbBOOLEAN'))
      fprintf(finputsigsnames,'%s %s %d\n',InputNamesVar{i},InputTypesVar{i},InputMaxStepVals(i));
    else
     fprintf(finputsigsnames,'%s %s %d %d %d\n',InputNamesVar{i},InputTypesVar{i},InputMinVals(i),InputMaxVals(i),InputMaxStepVals(i));
    end
  end
  fclose(finputsigsnames);
end