using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiLTester.SourceCode.Bussiness.Settings
{
    public class AdvancedSBSettings
    {

        public int candidates = 100;

        public override string ToString()
        {
            string adSBSettingsDetails = "";
            //adCCSettingsDetails = "\tRandom Exploration Algorithm = " + randomExplorationAlgorithm.ToString() + "\r\n";
            //adCCSettingsDetails += "\tSingle-State Search Algorithm = " + singelStateSearchAlgorithm.ToString() + "\r\n";
            //adCCSettingsDetails += "\tNumber of Iterations = " + algorithmIterations.ToString() + "\r\n";
            //adCCSettingsDetails += "\tNumber of Rounds = " + algorithmRounds.ToString();
            return adSBSettingsDetails;
        }
    }
}
