function [Output,tccov]=Fn_ExecuteATestCase(delphiModel,modelcompltname,testCase,ReportCov,InputTypesVar,externalinputname,externaloutputname,SimTime,SimStep)
    NoInputVars=size(testCase.dataValues,1);
    for i=1:NoInputVars,
      externalinputdata.signals(i)=Fn_MiLTester_CreateCustomStepSignal_SLDV(testCase.dataValues{i},testCase.timeValues,SimTime,SimStep);
      %externalinputdata.signals(i)=Fn_MiLTester_CreateCustomStepSignal(testCase.dataValues{i},testCase.timeValues,SimTime,SimStep);
      if(strcmp(InputTypesVar{i},'TbBOOLEAN') || strcmp(InputTypesVar{i},'TbBOOLEANF')|| strcmp(InputTypesVar{i},'TbBOOLEANT'))
        externalinputdata.signals(i).values=boolean(externalinputdata.signals(i).values);
      end
    end
    NoParams=size(testCase.paramValues,2);
    for parcnt=1:NoParams,
      if(delphiModel)
        eval(sprintf('tempvar=evalin(''base'',''%s'');',testCase.paramNames{parcnt}));
        eval(sprintf('tempvar.Value=%f;',testCase.paramValues(parcnt)));
        eval(sprintf('assignin(''base'',''%s'',tempvar);',testCase.paramNames{parcnt}));
      else
        eval(sprintf('assignin(''base'',''%s'',%d);',testCase.paramNames{parcnt},testCase.paramValues(parcnt)));
      end
    end
    externalinputdata.time=externalinputdata.signals(1).time;
    eval(sprintf('assignin(''base'',''%s'',%s);',externalinputname,'externalinputdata'));
    if(ReportCov)
      tccov=cvsim(cvtest(strrep(modelcompltname,'.mdl','')));
    else
      sim(modelcompltname);
    end
    eval(sprintf('NoOutputs=size(%s.signals,2);',externaloutputname));
    eval(sprintf('Output=zeros(NoOutputs,size(%s.time,1));',externaloutputname));
    for i=1:NoOutputs,
      eval(sprintf('Output(i,:)=%s.signals(i).values;',externaloutputname));
    end  
    eval(sprintf('clear %s;',externaloutputname));
end