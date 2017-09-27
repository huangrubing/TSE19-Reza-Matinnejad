function []=Fn_WriteOutputs(NoOutputs,NoMutants,NoIterations,outputdirectory,mutantModelsList,OutputVariableNameVar,FBorVB,ResDists,ULDists,CovMode)
 
  for ocnt=1:NoOutputs,
    thisoutputdirectory=sprintf('%s\\%s\\%s\\',outputdirectory,FBorVB,OutputVariableNameVar{ocnt});
    if(~exist(thisoutputdirectory,'dir'))
      mkdir(thisoutputdirectory)
    end
  end
  
  DistFileHeaderStr='';
  for m=1:NoMutants,
    if(m==1)
      DistFileHeaderStr=char(mutantModelsList(m).name);
    else
      DistFileHeaderStr=sprintf('%s,%s',DistFileHeaderStr,char(mutantModelsList(m).name));
    end
  end
   
  for ocnt=1:NoOutputs,
    thisoutputdirectory=sprintf('%s\\%s\\%s\\',outputdirectory,FBorVB,OutputVariableNameVar{ocnt});
    ResDistFileName=sprintf('%s\\ResDists_%s.dat',thisoutputdirectory,CovMode);
    ULDistFileName=sprintf('%s\\ULDists_%s.dat',thisoutputdirectory,CovMode);
    dlmwrite(ResDistFileName,DistFileHeaderStr,'');
    dlmwrite(ULDistFileName,DistFileHeaderStr,'');
    for iter=1:NoIterations,
      dlmwrite(ResDistFileName,ResDists(:,iter,ocnt)','-append', 'delimiter',',', 'newline', 'pc');
      dlmwrite(ULDistFileName,ULDists(:,iter,ocnt)','-append', 'delimiter',',', 'newline', 'pc');
    end
  end
 end