function [MutOutputs]=Fn_ReadMutOutputFile(filesdirectory,NoMutants,NoOutputVars)
  
  MutOutputs=zeros(NoMutants,NoOutputVars);
  
  fmutoutputs=fopen(sprintf('%s/%s',filesdirectory,'mutoutputs.txt'),'rt');
  m=1;
  nextline=fgetl(fmutoutputs);
  while(ischar(nextline))
    nextline=textscan(nextline,'%s');
    varcnt=1;
    for ocnt=1:NoOutputVars,
      MutOutputs(m,ocnt)=str2double(nextline{1}{varcnt});  
      if(MutOutputs(m,ocnt)>0)
        MutOutputs(m,ocnt)=1;
      end
      varcnt=varcnt+1;
    end  
    m=m+1;
    nextline=fgetl(fmutoutputs);
  end
  fclose(fmutoutputs); 
end