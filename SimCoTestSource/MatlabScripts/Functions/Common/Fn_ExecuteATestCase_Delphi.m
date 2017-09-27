function [Output,tccov,outsigtime]=Fn_ExecuteATestCase_Delphi(delphiModel,modelcompltname,testCase,ReportCov,InputTypesVar,externalinputname,externaloutputname,SimTime,SimStep,InputTypesModeVar,IsSignedVal,WordLengthVal,SlopeVal,BiasVal,FractionLengthVal)

  tccov=0;
  NoInputVars=size(testCase.dataValues,1);
  for i=1:NoInputVars,
    externalinputdata.signals(i)=Fn_MiLTester_CreateCustomStepSignal_SLDV(testCase.dataValues{i},testCase.timeValues,SimTime,SimStep);
    if(strcmp(InputTypesVar{i},'TbBOOLEAN') || strcmp(InputTypesVar{i},'boolean') || strcmp(InputTypesVar{i},'TbBOOLEANT') || strcmp(InputTypesVar{i},'TbBOOLEANF') )
      externalinputdata.signals(i).values=boolean(externalinputdata.signals(i).values);
    elseif(strcmp(InputTypesVar{i},'e'))
      externalinputdata.signals(i).values=fi(externalinputdata.signals(i).values,0,8,0);
    else
      if(strcmp(InputTypesModeVar{i},'Slope'))
        externalinputdata.signals(i).values=fi(externalinputdata.signals(i).values,IsSignedVal(i),WordLengthVal(i),SlopeVal(i),BiasVal(i));
      else
        externalinputdata.signals(i).values=fi(externalinputdata.signals(i).values,IsSignedVal(i),WordLengthVal(i),FractionLengthVal(i));
      end
    end
  end
  NoParams=size(testCase.paramValues,2);
  for parcnt=1:NoParams,
    if(delphiModel)
      eval(sprintf('tempvar=evalin(''base'',''%s'');',testCase.paramNames{parcnt}));
      if(strcmp(tempvar.DataType,'boolean'))
        eval(sprintf('tempvar.Value=boolean(%f);',testCase.paramValues(parcnt)));      
      else
        eval(sprintf('tempvar.Value=%f;',testCase.paramValues(parcnt)));
      end    
      eval(sprintf('assignin(''base'',''%s'',tempvar);',testCase.paramNames{parcnt}));
    else
      eval(sprintf('assignin(''base'',''%s'',%d);',testCase.paramNames{parcnt},testCase.paramValues(parcnt)));
    end
  end
  externalinputdata.time=externalinputdata.signals(1).time;
  eval(sprintf('assignin(''base'',''%s'',%s);',externalinputname,'externalinputdata'));
  if(ReportCov)
    testobj=cvtest(strrep(modelcompltname,'.mdl',''));
    testobj.settings.decision = 1;
    tccov=cvsim(testobj);
  else
    sim(modelcompltname);
  end
  %NoOneDimOutupus=
  eval(sprintf('NoOutputs=size(%s.signals,2);',externaloutputname));
  eval(sprintf('Output=zeros(NoOutputs,size(%s.time,1));',externaloutputname));
  eval(sprintf('outsigtime=%s.time;',externaloutputname));
  cntOut=0;
  for i=1:NoOutputs,
    if(eval(sprintf('%s.signals(i).dimensions==1',externaloutputname)))
      cntOut=cntOut+1;
      eval(sprintf('Output(cntOut,:)=%s.signals(i).values;',externaloutputname));
    end
  end  
  clear externalinputdata;
  eval(sprintf('clear %s;',externalinputname));
  eval(sprintf('clear %s;',externaloutputname));
  Output=Output(1:cntOut,:);
end