function [NoVars,NamesVar,TypesVar,MinVals,MaxVals,InputTypesModeVar,IsSignedVal,WordLengthVal,FractionLengthVal,SlopeVal,BiasVal]=Fn_ReadExtractInfo(filesdirectory,xmlfilename,varidnetifier)

  
  xDoc = xmlread(sprintf('%s%s',filesdirectory,xmlfilename));
  xRoot = xDoc.getDocumentElement;
  childNodes = xRoot.getChildNodes;
  numChildNodes = childNodes.getLength;
  
  cnt=1;
  for count = 1:numChildNodes,
    theChild = childNodes.item(count-1);
    if(strcmp(char(theChild.getNodeName),varidnetifier))
      inputChildNodes = theChild.getChildNodes;
      numInputChildNodes = inputChildNodes.getLength;
      for count2 = 1:numInputChildNodes,
        theAttr = inputChildNodes.item(count2-1);
        if(strcmp(char(theAttr.getNodeName),'Name'))
          valNode = theAttr.getChildNodes;
          NamesVar{cnt}=char(valNode.item(0).getNodeValue);
          SlopeVar{cnt}=0;
          BiasVar{cnt}=0;
        elseif(strcmp(char(theAttr.getNodeName),'DataTypeName'))
          valNode = theAttr.getChildNodes;
          TypesVar{cnt}=char(valNode.item(0).getNodeValue);
          if(strcmp(TypesVar{cnt},'enum'))
            TypesVar{cnt}='e';
            IsSignedVar{cnt}=0;
            WordLengthVar{cnt}=0;
            FractionLengthVar{cnt}=0;
            InputTypesModeVar{cnt}='NA'; 
          elseif(strcmp(TypesVar{cnt},'TbBOOLEAN'))
            MinVar{cnt}=0;
            MaxVar{cnt}=1;
            IsSignedVar{cnt}=0;
            WordLengthVar{cnt}=0;
            FractionLengthVar{cnt}=0;
            InputTypesModeVar{cnt}='NA'; 
          elseif(~strcmp(TypesVar{cnt},'TbBOOLEAN'))
            TypesVar{cnt}='f';
          end
        elseif(strcmp(char(theAttr.getNodeName),'DataTypeMode'))
          valNode = theAttr.getChildNodes;
          InputTypesModeVar{cnt}=char(valNode.item(0).getNodeValue); 
        elseif(strcmp(char(theAttr.getNodeName),'IsSigned'))
          valNode = theAttr.getChildNodes;
          IsSignedVar{cnt}=str2num(valNode.item(0).getNodeValue);
        elseif(strcmp(char(theAttr.getNodeName),'WordLength'))
          valNode = theAttr.getChildNodes;
          WordLengthVar{cnt}=str2num(valNode.item(0).getNodeValue);
       elseif(strcmp(char(theAttr.getNodeName),'Slope'))
          valNode = theAttr.getChildNodes;
          SlopeVar{cnt}=str2num(valNode.item(0).getNodeValue);
       elseif(strcmp(char(theAttr.getNodeName),'Bias'))
          valNode = theAttr.getChildNodes;
          BiasVar{cnt}=str2num(valNode.item(0).getNodeValue);  
        elseif(strcmp(char(theAttr.getNodeName),'FractionLength'))
          valNode = theAttr.getChildNodes;
          FractionLengthVar{cnt}=str2num(valNode.item(0).getNodeValue);
        elseif(strcmp(char(theAttr.getNodeName),'MinVal'))
          display(char(theAttr.getNodeName));
          valNode = theAttr.getChildNodes;
          MinVar{cnt}=str2num(valNode.item(0).getNodeValue);
        elseif(strcmp(char(theAttr.getNodeName),'MaxVal'))
          valNode = theAttr.getChildNodes;
          MaxVar{cnt}=str2num(valNode.item(0).getNodeValue);
        end
      end
      cnt=cnt+1;
    end
  end
  
  NoVars=0;
  if(exist('NamesVar','var'))
    NoVars=length(NamesVar);
    MinVals=zeros(NoVars,1);
    MaxVals=zeros(NoVars,1);
    IsSignedVal=zeros(NoVars,1);
    WordLengthVal=zeros(NoVars,1);
    SlopeVal=zeros(NoVars,1);
    BiasVal=zeros(NoVars,1);
    FractionLengthVal=zeros(NoVars,1);    
    for i=1:NoVars,
      MinVals(i)=MinVar{i};    
      MaxVals(i)=MaxVar{i};
      IsSignedVal(i)=IsSignedVar{i};
      WordLengthVal(i)=WordLengthVar{i};
      SlopeVal(i)=SlopeVar{i};   
      BiasVal(i)=BiasVar{i};   
      FractionLengthVal(i)=FractionLengthVar{i};      
    end
  end
end