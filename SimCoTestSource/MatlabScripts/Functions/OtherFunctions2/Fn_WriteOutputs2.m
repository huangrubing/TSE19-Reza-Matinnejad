function []=Fn_WriteOutputs2(NoOutputs,NoMutants,NoTestCases,outputdirectory,mutantModelsList,OutputNamesVar,AllDists)
 

  DistFileHeader=fopen(sprintf('%s\\AllDists_Header.dat',outputdirectory),'wt');
  fprintf(DistFileHeader,'MutantName\n');
  for m=1:NoMutants,
    for k=1:NoTestCases,
      fprintf(DistFileHeader,'%s\n',mutantModelsList(m).name);
    end
  end
  fclose(DistFileHeader);

  DistFileHeaderStr='';
  for ocnt=1:NoOutputs,
    if(ocnt==1)
      DistFileHeaderStr=sprintf('%d.%s',ocnt,char(OutputNamesVar(ocnt)));
    else
      DistFileHeaderStr=sprintf('%s,%d.%s',DistFileHeaderStr,ocnt,char(OutputNamesVar(ocnt)));
    end
  end
  DistFileHeaderStr=sprintf('%s,%s',DistFileHeaderStr,'Mutant');
  
%   if(exist('HighDistnacesOutputs','var'))
%     for ocnt=1:NoOutputs,
%       %Highest Distances
%       HighestDistFileName=sprintf('%s\\HighDistnacesOutputs_%s.dat',outputdirectory,OutputVariableNameVar{ocnt});
%       dlmwrite(HighestDistFileName,HighestDistFileHeaderStr,'');
%       dlmwrite(HighestDistFileName,squeeze(HighDistnacesOutputs(:,ocnt,:))','-append', 'delimiter',',', 'newline', 'pc');
%     end
%  end
  if(ndims(AllDists)>2)
    DistFileName=sprintf('%sAllDists.dat',outputdirectory);
    dlmwrite(DistFileName,DistFileHeaderStr,'');
    for m=1:NoMutants,
      DistsCurMutant=squeeze(AllDists(m,:,:));
      dlmwrite(DistFileName,DistsCurMutant,'-append', 'delimiter',',', 'newline', 'pc');  
    end 
    %HighestDistFileName=sprintf('%s\\HighestDists.dat',outputdirectory);
    %dlmwrite(HighestDistFileName,DistFileHeaderStr,'');
    %for m=1:NoMutants
    %  dlmwrite(HighestDistFileName,max(squeeze(AllDists(:,m,:))),'-append', 'delimiter',',', 'newline', 'pc');  
    %end
  end  
 end