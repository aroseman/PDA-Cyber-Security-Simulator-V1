using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PDA_Cyber_Security_Simulator_V1.Controls;
using static System.Windows.Forms.ListBox;

namespace PDA_Cyber_Security_Simulator_V1
{
    public partial class TestNetworkView : Form, TestNetworkInterface
    {
        #region Attributes
        private bool test = false;
        private List<Label> DeviceNames;
        private List<Label> PingLabels;
        private List<Label> PingTime;
        private List<Label> IpLabels;
        private List<Label> DeviceIp;
        private List<CirclePanelRed> RedDots;
        private List<CirclePanelGreen> GreenDots;
        #endregion
        public event Action NetworkSelected;
        public event Action RootCrumbClick;
        public HomeView Form1 { get; }
        public HomeViewPresenter Form1Presenter { get; }
        public List<String> NetworkNames { get { return this.testNetworkComboBox1.DataSource as List<String>; } }
        public String SelectedNetwork { get { return this.testNetworkComboBox1.Text as String; } }
        public List<int> NetworkIDs { get; set; }
        public List<Device> Devices { get { return this.testNetworkListBox1.DataSource as List<Device>;} }
        public List<Language> NetworkDataSource { get; }
        public List<Language> DeviceDataSource { get; }
        public NetworkTester NT { get; }

        public TestNetworkView(HomeView form1)
        {
            Form1 = form1;
            NT = new NetworkTester();
            
            InitializeComponent();
            InitializeGraphics();
            BindComponents();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        public TestNetworkView(HomeViewPresenter form1Presenter)
        {
            Form1Presenter = form1Presenter;
            NT = new NetworkTester();

            InitializeComponent();
            InitializeGraphics();
            BindComponents();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        /*private void InitializeNetworkNames()
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
        }*/

        private void BindComponents()
        {
            this.testNetworkComboBox1.SelectedValueChanged += testNetworkComboBoxOnClick;
            this.rootCrumb.Click += OnRootCrumbClick;
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

       public void LoadNetworkNames(List<String> network)
        {
            testNetworkComboBox1.DataSource = network;
        }

        public void LoadDevices(List<Device> devices)
        {
            testNetworkListBox1.DataSource = null;
            testNetworkListBox1.Items.Clear();
            for (int i = 0; i < devices.Count; i++)
            {
                testNetworkListBox1.Items.Add(devices[i]);
            }
            testNetworkListBox1.DataSource = devices;
        }

        public void LoadNetworkIDs(List<int> ids)
        {
            testNetworkListBox1.DataSource = ids;
        }

        public void ShowView()
        {
            this.Show();
        }

        public void HideView()
        {
            this.Hide();
        }

        //Navigate back to Home screen
        private void OnRootCrumbClick(object sender, EventArgs e)
        {
            //Need to relink this page to the home form (this needs to happen if the form has been cleared)
            if (this.RootCrumbClick != null)
                this.RootCrumbClick();
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
                //testNetworkListBox1.Items.Clear();

                //List<Device> dList = Network.getDevices(testNetworkComboBox1.SelectedIndex);
                //for (int i = 0; i < dList.Count; i++)
                //{
                //    if (!String.IsNullOrEmpty(dList[i].Name))
                //        testNetworkListBox1.Items.Add(dList[i].Name);
                //}

                // InitializeDevices(Int32.Parse(testNetworkComboBox1.SelectedValue.ToString()));
                /*InitializeDevices(Int32.Parse(NetworkDataSource[testNetworkComboBox1.SelectedIndex].Value));
                InitializeDeviceDataSource();
                PopulateDeviceList();*/
                if (this.NetworkSelected != null)
                    this.NetworkSelected();

        }
    }
}
