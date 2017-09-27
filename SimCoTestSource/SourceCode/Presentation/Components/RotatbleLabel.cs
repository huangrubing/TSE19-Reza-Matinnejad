using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MiLTester.SourceCode.Presentation.Components
{
    public class RotatbleLabel : Label
    {
        public int RotateAngle { get; set; }
        public string NewText { get; set; }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Brush b = new SolidBrush(this.ForeColor);
            e.Graphics.TranslateTransform((this.Width / 4) * 3 , 0);
            e.Graphics.RotateTransform(this.RotateAngle);
            e.Graphics.DrawString(this.NewText, this.Font, b, 0f, 0f);
            base.OnPaint(e);
        }
    }
}
