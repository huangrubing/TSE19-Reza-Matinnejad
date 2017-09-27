function Fn_ConvertCovHTML()

  fileCov = fopen('d:\cov.html','r');
  fileCovConv = fopen('d:\cov-conv.html','w');
  cvdispseen=false;
  parentseen=false;

  while(1)
    str=fgets(fileCov);
    if(~ischar(str))
      break;
    end
    if(cvdispseen)
      display(str);
      if(strfind(str,'Paren'))
        parentstr=fgets(fileCov);
        parentseen=true;
      end
    elseif(strfind(str,'cvdisplay'))
      cvdispseen=true;
      parentseen=false;
      i=0;
    end
    if(parentseen)
       cvdisstr=previousstr{1};
       convstr=Fn_ReplaceCVDisp(cvdisstr,Fn_GetParentPath(parentstr),Fn_GetBlockName(cvdisstr));
       fprintf(fileCovConv,'%s',convstr);
       for j=2:i,
         fprintf(fileCovConv,'%s',previousstr{j});
       end
       fprintf(fileCovConv,'%s',str);
       fprintf(fileCovConv,'%s',parentstr);
       cvdispseen=false;
       parentseen=false;
       i=0;
    elseif(cvdispseen)
      i=i+1;
      previousstr{i}=str;
    else
      fprintf(fileCovConv,'%s',str);
    end
  end
  fclose(fileCov);
  fclose(fileCovConv);
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

