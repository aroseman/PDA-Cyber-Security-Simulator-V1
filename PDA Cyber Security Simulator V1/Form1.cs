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
    public partial class Form1 : Form
    {
        private NetBuilder NetBuilder { get; set; }

        public Form1()
        {
            InitializeComponent();
           
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void configureNetwork_Paint(object sender, PaintEventArgs e)
        {

        }

        private void conifgureNetworkOnClick(object sender, EventArgs e)
        {

            //homeScreen.Visible = false;
            //breadCrumbFlowLayoutPanel.BackColor = Color.FromArgb(240,144,24);
            //imagePanel.BackColor = Color.FromArgb(240, 144, 24);
            //networkConfigurationPanel.Visible = true;

            if(NetBuilder is null)
            {
                NetBuilder form = new NetBuilder(this);
                NetBuilder = form;
                this.Hide();
                form.Show();
            }
            else
            {
                NetBuilder.Show();
                this.Hide();
            }
            
        }

        private void viewNetworkOnClick(object sender, EventArgs e)
        {
            Console.WriteLine("View Network");
        }

        private void testNetworkOnClick(object sender, EventArgs e)
        {
            homeScreen.Visible = false;
            breadCrumbFlowLayoutPanel.BackColor = Color.FromArgb(0, 144, 120);
            imagePanel.BackColor = Color.FromArgb(0, 144, 120);
            testNetworkTableLayoutPanel.Visible = true;
        }

        private void simulateAttackPanelOnClick(object sender, EventArgs e)
        {
            homeScreen.Visible = false;
            breadCrumbFlowLayoutPanel.BackColor = Color.FromArgb(0, 120, 192);
            imagePanel.BackColor = Color.FromArgb(0, 120, 192);
            simulateAttackTableLayoutPanel.Visible = true;
            Console.WriteLine("Simulate Attack");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Load_Home(object send, EventArgs e)
        {
            networkConfigurationPanel.Visible = false;
            testNetworkTableLayoutPanel.Visible = false;
            simulateAttackTableLayoutPanel.Visible = false;
            homeScreen.Visible = true;
            breadCrumbFlowLayoutPanel.BackColor = Color.FromName("Control");
            imagePanel.BackColor = Color.FromName("Control");
        }

        private void configurationOnIndexChange(object sender, EventArgs e)
        {
            /*
             * Controls the rendering of various containers on index change.
             * 
             * Networks:
             * 
             * Devices:
             * 
             * */
            if (configComboBox.SelectedItem.Equals("Networks"))
            {
                deviceFormTableLayoutPanel.Visible = false;
                configLabel.Text = "Networks";

            }
            else
            {
                deviceFormTableLayoutPanel.Visible = true;
                configLabel.Text = "Devices";
            }
        }

        private void AddNewOnClick(object sender, EventArgs e)
        {
            /*
             * Creates a new Device or Network Object, pushes it on to the appropriate list, and writes it to file.             
             * */

            
            if (configComboBox.SelectedItem.Equals("Networks"))
            {

            }
            else
            {
                string name = textBox1.Text;
                string ipAddress = textBox2.Text;
                string macAddress = textBox3.Text;
                string notes = textBox4.Text;
                string[] lines = { name, ipAddress, macAddress, notes};
                // Device device = new Device(name, ipAddress, macAddress, notes);
                Device device = new Device();
                System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\Devices.txt", lines);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        /*
         * Test Device
         * */
        private void button1_Click(object sender, EventArgs e)
        {
            NetworkTester networkTester = new NetworkTester();
            networkTester.TestDevice("www.google.com", pingResultTextBox);

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(this.Visible == true)
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

    }
}
