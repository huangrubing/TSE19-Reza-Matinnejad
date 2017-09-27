function Fn_CreateStChecksHTML(filesdirectory,xmlfilename)
  
  fileStChecksHtml = fopen(sprintf('%s\\%s.html',filesdirectory,xmlfilename),'w');
  fprintf(fileStChecksHtml,'%s\n%s\n%s\n%s\n','<HEAD>','<TITLE> Static Checks Report: Name </TITLE>','</HEAD>','<BODY>');
  linkstr='<BR><h3>checkNo.checkType "<A href="matlab: hilite_system(''blckpath'');">blckname</A>"</h3>';
  
  xDoc = xmlread(sprintf('%s\\%s.xml',filesdirectory,xmlfilename));
  xRoot = xDoc.getDocumentElement;
  childNodes = xRoot.getChildNodes;
  numChildNodes = childNodes.getLength;


  cnt=1;
  for count = 1:numChildNodes,
    theChild = childNodes.item(count-1);
    if(strcmp(char(theChild.getNodeName),'NoStOF'))
      inputChildNodes = theChild.getChildNodes;
      numInputChildNodes = inputChildNodes.getLength;
      for count2 = 1:numInputChildNodes,
        theAttr = inputChildNodes.item(count2-1);
        if(strcmp(char(theAttr.getNodeName),'Tag'))
          valNode = theAttr.getChildNodes;
          blckname=char(valNode.item(0).getNodeValue);
        elseif(strcmp(char(theAttr.getNodeName),'Path'))
          valNode = theAttr.getChildNodes;
          blckpath=char(valNode.item(0).getNodeValue);
        end
      end
      curlinkstr=strrep(linkstr,'checkNo',num2str(cnt));
      curlinkstr=strrep(curlinkstr,'checkType','Sature On Overflow');
      curlinkstr=strrep(curlinkstr,'blckname',blckname);
      curlinkstr=strrep(curlinkstr,'blckpath',blckpath);
      fprintf(fileStChecksHtml,'%s',curlinkstr);
      cnt=cnt+1;
    end
  end
  
  fprintf(fileStChecksHtml,'%s','</BODY>');
  fclose(fileStChecksHtml);
end