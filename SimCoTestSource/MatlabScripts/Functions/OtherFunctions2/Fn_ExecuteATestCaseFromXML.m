function Fn_ExecuteATestCaseFromXML(modelcompltname,filesdirectory,testSuiteFilepath,dsrdTCNo,SimTime,SimStep,OutputName,OutputIndex)

  %curTimeValues=repmat(SimTime,NoInputVars,max(TestSuiteComplexity(tccnt,:)));
  
  xDoc = xmlread(sprintf('%s\\TestSuite.xml',testSuiteFilepath));
  xRoot = xDoc.getDocumentElement;
  childNodes = xRoot.getChildNodes;
  numChildNodes = childNodes.getLength;

  tccnt=0;
  for count = 1:numChildNodes,
    theChild = childNodes.item(count-1);
    if(strcmp(char(theChild.getNodeName),'TestCase'))
      tccnt=tccnt+1;
      if(tccnt~=dsrdTCNo)
        continue;
      end
      icnt=0;
      parcnt=0;
      inputChildNodesTemp = theChild.getChildNodes;
      numInputChildNodesTemp = inputChildNodesTemp.getLength;
      for countTemp = 1:numInputChildNodesTemp,
        theAttrTemp = inputChildNodesTemp.item(countTemp-1);
        if(strcmp(char(theAttrTemp.getNodeName),'Input'))
          inputChildNodes = theAttrTemp.getChildNodes;
          numInputChildNodes = inputChildNodes.getLength;
          for count2 = 1:numInputChildNodes,
            theAttr = inputChildNodes.item(count2-1);
            if(strcmp(char(theAttr.getNodeName),'VarName'))
              valNode = theAttr.getChildNodes;
              VarName=char(valNode.item(0).getNodeValue);
            elseif(strcmp(char(theAttr.getNodeName),'Type'))
              valNode = theAttr.getChildNodes;
              VarType=char(valNode.item(0).getNodeValue);
              if(strcmp(VarType,'Input'))
                icnt=icnt+1;
              elseif(strcmp(VarType,'Calibration'))
                parcnt=parcnt+1;
              end
            elseif(strcmp(char(theAttr.getNodeName),'NoSegments'))
              valNode = theAttr.getChildNodes;
              %NoSegs=char(valNode.item(0).getNodeValue);
              timesegcnt=0;
              valsegcnt=0;
            elseif(strcmp(char(theAttr.getNodeName),'StepTime'))
              timesegcnt=timesegcnt+1;
              valNode = theAttr.getChildNodes;
              timeSeg=char(valNode.item(0).getNodeValue);
              curTimeValuesCells{icnt,timesegcnt}=str2num(timeSeg);
            elseif(strcmp(char(theAttr.getNodeName),'Value'))
              valNode = theAttr.getChildNodes;
              VarValue=char(valNode.item(0).getNodeValue);  
              if(strcmp(VarType,'Input'))
                valsegcnt=valsegcnt+1;
                if(valsegcnt==1)
                  testCase.dataValues{icnt,1}=str2num(VarValue);
                else
                  testCase.dataValues{icnt,1}=[testCase.dataValues{icnt,1}, str2num(VarValue)];
                end
                testCase.dataNames{icnt}=VarName;
              elseif(strcmp(VarType,'Calibration'))
                testCase.paramNames{parcnt}=VarName;
                ParameterValues{parcnt}=str2num(VarValue);
              end
            end
          end
        end
      end
      testCase.paramValues=zeros(1,parcnt);
      for j=1:parcnt,
        testCase.paramValues(j)=ParameterValues{j};
      end
      break;
    end
  end

  
  curTimeValues=zeros(size(curTimeValuesCells,1),size(curTimeValuesCells,2)-1);
  for i=1:size(curTimeValuesCells,1),
    for j=2:size(curTimeValuesCells,2),
      if(~isempty(curTimeValuesCells{i,j}))
        curTimeValues(i,j-1)=curTimeValuesCells{i,j};
      else
        curTimeValues(i,j-1)=SimTime;
      end
    end
  end
 
  NoInputVars=icnt;
  testCase.timeValues=sort(unique([curTimeValues(:)',0,SimTime]));
  for icnt=1:NoInputVars,
    curDataValues=testCase.dataValues{icnt,1};
    l=1;
    for k=1:size(testCase.timeValues,2),
      if(testCase.timeValues(k)>=curTimeValues(icnt,l) && ...
          testCase.timeValues(k)~=SimTime)
        l=l+1;
      end
      if(k==1)
        testCase.dataValues{icnt,1}=curDataValues(l);
      else
        testCase.dataValues{icnt,1}=[testCase.dataValues{icnt,1}, curDataValues(l)];
      end
    end
  end

  [NoInputVars,InputNamesVar,InputTypesVar,InputMinVals,InputMaxVals,InputTypesModeVar,IsSignedVal,WordLengthVal,FractionLengthVal,SlopeVal,BiasVal]=Fn_ReadExtractInfo(filesdirectory,'ExtractInfo.xml','Input');
  [NoCalibs,CalNamesVar,CalTypesVar,CalMinVals,CalMaxVals,CalTypesModeVar,CalsIsSignedVal,CalsWordLengthVal,CalsFractionLengthVal,CalsSlopeVal,CalsBiasVal]=Fn_ReadExtractInfo(filesdirectory,'ExtractInfo.xml','Calib');
  [NoOutputs,OutputNamesVar,OutputTypesVar,OutputMinVals,OutputMaxVals]=Fn_ReadExtractInfo(filesdirectory,'ExtractInfo.xml','Output');

  delphiModel=true;
  ReportCov=0;
  externalinputname='externalinputdata';
  externaloutputname='yout';

  [Output,~,tout]=Fn_ExecuteATestCase_Delphi(delphiModel,modelcompltname,testCase,ReportCov,InputTypesVar,externalinputname,...
    externaloutputname,SimTime,SimStep,InputTypesModeVar,IsSignedVal,WordLengthVal,SlopeVal,BiasVal,FractionLengthVal);
  plot(tout,Output(OutputIndex,:));
  title(sprintf('TestCases-%d',dsrdTCNo))
  xlabel('time')
  ylabel(OutputName)
end