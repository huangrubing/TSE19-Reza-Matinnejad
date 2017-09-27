function []=Fn_WriteTestSuiteSizes(NoMutants,filesdirectory,DMUT,TestSuiteSizes,CovMode)
 
  fTestSuiteSizes=fopen(sprintf('%s/testsuitesizes_%s.txt',filesdirectory,CovMode),'wt');
  for m=1:NoMutants,
    fprintf(fTestSuiteSizes,'%s %d\n',DMUT(m).name,TestSuiteSizes(m));   
  end
  fclose(fTestSuiteSizes);
end