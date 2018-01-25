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
        public NetBuilder()
        {
            Status = false;
            InitializeComponent();
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
            pa
        }
    }
}
