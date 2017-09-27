function [out]=Fn_MyNorm(ValuesVector)    
  len=length(ValuesVector);
  sum=0;
  for cnt=1:len,
    sum=sum+ValuesVector(cnt)*ValuesVector(cnt);
  end
  out=sqrt(sum);  
end