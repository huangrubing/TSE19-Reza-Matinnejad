function [NoMuts,MutModelNames,TestSuiteSizes]=Fn_ReadTestSuiteSizes(filesdirectory,CovMode)
   %read input singals names  (from workspace)
  
  ftestsuitesizes=fopen(sprintf('%s/%s',filesdirectory,sprintf('testsuitesizes_%s.txt',CovMode)),'rt');
  cnt=1;
  nextline=fgetl(ftestsuitesizes);
  while(ischar(nextline))
    nextline=textscan(nextline,'%s');
    varcnt=1;
    MutModelNames{cnt}=nextline{1}{varcnt};   
    varcnt=varcnt+1;
    TestSuiteSizesVar{cnt}=str2double(nextline{1}{varcnt});
    nextline=fgetl(ftestsuitesizes);
    cnt=cnt+1;
  end
  fclose(ftestsuitesizes);
 
  NoMuts=0;
  if(exist('TestSuiteSizesVar','var'))
    NoMuts=length(TestSuiteSizesVar);
    TestSuiteSizes=zeros(NoMuts,1);
    for i=1:NoMuts,
      TestSuiteSizes(i)=TestSuiteSizesVar{i};    
    end
  end
end