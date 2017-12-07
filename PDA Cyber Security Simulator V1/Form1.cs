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

            homeScreen.Visible = false;
            breadCrumbPanel.BackColor = Color.FromArgb(240,144,24);
            imagePanel.BackColor = Color.FromArgb(240, 144, 24);
            networkConfigurationPanel.Visible = true;
        }

        private void viewNetworkOnClick(object sender, EventArgs e)
        {
            Console.WriteLine("View Network");
        }

        private void testNetworkOnClick(object sender, EventArgs e)
        {
            homeScreen.Visible = false;
            breadCrumbPanel.BackColor = Color.FromArgb(0, 144, 120);
            imagePanel.BackColor = Color.FromArgb(0, 144, 120);
            testNetworkPanel.Visible = true;
        }

        private void simulateAttackPanelOnClick(object sender, EventArgs e)
        {
            Console.WriteLine("Simulate Attack");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Load_Home(object send, EventArgs e)
        {
            networkConfigurationPanel.Visible = false;
            testNetworkPanel.Visible = false;
            homeScreen.Visible = true;
            breadCrumbPanel.BackColor = Color.FromName("Control");
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
                deviceFormtableLayoutPanel.Visible = false;
                configLabel.Text = "Networks";

            }
            else
            {
                deviceFormtableLayoutPanel.Visible = true;
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
                Device device = new Device(name, ipAddress, macAddress, notes);
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

    }
}
