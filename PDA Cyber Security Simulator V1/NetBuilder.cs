using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDA_Cyber_Security_Simulator_V1
{
    public partial class NetBuilder : Form
    {
        public bool Status { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        private Pen Pen { get; set; }
        public NetBuilder()
        {
            Status = false;
            InitializeComponent();
            Pen = new Pen(Color.Black);
        }

        private void expandTools_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            Status = true;
            StartPoint = MousePosition;
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            Status = false;
            EndPoint = MousePosition;
            canvas.Refresh();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            if (Status)
            {
                e.Graphics.DrawLine(Pen, StartPoint, EndPoint);
                canvas.Refresh();
            }
        }

        /**
         * Handle closing applicaion from secondary form.
         * [!]BUG: it double prompts the user.
         * */
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
        
            base.OnFormClosing(e);
            System.Windows.Forms.Application.Exit(); // Do not move!
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

           // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:

                    break;
            }
        }
    }
}
