 
function [StaticSlice]=Fn_GetBackStaticSlice(mdlname)
  %blocks are accessed usig the blockpath
  allblocks=find_system(mdlname,'FollowLinks','on','LookUnderMasks','all','Type','Block');
  
  %stateflow elements are accessed using sfIds
  rt=sfroot;
  sfobjcets=rt.find('-isa','Stateflow.Chart','-or','-isa','Stateflow.State','-or','-isa','Stateflow.Transition');
  if(~isempty(sfobjcets))
    %model contains a Stateflow
    for i=1:length(sfobjcets),
      sfobjcetsids{i}=num2str(sfobjcets(i).Id);
    end
  end
  %find all ouptuts at the highest level of the model
  outputports=find_system(mdlname,'FollowLinks','on','LookUnderMasks','all','Type','Block','Parent',mdlname,'BlockType','Outport');

  %iterating over models outputs
  for i=1:length(outputports),
    %building a StaticSlice matrix (block,covered)
    %blocks (assuming the model contains some sim blocks    
    valueSet=zeros(length(allblocks),1);
    slblocksmap=containers.Map(allblocks,valueSet);
    %sfobjects
    if(~isempty(sfobjcets))
      valueSet=zeros(length(sfobjcets),1);
      sfobjectsmap=containers.Map(sfobjcetsids',valueSet);
      StaticSlice{i}=[slblocksmap; sfobjectsmap];  
    else
      StaticSlice{i}=slblocksmap;
    end
  end
  
  for i=1:length(outputports),
    %reset color matrix
    hndlcellarry=get_param(outputports(i),'Handle');
    BackStaticSliceRec(mdlname,StaticSlice{i},hndlcellarry{1});
  end
  %save('d:\StaticSlice.mat','StaticSlice');
end


%a recursive function to compute the static slice for a given block
function BackStaticSliceRec(mdlname,StaticSlice,blkhndl)
  %check if block is visited before, this wil prevent recursion
  blockcap=get_param(blkhndl,'Capabilities');
  if(StaticSlice(blockcap.BlockPath))
    return;
  end
  StaticSlice(blockcap.BlockPath)=1;
  %finds ports connected to current block
  pcon=get_param(blkhndl,'PortConnectivity');
  numinputs=0;
  for i=1:length(pcon),
    if(~isempty(pcon(i).SrcBlock))
      numinputs=numinputs+1;
      srcblckhndl=pcon(i).SrcBlock;
      srcblcktype=get_param(srcblckhndl,'BlockType');
      if(~strcmp(srcblcktype,'SubSystem'))%checks if the srcblock is not a sybsystem
        BackStaticSliceRec(mdlname,StaticSlice,srcblckhndl);
      else
        %srcblock is a sybsystem
        srcblckmasktype=get_param(srcblckhndl,'MaskType');
        if(~strcmp(srcblckmasktype,'Stateflow'))%checks if the srcblock is not a stateflow
          outportnum=str2num(pcon(i).Type);
          lhndl=get_param(blkhndl,'LineHandles');
          inlinhndl=lhndl.Inport(outportnum);
          if(inlinhndl<=0)
            %no line is connected to this inport
            continue;
          end
          srcblckhndls=InSubsystemSrcBlck(inlinhndl,srcblckhndl,StaticSlice);
          for j=1:length(srcblckhndls),
            BackStaticSliceRec(mdlname,StaticSlice,srcblckhndls{j});
          end
        else
          %the subsyste is a stateflow
          %we assume all the stateflow objects are in the static slice
          %Stateflow Subsystem visited
          blockcap=get_param(srcblckhndl,'Capabilities');
          StaticSlice(blockcap.BlockPath)=1;

          rt=sfroot;
          sfobjcets=rt.find('-isa','Stateflow.Chart','-or','-isa','Stateflow.State','-or','-isa','Stateflow.Transition');
          for j=1:length(sfobjcets),
            StaticSlice(num2str(sfobjcets(j).Id))=1;
          end

          
          outportnum=pcon(i).SrcPort + 1;
          sfoutputports=find_system(srcblckhndl,'FollowLinks','on','LookUnderMasks','all','Type','Block','BlockType','Outport');
          outportcap=get_param(sfoutputports(outportnum),'Capabilities');
          StaticSlice(outportcap.BlockPath)=1;
          
          %we continue the back trace from all the 
          sfinputports=find_system(srcblckhndl,'FollowLinks','on','LookUnderMasks','all','Type','Block','BlockType','Inport');
          for k=1:length(sfinputports),
            BackStaticSliceRec(mdlname,StaticSlice,sfinputports(k));
          end
          %and then we backtrace for all the stateflow inputs
          %lhndl=get_param(srcblckhndl,'LineHandles');
          %for j=1:length(lhndl.Inport),
          %  inlinhndl=lhndl.Inport(j);
          %  if(inlinhndl<=0)
              %no line is connected to this inport
          %    continue;
          %  end
          %  srcblckhndl=get_param(inlinhndl,'SrcBlockHandle');
          %  srcblcktype=get_param(srcblckhndl,'BlockType');
          %  if(strcmp(srcblcktype,'SubSystem'))
          %    srcblckhndls=InSubsystemSrcBlck(inlinhndl,srcblckhndl,StaticSlice);
          %    for k=1:length(srcblckhndls),
          %      BackStaticSliceRec(mdlname,StaticSlice,srcblckhndls{k});
          %    end
          %  else
          %    BackStaticSliceRec(mdlname,StaticSlice,srcblckhndl);
          %  end
          %end
        end        
      end
    end
  end
  
  if(numinputs<=0)
    %a block with no input
    %for input ports and from blocks, we should handle the situation
    blckparent=get_param(blkhndl,'Parent');
    blcktype=get_param(blkhndl,'BlockType');
    if(strcmp(blcktype,'Inport') && ~strcmp(blckparent,mdlname))
      %input port block, not in the higest level
      lhndl=get_param(blckparent,'LineHandles');
      inportnum=str2num(get_param(blkhndl,'Port'));
      inlinhndl=lhndl.Inport(inportnum);
      if(inlinhndl<=0)
        %no line is connected to this inport
        return;
      end
      srcblckhndl=get_param(inlinhndl,'SrcBlockHandle');
      srcblcktype=get_param(srcblckhndl,'BlockType');
      if(strcmp(srcblcktype,'SubSystem'))
        srcblckhndls=InSubsystemSrcBlck(inlinhndl,srcblckhndl,StaticSlice);
        for k=1:length(srcblckhndls),
          BackStaticSliceRec(mdlname,StaticSlice,srcblckhndls{k});
        end        
      else
        BackStaticSliceRec(mdlname,StaticSlice,srcblckhndl);  
      end
    elseif(strcmp(blcktype,'EnablePort') && ~strcmp(blckparent,mdlname))
      lhndl=get_param(blckparent,'LineHandles');
      inlinhndl=lhndl.Enable;
      if(inlinhndl<=0)
        %no line is connected to this inport
        return;
      end
      srcblckhndl=get_param(inlinhndl,'SrcBlockHandle');
      srcblcktype=get_param(srcblckhndl,'BlockType');
      if(strcmp(srcblcktype,'SubSystem'))
        srcblckhndls=InSubsystemSrcBlck(inlinhndl,srcblckhndl,StaticSlice);
        for k=1:length(srcblckhndls),
          BackStaticSliceRec(mdlname,StaticSlice,srcblckhndls{k});
        end        
      else
        BackStaticSliceRec(mdlname,StaticSlice,srcblckhndl);  
      end
    elseif(strcmp(blcktype,'ActionPort') && ~strcmp(blckparent,mdlname))
      %report matlab bug (for action ports, LineHandles returns a port
      %hanldle not a line handle!
      phndl=get_param(blckparent,'PortHandles');
      actionporthndl=phndl.Ifaction(1);
      if(actionporthndl<=0)
        %no line is connected to this inport
        return;
      end
      grandparent=get_param(blckparent,'Parent');
      alllines=find_system(grandparent,'FindAll','On','SearchDepth','1','FollowLinks','on','LookUnderMasks','all','Type','Line');
      for i=1:length(alllines),
        %get_param(alllines(i),'Handle');
        if(get_param(alllines(i),'DstPortHandle')==actionporthndl)
          break;
        end
      end
      inlinhndl=alllines(i);
      srcblckhndl=get_param(inlinhndl,'SrcBlockHandle');
      srcblcktype=get_param(srcblckhndl,'BlockType');
      if(strcmp(srcblcktype,'SubSystem'))
        srcblckhndls=InSubsystemSrcBlck(inlinhndl,srcblckhndl,StaticSlice);
        for k=1:length(srcblckhndls),
          BackStaticSliceRec(mdlname,StaticSlice,srcblckhndls{k});
        end        
      else
        BackStaticSliceRec(mdlname,StaticSlice,srcblckhndl);  
      end      
    elseif(strcmp(blcktype,'From'))
      gototag=get_param(blkhndl,'GoToTag');
      gotoblock=find_system(blckparent,'SearchDepth','1','FollowLinks','on','LookUnderMasks','all','Type','Block','BlockType','Goto','GoToTag',gototag);
      if(isempty(gotoblock))
        %no got for this from
        return;
      end
      srcblckhndlcellarry=get_param(gotoblock,'Handle');
      srcblckhndl=srcblckhndlcellarry{1};
      BackStaticSliceRec(mdlname,StaticSlice,srcblckhndl);
    else
      %no input. Neither a from block, nor an internal inport
      return;
    end
  end
end

function [InSubsystemSrcBlckHndls]=InSubsystemSrcBlck(inlinhndl,srcblckhndl,StaticSlice)
  %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
  %SubSystem Visited
  blockcap=get_param(srcblckhndl,'Capabilities');
  StaticSlice(blockcap.BlockPath)=1;
  %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
  srcprthndl=get_param(inlinhndl,'SrcPortHandle');
  srcprtno=get_param(srcprthndl,'PortNumber');
  subsyspath=get_param(srcblckhndl,'Capabilities');
  outportblck=find_system(subsyspath.BlockPath,'SearchDepth','1','FollowLinks','on','LookUnderMasks','all','Type','Block','BlockType','Outport','Port',num2str(srcprtno));
  outportblckhndlcellarry=get_param(outportblck,'Handle');
  InSubsystemSrcBlckHndls{1}=outportblckhndlcellarry{1};  
  
  offset=length(InSubsystemSrcBlckHndls);
  ActionPorts=find_system(subsyspath.BlockPath,'SearchDepth','1','FollowLinks','on','LookUnderMasks','all','Type','Block','BlockType','ActionPort');
  for i=1:length(ActionPorts),
    InSubsystemSrcBlckHndls{i+offset}=ActionPorts{i};
  end
  
  offset=length(InSubsystemSrcBlckHndls);
  EnablePorts=find_system(subsyspath.BlockPath,'SearchDepth','1','FollowLinks','on','LookUnderMasks','all','Type','Block','BlockType','EnablePort');
  for i=1:length(EnablePorts),
    InSubsystemSrcBlckHndls{i+offset}=EnablePorts{i};
  end

end