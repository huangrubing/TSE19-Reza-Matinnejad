function Fn_ConvertTestSuites(testSuite,xmlFilepath,outputName)

  tsNode = com.mathworks.xml.XMLUtils.createDocument('root_ts');
  tsRoot = tsNode.getDocumentElement;
  outputdirectory=sprintf('%s\\%s',xmlFilepath,outputName);
  if(~exist(outputdirectory,'dir'))
    mkdir(outputdirectory)
  end
  tsPath=sprintf('%s\\TestSuite.xml',outputdirectory);

  for tccnt=1:size(testSuite.TestCases,2),
    testcase=testSuite.TestCases(tccnt);

    nextTC=tsNode.createElement('TestCase');

    for icnt=1:size(testcase.inputNames,2),
      nextInput=tsNode.createElement('Input');

      nextVarName=tsNode.createElement('VarName');
      nextVarNameText=tsNode.createTextNode(testcase.inputNames{icnt});
      nextVarName.appendChild(nextVarNameText);
      nextInput.appendChild(nextVarName);

      nextType=tsNode.createElement('Type');
      nextTypeText=tsNode.createTextNode('Input');
      nextType.appendChild(nextTypeText);
      nextInput.appendChild(nextType);  
      if(~isfield(testcase,'timeRawValues'))
        segsNo=1;
      elseif(icnt>size(testcase.timeRawValues,1))
        segsNo=1;
      else
        segsNo=size(testcase.timeRawValues{icnt},2)+1;
      end
      
      nextSegsNo=tsNode.createElement('NoSegments');
      nextSegsNoText=tsNode.createTextNode(num2str(segsNo));
      nextSegsNo.appendChild(nextSegsNoText);
      nextInput.appendChild(nextSegsNo);  
      
      nextStepTime=tsNode.createElement('StepTime');
      nextStepTimeText=tsNode.createTextNode(num2str(testcase.timeValues(1)));
      nextStepTime.appendChild(nextStepTimeText);
      nextInput.appendChild(nextStepTime); 
      
      nextSegValue=tsNode.createElement('Value');
      nextSegValueText=tsNode.createTextNode(num2str(testcase.dataRawValues{icnt}(1)));
      nextSegValue.appendChild(nextSegValueText);
      nextInput.appendChild(nextSegValue);          
      
      for seg=1:segsNo-1,
        nextStepTime=tsNode.createElement('StepTime');
        nextStepTimeText=tsNode.createTextNode(num2str(testcase.timeRawValues{icnt}(seg)));
        nextStepTime.appendChild(nextStepTimeText);
        nextInput.appendChild(nextStepTime);  
 
        nextSegValue=tsNode.createElement('Value');
        nextSegValueText=tsNode.createTextNode(num2str(testcase.dataRawValues{icnt}(seg+1)));
        nextSegValue.appendChild(nextSegValueText);
        nextInput.appendChild(nextSegValue);          
      end
      nextStepTime=tsNode.createElement('StepTime');
      nextStepTimeText=tsNode.createTextNode(num2str(testcase.timeValues(end)));
      nextStepTime.appendChild(nextStepTimeText);
      nextInput.appendChild(nextStepTime);  

      nextSegValue=tsNode.createElement('Value');
      nextSegValueText=tsNode.createTextNode(num2str(testcase.dataRawValues{icnt}(segsNo)));
      nextSegValue.appendChild(nextSegValueText);
      nextInput.appendChild(nextSegValue);          

      nextTC.appendChild(nextInput);
    end
    
    
    for calcnt=1:size(testcase.paramNames,2),
      nextInput=tsNode.createElement('Input');

      nextVarName=tsNode.createElement('VarName');
      nextVarNameText=tsNode.createTextNode(testcase.paramNames{calcnt});
      nextVarName.appendChild(nextVarNameText);
      nextInput.appendChild(nextVarName);

      nextType=tsNode.createElement('Type');
      nextTypeText=tsNode.createTextNode('Calibration');
      nextType.appendChild(nextTypeText);
      nextInput.appendChild(nextType);  

      nextValue=tsNode.createElement('Value');
      nextValueText=tsNode.createTextNode(num2str(testcase.paramValues(calcnt)));
      nextValue.appendChild(nextValueText);
      nextInput.appendChild(nextValue);        
      
      nextTC.appendChild(nextInput);
    end

    tsRoot.appendChild(nextTC);
  end
  
  xmlwrite(tsPath,tsNode);
end

function blckname=Fn_GetBlockName(cvdisstr)

  strtindx=strfind(cvdisstr,'cvdisplay');
  index1=strfind(cvdisstr(strtindx:end),'>');
  index2=strfind(cvdisstr(strtindx:end),'<');
  blckname=cvdisstr(index1(1)+strtindx:index2(1)+strtindx-2);
end

 function convstr=Fn_ReplaceCVDisp(cvdisstr,parentblock,block)

  strtindx=strfind(cvdisstr,'cvdisplay');
  indexend=strfind(cvdisstr(strtindx:end),')');
  hilightstr=sprintf('hilite_system(''%s/%s'')',parentblock,block);
  convstr=strrep(cvdisstr,cvdisstr(strtindx:indexend(1)+strtindx-1),hilightstr);
 end

 function parentpath=Fn_GetParentPath(parentstr)

  indexstart=strfind(parentstr,'>');
  indexend=strfind(parentstr,'<');
  parentpath=parentstr(indexstart(2)+1:indexend(3)-1);
  if(parentpath(1)=='/')
    parentpath=parentpath(2:end);
  end
end

