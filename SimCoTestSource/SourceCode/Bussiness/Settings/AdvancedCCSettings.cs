using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiLTester.SourceCode.Bussiness.Settings
{
    public enum RandomExplorationAlgorithmsEnum
    {
        RandomSearch,
        AdaptiveRandomSearch
    }

    public enum SingelStateSearchAlgorithmsEnum
    {
        RandomSearch,
        HillClimbing,
        HCRR,
        SimulatedAnnealing
    }

    public enum SingelStateSearchAlgorithmTypeEnum
    {
        Explorative,
        Exploitative
    }
    public class AdvancedCCSettings
    {

        public RandomExplorationAlgorithmsEnum randomExplorationAlgorithm =
            RandomExplorationAlgorithmsEnum.AdaptiveRandomSearch;
        public SingelStateSearchAlgorithmsEnum singelStateSearchAlgorithm=
            SingelStateSearchAlgorithmsEnum.HillClimbing;
        public int algorithmIterations = 100;
        public int algorithmRounds = 1;
        public SingelStateSearchAlgorithmTypeEnum algorithmType = 
            SingelStateSearchAlgorithmTypeEnum.Exploitative;
        public bool escapeRandomExploration = false;
        
        public override string ToString()
        {
            string adCCSettingsDetails;
            adCCSettingsDetails = "\tRandom Exploration Algorithm = " + randomExplorationAlgorithm.ToString() + "\r\n";
            adCCSettingsDetails += "\tSingle-State Search Algorithm = " + singelStateSearchAlgorithm.ToString() + "\r\n";
            adCCSettingsDetails += "\tNumber of Iterations = " + algorithmIterations.ToString() + "\r\n";
            adCCSettingsDetails += "\tNumber of Rounds = " + algorithmRounds.ToString();
            return adCCSettingsDetails;
        }
    }
}
