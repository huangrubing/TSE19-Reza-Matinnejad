try
  close_system(find_system);
  orgmodelname='[MiLTester_ModelComltName]';
  %orgmodelname='scpc';
  delphiModel=true;
  orgmodelpath='[MiLTester_SimulinkModelPathVal]';

  %method options
  %method='random';
  method='search';
  %distancemethod='vector';
  %distancemethod='features';
  %distancemethod='random';
  
  
  addpath(genpath('[MiLTester_CodeRootVal]\Functions'));
  addpath('[MiLTester_CodeRootVal]\Functions\Common');
  run('SC_MiLTester_ModelSettingsScript');
  close_system(find_system()); 
  addpath(orgmodelpath);

  filesdirectory=sprintf('%s\\%s-Files\\',orgmodelpath,orgmodelname);
  
  [NoInputVars,InputNamesVar,InputTypesVar,InputMinVals,InputMaxVals,InputTypesModeVar,IsSignedVal,WordLengthVal,FractionLengthVal,SlopeVal,BiasVal]=Fn_ReadExtractInfo(filesdirectory,'ExtractInfo.xml','Input');
  [NoCalibs,CalNamesVar,CalTypesVar,CalMinVals,CalMaxVals,CalTypesModeVar,CalsIsSignedVal,CalsWordLengthVal,CalsFractionLengthVal,CalsSlopeVal,CalsBiasVal]=Fn_ReadExtractInfo(filesdirectory,'ExtractInfo.xml','Calib');
  [NoOutputs,OutputNamesVar,OutputTypesVar,OutputMinVals,OutputMaxVals]=Fn_ReadExtractInfo(filesdirectory,'ExtractInfo.xml','Output');
  
  [InputMaxVals]=Fn_ChangedFixedPointMaxVals(NoInputVars,InputMaxVals,InputTypesVar,InputTypesModeVar,FractionLengthVal);
  [CalMaxVals]=Fn_ChangedFixedPointMaxVals(NoCalibs,CalMaxVals,CalTypesVar,CalTypesModeVar,CalsFractionLengthVal);



  TestSuitSizes=1;
  TestSuiteComplexity=zeros(TestSuitSizes,NoInputVars);
  TestSuiteComplexity(:)=2;
  %TestSuiteComplexity(:,11:15)=3;
  %TestSuiteComplexity(:,16:NoInputVars)=1;
  TestSuiteComplexityAllVB=zeros(NoOutputs,TestSuitSizes,NoInputVars);
  TestSuiteComplexityAllFB=zeros(NoOutputs,TestSuitSizes,NoInputVars);
  load_system(orgmodelname);

  SimTime=Fn_MiLTester_GetSimulationTime();
  SimStep=Fn_MiLTester_GetSimulationTimeStep();
  NoSteps=(SimTime/SimStep);
  outputdirectory=sprintf('%s\\Outputs\\',filesdirectory);
  if(~exist(outputdirectory,'dir'))
    mkdir(outputdirectory)
  end
  CfSBPC_t_CLUTCH_SAMPLETIME.Value=SimStep;
  CfSBPC_t_CLUTCHCTRL_LOOPTIME.Value=SimStep;
  CfSBPC_t_PRESRATIOCTRL_SAMPLETIME.Value=SimStep;
  CfSBPC_t_PRESRATIOCTRL_SAMPLETIME.Value=SimStep;
  CfSBPC_t_PRESRATIOCTRL_SAMPLETIME.Value=SimStep;
  
  NoSteps=(SimTime/SimStep);
  AlgIterations=1;
  TestSuiteVBCov=zeros(AlgIterations,NoOutputs);
  TestSuiteFBCov=zeros(AlgIterations,NoOutputs);
  
  TimeOutOrgVB=400/1.5;
  TimeOutOrgFB=1.5*TimeOutOrgVB;

  TweakSigmaExploration=0.5;
  TweakSigmaExploitation=0.05;
  %main loop on the model mutants 
  if(strcmp(method,'search')==1)
    TimeOutVB=TimeOutOrgVB;
    TimeOutFB=TimeOutOrgFB;
  end

  load_system(orgmodelname);
  TweakSigmaVB=zeros(NoOutputs,1);
  TweakSigmaFB=zeros(NoOutputs,1);
  for iter=1:AlgIterations,
    for ocnt=1:NoOutputs,
      TestSuiteComplexityAllVB(ocnt,:)=TestSuiteComplexity(:);
      TestSuiteComplexityAllFB(ocnt,:)=TestSuiteComplexity(:);
    end
    testsuite=Fn_GenerateARandomTestSuite(NoInputVars,InputNamesVar,InputTypesVar,InputMinVals,InputMaxVals,reshape(TestSuiteComplexityAllVB(1,:,:),[size(TestSuiteComplexityAllVB,2) size(TestSuiteComplexityAllVB,3)]),TestSuitSizes,SimTime,SimStep);
    testsuite=Fn_CompleteARandomTestSuiteWithCalibs(testsuite,NoCalibs,CalNamesVar,CalTypesVar,CalMinVals,CalMaxVals);
    MaxTestSuiteODVB=zeros(NoOutputs,1);
    MaxTestSuiteODFB=zeros(NoOutputs,1);
    inittscovvalVB=zeros(NoOutputs,1);
    inittscovvalFB=zeros(NoOutputs,1);

    for ocnt=1:NoOutputs,
      TweakSigmaVB(ocnt)=TweakSigmaExploration;
      TweakSigmaFB(ocnt)=TweakSigmaExploration;
      cursolutionVB{ocnt}=testsuite;
      cursolutionFB{ocnt}=testsuite;
      bestsolutionVB{ocnt}=testsuite;
      bestsolutionFB{ocnt}=testsuite;
    end  
    tic;
    LoopCnt=1;
    while(LoopCnt<200)
      if(strcmp(method,'search')==1)
        for ocnt=1:NoOutputs,
          if(ocnt==1)
            testsuite=cursolutionVB{ocnt};
            [TestSuiteOutput,tscov]=Fn_ExecuteATestSuite_Delphi(delphiModel,orgmodelname,testsuite,true,InputTypesVar,NoSteps,NoOutputs,SimTime,SimStep,InputTypesModeVar,IsSignedVal,WordLengthVal,SlopeVal,BiasVal,FractionLengthVal);
          end
          if(LoopCnt==1)
            decisioninittscov=decisioninfo(tscov, strrep(orgmodelname,'.mdl',''));
            inittscovvalVB(ocnt)=decisioninittscov(1)/decisioninittscov(2);
            acctscovVB{ocnt}=tscov;
            acctscovLoopVB{ocnt}{LoopCnt}=tscov;
          else
            acctscovVB{ocnt}=acctscovVB{ocnt}+tscov;
            acctscovLoopVB{ocnt}{LoopCnt}= acctscovVB{ocnt};
          end
          TestSuiteOD=Fn_ComputeTestSuiteOD('vector',reshape((TestSuiteOutput(:,ocnt,:)),[size(TestSuiteOutput,1) size(TestSuiteOutput,3)]));
          %Replace Strategy
          if(TestSuiteOD>=MaxTestSuiteODVB(ocnt))
            MaxTestSuiteODVB(ocnt)=TestSuiteOD;
            bestsolutionVB{ocnt}=testsuite;
            TestSuiteVB{iter}{ocnt}=testsuite;
            decisioninittscov=decisioninfo(tscov, strrep(orgmodelname,'.mdl',''));
            TestSuiteVBCov(iter,ocnt)=decisioninittscov(1)/decisioninittscov(2);
          end
        end        
      end
      if(strcmp(method,'search')==1)
        %TweakSigmaVB=Fn_AdaptTweakParameter_Delphi(orgmodelname,NoOutputs,acctscovVB,inittscovvalVB,TweakSigmaVB,TweakSigmaExploration,TweakSigmaExploitation);
        %TestSuiteComplexityAllVB(:,:,:)=Fn_AdaptComplexity_Delphi(orgmodelname,NoOutputs,acctscovLoopVB,LoopCnt,5,TestSuiteComplexityAllVB(:,:,:));
        for ocnt=1:NoOutputs,       
          if(ocnt==1)
            testsuite=Fn_TweakATestSuite(bestsolutionVB{ocnt},TweakSigmaVB(ocnt),NoInputVars,InputTypesVar,InputMinVals,InputMaxVals,reshape(TestSuiteComplexityAllVB(ocnt,:,:),[size(TestSuiteComplexityAllVB,2) size(TestSuiteComplexityAllVB,3)]),TestSuitSizes,SimTime,SimStep);
            cursolutionVB{ocnt}=Fn_TweakATestSuiteCalibs(testsuite,TweakSigmaVB(ocnt),NoCalibs,CalTypesVar,CalMinVals,CalMaxVals);
          else
            cursolutionVB{ocnt}=cursolutionVB{1};
          end
        end
      end
      diary(sprintf('%s\\outputlog.dat',orgmodelpath));
      LoopCnt=LoopCnt+1;
      display(LoopCnt);
      diary off; 
    end


    diary(sprintf('%s\\outputlog.dat',orgmodelpath));
    display('VB');
    display(LoopCnt);
    display(iter);
    diary off;
  end


