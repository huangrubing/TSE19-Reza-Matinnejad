function []=Fn_WriteOutputs(NoOutputs,NoMutants,NoIterations,outputdirectory,mutantModelsList,OutputVariableNameVar,FBorVB,ResDists,ULDists,HighDistnacesOutputs)
 
  for ocnt=1:NoOutputs,
    thisoutputdirectory=sprintf('%s\\%s\\%s\\',outputdirectory,FBorVB,OutputVariableNameVar{ocnt});
    if(~exist(thisoutputdirectory,'dir'))
      mkdir(thisoutputdirectory)
    end
  end
% 
%   ULDistFileHeaderStr='';
%   for ocnt=1:NoOutputs,
%     if(ocnt==1)
%       ULDistFileHeaderStr=sprintf('%s',OutputNamesVar(1));
%     else
%       ULDistFileHeaderStr=sprintf('%s,%s',ULDistFileHeaderStr,OutputNamesVar(ocnt));
%     end
%   end



%   DistFileHeader=fopen(sprintf('%s\\AllDists_Header.dat',outputdirectory),'wt');
%   fprintf(DistFileHeader,'MutantName\n');
%   for m=1:NoMutants,
%     for k=1:NoTestCases,
%       fprintf(DistFileHeader,'%s\n',DMUT(m).name);
%     end
%   end
%   fclose(DistFileHeader);

%   HighestDistFileHeader=fopen(sprintf('%s\\HighestDists_Header.dat',outputdirectory),'wt');
%   fprintf(HighestDistFileHeader,'Time\n');
%   for i=0:NoSteps,
%     fprintf(HighestDistFileHeader,'%d\n',i*SimulationTimeStep);
%   end
%   fclose(HighestDistFileHeader);
  
%   HighestDistFileHeaderStr='';
%   for m=1:NoMutants,
%     if(m==1)
%       HighestDistFileHeaderStr=sprintf('ref_%s,%s',mutantModelsList(m).name,mutantModelsList(m).name);
%     else
%       HighestDistFileHeaderStr=sprintf('%s,ref_%s,%s',HighestDistFileHeaderStr,mutantModelsList(m).name,mutantModelsList(m).name);
%     end
%   end
%   HighestDistFileHeaderStr=sprintf('%s,%s',HighestDistFileHeaderStr,'Time');

  DistFileHeaderStr='';
  for m=1:NoMutants,
    if(m==1)
      DistFileHeaderStr=char(mutantModelsList(m).name);
    else
      DistFileHeaderStr=sprintf('%s,%s',DistFileHeaderStr,char(mutantModelsList(m).name));
    end
  end
  


  %DistFileHeaderStr=sprintf('%s,%s',DistFileHeaderStr,'Mutant');
  
%   if(exist('HighDistnacesOutputs','var'))
%     for ocnt=1:NoOutputs,
%       %Highest Distances
%       HighestDistFileName=sprintf('%s\\HighDistnacesOutputs_%s.dat',outputdirectory,OutputVariableNameVar{ocnt});
%       dlmwrite(HighestDistFileName,HighestDistFileHeaderStr,'');
%       dlmwrite(HighestDistFileName,squeeze(HighDistnacesOutputs(:,ocnt,:))','-append', 'delimiter',',', 'newline', 'pc');
%     end
%   end
%   if(ndims(AllDists)>2)
%     DistFileName=sprintf('%s\\AllDists.dat',outputdirectory);
%     dlmwrite(DistFileName,DistFileHeaderStr,'');
%     for m=1:NoMutants,
%       DistsCurMutant=squeeze(AllDists(m,:,:));
%       dlmwrite(DistFileName,DistsCurMutant,'-append', 'delimiter',',', 'newline', 'pc');  
%     end 
%     HighestDistFileName=sprintf('%s\\HighestDists.dat',outputdirectory);
%     dlmwrite(HighestDistFileName,DistFileHeaderStr,'');
%     for m=1:NoMutants
%       dlmwrite(HighestDistFileName,max(squeeze(AllDists(m,:,:))),'-append', 'delimiter',',', 'newline', 'pc');  
%     end
%   else
    for ocnt=1:NoOutputs,
      thisoutputdirectory=sprintf('%s\\%s\\%s\\',outputdirectory,FBorVB,OutputVariableNameVar{ocnt});
      ResDistFileName=sprintf('%s\\ResDists.dat',thisoutputdirectory);
      ULDistFileName=sprintf('%s\\ULDists.dat',thisoutputdirectory);
      dlmwrite(ResDistFileName,DistFileHeaderStr,'');
      dlmwrite(ULDistFileName,DistFileHeaderStr,'');
      for iter=1:NoIterations,
        dlmwrite(ResDistFileName,ResDists(:,iter,ocnt)','-append', 'delimiter',',', 'newline', 'pc');
        dlmwrite(ULDistFileName,ULDists(:,iter,ocnt)','-append', 'delimiter',',', 'newline', 'pc');
      end
    end
%   end  
 end