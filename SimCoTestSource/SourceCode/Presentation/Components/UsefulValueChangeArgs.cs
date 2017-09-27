using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiLTester.SourceCode.Presentation.Components
{
    public class UsefulValueChangeArgs: EventArgs
    {
        public UsefulValueChangeArgs(int PreviousValue, int CurrentValue)
        {
            this.PreviousValue = PreviousValue;
            this.CurrentValue = CurrentValue;
        }
        public int CurrentValue;
        public int PreviousValue;
    }
}
