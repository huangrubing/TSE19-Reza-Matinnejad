function []=Fn_WriteOutputs(NoOutputs,NoMutants,NoTestCases,NoSteps,outputdirectory,OutputVariableNameVar,SimulationTimeStep,DMUT,AllDists,HighDistnacesOutputs)
 
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
%       HighestDistFileHeaderStr=sprintf('ref_%s,%s',DMUT(m).name,DMUT(m).name);
%     else
%       HighestDistFileHeaderStr=sprintf('%s,ref_%s,%s',HighestDistFileHeaderStr,DMUT(m).name,DMUT(m).name);
%     end
%   end
%   HighestDistFileHeaderStr=sprintf('%s,%s',HighestDistFileHeaderStr,'Time');

  DistFileHeaderStr='';
  for ocnt=1:NoOutputs,
    if(ocnt==1)
      DistFileHeaderStr=char(OutputVariableNameVar(ocnt));
    else
      DistFileHeaderStr=sprintf('%s,%s',DistFileHeaderStr,char(OutputVariableNameVar(ocnt)));
    end
  end
  DistFileHeaderStr=sprintf('%s,%s',DistFileHeaderStr,'Mutant');
  
  if(exist('HighDistnacesOutputs','var'))
    for ocnt=1:NoOutputs,
      %Highest Distances
      HighestDistFileName=sprintf('%s\\HighDistnacesOutputs_%s.dat',outputdirectory,OutputVariableNameVar{ocnt});
      dlmwrite(HighestDistFileName,HighestDistFileHeaderStr,'');
      dlmwrite(HighestDistFileName,squeeze(HighDistnacesOutputs(:,ocnt,:))','-append', 'delimiter',',', 'newline', 'pc');
    end
  end
  if(ndims(AllDists)>2)
    DistFileName=sprintf('%s\\AllDists.dat',outputdirectory);
    dlmwrite(DistFileName,DistFileHeaderStr,'');
    for m=1:NoMutants,
      DistsCurMutant=squeeze(AllDists(m,:,:));
      dlmwrite(DistFileName,DistsCurMutant,'-append', 'delimiter',',', 'newline', 'pc');  
    end 
    HighestDistFileName=sprintf('%s\\HighestDists.dat',outputdirectory);
    dlmwrite(HighestDistFileName,DistFileHeaderStr,'');
    for m=1:NoMutants
      dlmwrite(HighestDistFileName,max(squeeze(AllDists(m,:,:))),'-append', 'delimiter',',', 'newline', 'pc');  
    end
  else
    HighestDistFileName=sprintf('%s\\HighestDists.dat',outputdirectory);
    dlmwrite(HighestDistFileName,DistFileHeaderStr,'');
    for m=1:NoMutants
      dlmwrite(HighestDistFileName,AllDists(m,:),'-append', 'delimiter',',', 'newline', 'pc');  
    end   
  end  
 end