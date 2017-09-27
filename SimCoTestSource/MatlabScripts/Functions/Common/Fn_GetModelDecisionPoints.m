 
function [DecisionPoints,DecisionPointsOutcomes]=Fn_GetModelDecisionPoints(mdlname,tccov)
  % the function returns the Block Paths of Simulink blcoks and SFIDs of
  % the stateflow objects which include a decision point
  % note that each decision point includes at least 2 outcomes
  % and each outcome is covered for a percentage of the simulaiton time
  % (that of course can be 0)
  % However, in this function we just want to extract the decisoin potins
  % form the model and we are not interested in the coverage of outcomes
  
  % blocks are accessed usig the blockpath
  decpointscnt=0;
  decscnt=0;
  NoDecOutcomes=0;
  allblocks=find_system(mdlname,'FindAll','on','FollowLinks','on','LookUnderMasks','all','Type','Block');
  for blckcnt=1:length(allblocks),
    blckhndl=allblocks(blckcnt);
    [~,desc]=decisioninfo(tccov,blckhndl);
    if(~isempty(desc)&&isfield(desc,'decision'))
      decpointscnt=decpointscnt+1;
      blockcap=get_param(blckhndl,'Capabilities');
      DecisionPoints{decpointscnt}=blockcap.BlockPath;
      NoDecOutcomes=0;
      decscnt=decscnt+length(desc.decision);
      for dec=1:length(desc.decision), 
        NoDecOutcomes=NoDecOutcomes+length(desc.decision(dec).outcome);
      end
      DecisionPointsOutcomesCell{decpointscnt}=NoDecOutcomes;
    end
  end  
  
  %stateflow elements are accessed using sfIds
  rt=sfroot;
  sfobjcets=rt.find('-isa','Stateflow.Chart','-or','-isa','Stateflow.State','-or','-isa','Stateflow.Transition');
  for sfobjcnt=1:length(sfobjcets),
    sfObjId=sfobjcets(sfobjcnt).Id;
    [~,desc]=decisioninfo(tccov,sfObjId);
    if(~isempty(desc)&&isfield(desc,'decision'))
      decpointscnt=decpointscnt+1;
      DecisionPoints{decpointscnt}=num2str(sfObjId); 
      NoDecOutcomes=0;
      decscnt=decscnt+length(desc.decision);
      for dec=1:length(desc.decision), 
        NoDecOutcomes=NoDecOutcomes+length(desc.decision(dec).outcome);
      end
      DecisionPointsOutcomesCell{decpointscnt}=NoDecOutcomes;
    end
  end
  DecisionPointsOutcomes=zeros(length(DecisionPointsOutcomesCell),1);
  for i=1:length(DecisionPointsOutcomesCell),
    DecisionPointsOutcomes(i)=DecisionPointsOutcomesCell{i};
  end
end