%       tic;
%       LoopCnt=1;
%       while(toc<TimeOutFB && LoopCnt<=1)
%         if(strcmp(method,'search')==1)
%           for ocnt=1:NoOutputs,
%             if(MutOutputs(m,ocnt)==0)
%               continue;
%             end
%             testsuite=cursolutionFB{ocnt};
%             [TestSuiteDist,TestSuiteOutput,tscov]=Fn_ExecuteATestSuite(delphiModel,orgmodelname,mutModelName,testsuite,true,InputTypesVar,NoSteps,NoOutputs,SimTime,SimStep,MaxDist,ocnt);
%             if(LoopCnt==1)
%               decisioninittscov=decisioninfo(tscov, strrep(mutModelName,'.mdl',''));
%               inittscovvalFB(ocnt)=decisioninittscov(1)/decisioninittscov(2);
%               acctscovFB{ocnt}=tscov;
%               acctscovLoopFB{ocnt}{LoopCnt}=tscov;
%             else
%               acctscovFB{ocnt}=acctscovFB{ocnt}+tscov;
%               acctscovLoopFB{ocnt}{LoopCnt}= acctscovFB{ocnt};
%             end
%             %if(strcmp(distancemethod,'vector'))
%             %  TestSuiteOD=Fn_ComputeTestSuiteOD(distancemethod,TestSuiteOutput);
%             %elseif(strcmp(distancemethod,'features'))
%               TestSuiteFeatures=Fn_ComputeTestSuiteFeatures(TestSuiteOutput);
%               TestSuiteOD=Fn_ComputeTestSuiteOD('features',TestSuiteFeatures);
%             %end
%             if(TestSuiteDist>=ULDistFB(m,iter,ocnt))
%               ULDistFB(m,iter,ocnt)=TestSuiteDist;
%               TestSuiteFBUL{m}{iter}{ocnt}=cursolutionFB{ocnt};
%               decisioninittscov=decisioninfo(tscov, strrep(mutModelName,'.mdl',''));
%               TestSuiteFBULCov(m,iter,ocnt)=decisioninittscov(1)/decisioninittscov(2);              
%             end
%             %Replace Strategy
%             if(TestSuiteOD>=MaxTestSuiteODFB(ocnt))
%               MaxTestSuiteODFB(ocnt)=TestSuiteOD;
%               FBDist(m,iter,ocnt)=TestSuiteDist;
%               bestsolutionFB{ocnt}=cursolutionFB{ocnt};
%               TestSuiteFB{m}{iter}{ocnt}=cursolutionFB{ocnt};
%               decisioninittscov=decisioninfo(tscov, strrep(mutModelName,'.mdl',''));
%               TestSuiteFBCov(m,iter,ocnt)=decisioninittscov(1)/decisioninittscov(2);
%             end
%           end        
%         end
%         if(strcmp(method,'search')==1)
%           %TweakSigmaFB=Fn_AdaptTweakParameter(mutModelName,NoOutputs,MutOutputs(m,:),acctscovFB,inittscovvalFB,TweakSigmaFB,TweakSigmaExploration,TweakSigmaExploitation);
%           %TestSuiteComplexityAllFB(m,:,:,:)=Fn_AdaptComplexity(mutModelName,NoOutputs,MutOutputs(m,:),acctscovLoopFB,LoopCnt,5,squeeze(TestSuiteComplexityAllFB(m,:,:,:)));
%           for ocnt=1:NoOutputs,       
%             if(MutOutputs(m,ocnt)==0)
%               continue;
%             end
%             %testsuite=Fn_TweakATestSuite(bestsolutionFB{ocnt},TweakSigmaFB(ocnt),NoInputVars,InputTypesVar,InputMinVals,InputMaxVals,squeeze(TestSuiteComplexityAllFB(m,ocnt,:,:)),TestSuitSizes(m),SimTime,SimStep);
%             %cursolutionFB{ocnt}=Fn_TweakATestSuiteCalibs(testsuite,TweakSigmaFB(ocnt),NoCalibs,CalTypesVar,CalMinVals,CalMaxVals);
%           end
%         end
%         LoopCnt=LoopCnt+1;
%       end
%       diary(sprintf('%s\\outputlog.dat',orgmodelpath));
%       display('FB');      
%       display(m);
%       display(mutModelName);
%       display(LoopCnt);
%       display(iter);
%       diary off;
%     end
    %Fn_WriteOutputs(NoOutputs,NoMutants,AlgIterations,outputdirectory,mutantModelsList,OutputNamesVar,'FB',FBDist,ULDistFB);
    %save('d:\o\TestSuiteVB','TestSuiteVB');
    %close_system(orgmodelname);
   for ocnt=1:NoOutputs,
     Fn_ConvertTestSuites(TestSuiteVB{1}{ocnt},'D:\Desktop\MiLTester\bin\Debug\MiLTesterFiles\Data\SCPC-Mut-Dis\Results\Discontinuity',OutputNamesVar{ocnt});
   end
catch exc
  display(getReport(exc));
  display('Error in random exploration!');
end