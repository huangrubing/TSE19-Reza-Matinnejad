using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiLTester.SourceCode.Bussiness.Workspace.Parameters
{

    public class BlockInfo
    {
        /*public BlockInfo(string blockPath)
        {
            this.blockPath = blockPath;
        }*/

        public BlockInfo(string blockPath, string blockTag)
        {
            this.blockTag = blockTag;
            this.blockPath = blockPath;
        }

        public BlockInfo(string blockPath, string blockTag,int blockPortNum)
            : this(blockPath, blockTag)
        {
            this.blockPortNum = blockPortNum;
        }


        public string blockTag = "";
        public int blockPortNum = 0;
        public string blockPath = "";
    }
}
