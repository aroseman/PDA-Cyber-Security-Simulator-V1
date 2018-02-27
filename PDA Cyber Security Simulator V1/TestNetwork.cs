using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDA_Cyber_Security_Simulator_V1.Controls;

namespace PDA_Cyber_Security_Simulator_V1
{
    public partial class TestNetwork : Form
    {
        private Form1 Form1;
        private bool test = false;

        public TestNetwork(Form1 form1)
        {
            Form1 = form1;
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        //Navigate back to Home screen
        private void rootCrumb_Click(object sender, EventArgs e)
        {
            //Need to relink this page to the home form (this needs to happen if the form has been cleared)
            Form1.TestNetwork = this;
            Form1.Show();
            this.Hide();
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

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control c in pnlTestStatus.Controls)
            {
                if (c is CirclePanelRed)
                {
                    if (!test)
                    {
                        c.Hide();
                    }
                    else
                    {
                        c.Show();
                    }
                }
            }

            test = !test;
        }


        private void testNetworkComboBoxOnClick(object sender, EventArgs e)
        {
            if (testNetworkComboBox1.SelectedIndex != -1)
            {
                testNetworkListBox1.Items.Clear();

                String[] dList = Network.getDeviceNames(testNetworkComboBox1.SelectedIndex);
                for (int i = 0; i < dList.Length; i++)
                {
                    if (!String.IsNullOrEmpty(dList[i]))
                        testNetworkListBox1.Items.Add(dList[i]);
                }
            }
        }
    }
}
