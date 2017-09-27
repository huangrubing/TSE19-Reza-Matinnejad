using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiLTester.SourceCode.Bussiness.Workspace.Parameters
{

    public class ParameterDataType
    {
        public ParameterDataType(string dataTypeName)
        {
            this.dataTypeName = dataTypeName;
        }

        public ParameterDataType(string dataTypeName, bool isSigned, int wordLength, int fracLength, float minDataType, float maxDataType)
            : this(dataTypeName)
        {
            this.isSigned = isSigned;
            this.wordLength = wordLength;
            this.fracLength = fracLength;
            this.minDataType = minDataType;
            this.maxDataType = maxDataType;
        }
       

        /*public override string ToString()
        {
            return "Parameter Name: " + parameterName + "\r\n\t\tType: " + parameteresType.ToString() 
                + "\r\n\t\tFrom: " + from.ToString() + "\r\n\t\tTo: " + to.ToString();
        }*/

        public float minDataType = 0;
        public float maxDataType = 0;
        public int wordLength = 0;
        public int fracLength = 0;
        public bool isSigned = false;
        public string dataTypeName = "";
    }
}
