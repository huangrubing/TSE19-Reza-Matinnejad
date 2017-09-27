using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiLTester.SourceCode.Bussiness.RunEngine.MatlabCommands;
using MiLTester.SourceCode.Bussiness.Output.HeatMap;

namespace MiLTester.SourceCode.Bussiness.Settings
{
    public class SLSettings
    {
        public SLSettings(bool withDefaultBudget)
        {
            Criteria.Add("Diversity", 6);
            Criteria.Add("Stability", 3);
            Criteria.Add("Continuity", 1);
        }

        public void Reset()
        {
            for (int i = 0; i < Criteria.Keys.Count;++i)
                Criteria[Criteria.Keys.ElementAt(i)] = 0;
        }

        public int GetNumberOfSelectedCriteria()
        {
            int CriCount = 0;
            for (int i = 0; i < Criteria.Count; ++i)
                if (Criteria.ElementAt(i).Value > 0)
                    ++CriCount;
            return CriCount;
        }

        public override string ToString()
        {
            string sbSettingsDetails = "";
            foreach(string key in Criteria.Keys)
                sbSettingsDetails += "\t" + Criteria[key].ToString() + " test cases for " + key + ".\r\n";
            return sbSettingsDetails;
        }


        public Dictionary<string, int> Criteria = new Dictionary<string, int>();

    }

}
