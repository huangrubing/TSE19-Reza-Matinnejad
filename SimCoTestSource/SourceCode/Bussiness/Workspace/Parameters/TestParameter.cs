using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiLTester.SourceCode.Bussiness.Workspace.Parameters
{

    public enum ParameteresType
    {
        DesiredVariable,
        ActualVariable,
        InputVariable,
        OutputVariable,
        CalibrationVariable
    }

    public class TestParameter
    {
        public TestParameter(string parameterName, ParameteresType parameteresType, float from, float to)
        {
            this.parameteresType=parameteresType;
            this.parameterName=parameterName;
            this.from = from;
            this.to = to;
        }

        public TestParameter(string parameterName, ParameteresType parameteresType, float from, float to, string dataTypeName)
            : this(parameterName, parameteresType, from, to)
        {
            this.dataTypeName = dataTypeName;
        }

        public TestParameter(string parameterName, ParameteresType parameteresType, float from, float to,float valueForTest)
            : this(parameterName, parameteresType, from, to)
        {
            this.valueForTest = valueForTest;
        }

        public TestParameter(string parameterName, ParameteresType parameteresType, float from, float to, float valueForTest, string dataTypeName)
            : this(parameterName, parameteresType, from, to, dataTypeName)
        {
            this.valueForTest = valueForTest;
        }

        public TestParameter(string parameterName, ParameteresType parameteresType, float from, float to, string dataTypeName, float defaultValue, int portNum, string path,
            int wordLength,int fracLength)
            : this(parameterName, parameteresType, from, to, dataTypeName)
        {
            this.defaultValue = defaultValue;
            this.portNum = portNum;
            this.path = path;
        }

        public TestParameter(BlockInfo blockInfo, ParameterDataType parameterDataType)
            //: this(parameterName, parameteresType, from, to, dataType)
        {
            this.blockInfo = blockInfo;
            this.parameterDataType = parameterDataType;
        }

        public override string ToString()
        {
            return "Parameter Name: " + parameterName + "\r\n\t\tType: " + parameteresType.ToString() 
                + "\r\n\t\tFrom: " + from.ToString() + "\r\n\t\tTo: " + to.ToString();
        }


        public BlockInfo blockInfo;
        public ParameterDataType parameterDataType;



        public string dataTypeName = "";
        public string path = "";
        public int portNum = 0;
        public float defaultValue = 0;

        public float valueForTest = 0;
        public float from = 0, to = 0;
        public ParameteresType parameteresType;
        public string parameterName = "";
    }
}
