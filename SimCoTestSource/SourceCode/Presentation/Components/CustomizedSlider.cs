using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MB.Controls;

namespace MiLTester.SourceCode.Presentation.Components
{
    public delegate void UsefulValueChangeEventDelegate(UsefulValueChangeArgs args);
    public class CustomizedSlider : ColorSlider
    {
        public CustomizedSlider()
        {
            this.ValueChanged += OnValueChnaged;
        }

        private void OnValueChnaged(object sender, EventArgs e)
        {
            if (OnUsefullValueChange != null)
            {
                if(previousSliderValue==this.Value)
                    return;
                if (previousSliderValue != 0)
                {
                    if(this.Value>previousSliderValue)
                        OnUsefullValueChange(new UsefulValueChangeArgs(previousSliderValue,this.Value));
                    else
                        OnUsefullValueChange(new UsefulValueChangeArgs(previousSliderValue,this.Value));
                    System.Console.Out.WriteLine("Here");
                }
                previousSliderValue = this.Value;
            }
        }

        private int previousSliderValue=0;
        public event UsefulValueChangeEventDelegate OnUsefullValueChange = null;
        public static int colorSliderWidth = 12;
    }
}
