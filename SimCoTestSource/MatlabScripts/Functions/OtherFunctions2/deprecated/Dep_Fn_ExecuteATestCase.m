function [Output]=Dep_Fn_ExecuteATestCase(orgmodelcompltname,testCase,InputTypesVar,externalinputname,externaloutputname,SimTime,SimStep)
    NoInputVars=size(testCase.dataValues,1);
    for i=1:NoInputVars,
      externalinputdata.signals(i)=Fn_MiLTester_CreateCustomStepSignal_SLDV(testCase.dataValues{i},testCase.timeValues,SimTime,SimStep);
      if(strcmp(InputTypesVar{i},'TbBOOLEAN') || strcmp(InputTypesVar{i},'TbBOOLEANF')|| strcmp(InputTypesVar{i},'TbBOOLEANT'))
         externalinputdata.signals(i).values=boolean(externalinputdata.signals(i).values);
      end
    end
    
    NoParams=size(testCase.paramValues,2);
    for parcnt=1:NoParams,
      eval(sprintf('assignin(''base'',''%s'',%d);',testCase.paramNames{parcnt},testCase.paramValues(parcnt)));
    end

    externalinputdata.time=externalinputdata.signals(1).time;
    eval(sprintf('assignin(''base'',''%s'',%s);',externalinputname,'externalinputdata'));
    sim(orgmodelcompltname);
    eval(sprintf('NoOutputs=size(%s.signals,2);',externaloutputname));
    eval(sprintf('Output=zeros(NoOutputs,size(%s.time,1));',externaloutputname));
    for i=1:NoOutputs,
      eval(sprintf('Output(i,:)=%s.signals(i).values;',externaloutputname));
    end  
    eval(sprintf('clear %s;',externaloutputname));
end