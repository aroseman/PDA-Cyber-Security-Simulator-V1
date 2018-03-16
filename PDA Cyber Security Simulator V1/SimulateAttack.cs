using System;
using System.Windows.Forms;

namespace PDA_Cyber_Security_Simulator_V1
{
    public partial class SimulateAttack : Form
    {
        private Form1 Form1;


        public SimulateAttack(Form1 form1)
        {
            Form1 = form1;
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }


        //Form closing
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.Visible == true)
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

        private void rootCrumb_Click(object sender, System.EventArgs e)
        {
            //Need to relink this page to the home form (this needs to happen if the form has been cleared)
            Form1.SimulateAttack = this;
            Form1.Show();
            this.Hide();

        }

        private void lblDevices_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void AttacksComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
