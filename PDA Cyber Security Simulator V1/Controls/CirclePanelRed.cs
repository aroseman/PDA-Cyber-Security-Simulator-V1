using System;
using System.Drawing;
using System.Windows.Forms;

namespace PDA_Cyber_Security_Simulator_V1.Controls
{
    public class CirclePanelRed : Panel
    {
        public CirclePanelRed()
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Color myColor = Color.FromArgb(191, 57, 54);
            SolidBrush fillColor = new SolidBrush(myColor);
            Pen borderColor = new Pen(myColor);
            g.FillEllipse(fillColor, 0, 0, this.Width - 1, this.Height - 1);
            g.DrawEllipse(borderColor, 0, 0, this.Width - 1, this.Height - 1);
        }

        protected override void OnResize(EventArgs e)
        {
            this.Width = this.Height;
            base.OnResize(e);
        }
    }
}

