using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Bussiness.Workspace.Parameters;

namespace MiLTester.SourceCode.Bussiness.Workspace.Parameters
{

    public enum StaticCheckType
    {
        STOF,
        GNoF,
        FNoG,
        NoSigRes,
        ParMultVal,
        TblOneVal,
        TblAllTheSame,
        HighLowConf
    }

    public class StaticCheckBlock
    {
        public StaticCheckBlock(StaticCheckType staticCheckType,BlockInfo blockInfo)
        {
            this.blockInfo = blockInfo;
            this.staticCheckType = staticCheckType;
        }

        public StaticCheckType staticCheckType;
        public BlockInfo blockInfo;
    }
}
