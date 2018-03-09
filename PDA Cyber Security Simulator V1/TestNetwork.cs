using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PDA_Cyber_Security_Simulator_V1.Controls;
using static System.Windows.Forms.ListBox;

namespace PDA_Cyber_Security_Simulator_V1
{
    public partial class TestNetwork : Form
    {
        #region Attributes
        private Form1 Form1;
        private bool test = false;
        private List<Label> DeviceNames;
        private List<Label> PingLabels;
        private List<Label> PingTime;
        private List<Label> IpLabels;
        private List<Label> DeviceIp;
        private List<CirclePanelRed> RedDots;
        private List<CirclePanelGreen> GreenDots;
        #endregion
        List<String> NetworkNames;
        List<int> NetworkIDs;
        List<Device> Devices;
        List<Language> NetworkDataSource { get;  set; }
        List<Language> DeviceDataSource { get; set; }
        NetworkTester NT { get; set; }
        public TestNetwork(Form1 form1)
        {
            Form1 = form1;
            NT = new NetworkTester();
            
            InitializeNetworkNames();
            InitializeNetworkIDs();
            InitializeNetworkDataSource();
            InitializeComponent();
            InitializeGraphics();
            PopulateNetworkList();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
          //  testNetworkComboBox1.Items = 
        }
        
        private void InitializeNetworkNames()
        {
            NetworkNames = new List<string>();
            NetworkNames = Network.getNetworkNames();
        }
        private void InitializeNetworkDataSource()
        {
            NetworkDataSource = new List<Language>();
            for(int i = 0; i < NetworkNames.Count; i++)
            {
                NetworkDataSource.Add(new Language() { Name = NetworkNames[i], Value = NetworkIDs[i].ToString() });
            }
        }
        private void InitializeDevices(int netId)
        {
            Devices = new List<Device>();
            Devices = Network.getDevices(netId);
        }
        private void InitializeDeviceDataSource()
        {
            DeviceDataSource = new List<Language>();
            for(int i = 0; i < Devices.Count; i++)
            {
                DeviceDataSource.Add(new Language { Name = Devices[i].Name, Value = Devices[i].IpAddress });
            }
        }


        private void InitializeNetworkIDs()
        {
            NetworkIDs = new List<int>();
            foreach (String name in NetworkNames){
                NetworkIDs.Add(Network.getNetworkIdByName(name));
            }
        }

        private void InitializeGraphics()
        {
            DeviceNames = new List<Label>();
            PingLabels = new List<Label>();
            PingTime = new List<Label>();
            IpLabels = new List<Label>();
            DeviceIp = new List<Label>();
            RedDots = new List<CirclePanelRed>();
            GreenDots = new List<CirclePanelGreen>();

            foreach(Control c in pnlTestStatus.Controls)
            {
                if(c is Label && c.Name.Contains("lblDevice"))
                {
                    DeviceNames.Add((Label)c);
                }
                else if(c is Label && c.Name.Contains("lblPingTime"))
                {
                    PingTime.Add((Label)c);
                }
                else if(c is Label && c.Name.Contains("lblPing"))
                {
                    PingLabels.Add((Label)c);
                }
                else if(c is Label && c.Name.Contains("lblIp"))
                {
                    IpLabels.Add((Label)c);
                }
                else if(c is Label && c.Name.Contains("lblAddress"))
                {
                    DeviceIp.Add((Label)c);
                }
                else if(c is CirclePanelGreen)
                {
                    GreenDots.Add((CirclePanelGreen)c);
                }
                else if(c is CirclePanelRed)
                {
                    RedDots.Add((CirclePanelRed)c);
                }
                else
                {

                }
            }

            for(int i = 0; i < RedDots.Count; i++)
            {
                RedDots[i].Hide();
                GreenDots[i].Hide();
                DeviceNames[i].Hide();
                DeviceIp[i].Hide();
                IpLabels[i].Hide();
                PingLabels[i].Hide();
                PingTime[i].Hide();
            }
        }


        /**
         * Populates testNetworkComboBox1 with all available networks.
         *
         **/
        private void PopulateNetworkList()
        {
            testNetworkComboBox1.DataSource = NetworkDataSource;
        }

        private void PopulateDeviceList()
        {
            testNetworkListBox1.DataSource = DeviceDataSource;
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
            SelectedIndexCollection selectedDevices = testNetworkListBox1.SelectedIndices;

            for(int i = 0; i < selectedDevices.Count; i++)
            {
                int index = selectedDevices.IndexOf(i);
                NT.TestDevice(Devices[index].IpAddress);
                Console.WriteLine(index);
            }
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
                //testNetworkListBox1.Items.Clear();

                //List<Device> dList = Network.getDevices(testNetworkComboBox1.SelectedIndex);
                //for (int i = 0; i < dList.Count; i++)
                //{
                //    if (!String.IsNullOrEmpty(dList[i].Name))
                //        testNetworkListBox1.Items.Add(dList[i].Name);
                //}

                // InitializeDevices(Int32.Parse(testNetworkComboBox1.SelectedValue.ToString()));
                InitializeDevices(Int32.Parse(NetworkDataSource[testNetworkComboBox1.SelectedIndex].Value));
                InitializeDeviceDataSource();
                PopulateDeviceList();
            }
        }
    }
}
