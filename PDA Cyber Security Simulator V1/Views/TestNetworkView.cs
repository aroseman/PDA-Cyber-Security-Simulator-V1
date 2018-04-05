using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PDA_Cyber_Security_Simulator_V1.Controls;
using PDA_Cyber_Security_Simulator_Domain;
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
        public event Action ComboBoxClick;
        public event Action TestNetworkClick;
        public HomeView Form1 { get; }
        public HomeViewPresenter Form1Presenter { get; }
        public List<String> NetworkNames { get { return this.testNetworkComboBox1.DataSource as List<String>; } }
        public String SelectedNetwork { get { return this.testNetworkComboBox1.Text as String; } }
        public List<int> NetworkIDs { get; set; }
        //public List<Device> Devices { get { return this.testNetworkListBox1.DataSource as List<Device>;}
        public List<Device> Devices { get; set; }
        public List<Language> NetworkDataSource { get; set; }
        public List<Language> DeviceDataSource { get; set; }
        public NetworkTester NT { get; }
        public ComboBox TestNetworkComboBox1 { get; set; }
        public ListBox TestNetworkListBox1 { get; set; }


        public TestNetworkView(HomeView form1)
        {
            Form1 = form1;
            NT = new NetworkTester();
            NetworkDataSource = new List<Language>();
            DeviceDataSource = new List<Language>();
            InitializeComponent();
            InitializeGraphics();
            BindComponents();
            TestNetworkComboBox1 = testNetworkComboBox1;
            TestNetworkListBox1 = testNetworkListBox1;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        public TestNetworkView(HomeViewPresenter form1Presenter)
        {
            Form1Presenter = form1Presenter;
            NT = new NetworkTester();

            InitializeComponent();
            InitializeGraphics();
            BindComponents();
            TestNetworkComboBox1 = testNetworkComboBox1;
            TestNetworkListBox1 = testNetworkListBox1;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

  

        private void BindComponents()
        {
            //this.testNetworkComboBox1.SelectedValueChanged += TestNetworkComboBoxOnClick;
            this.rootCrumb.Click += OnRootCrumbClick;
            this.testNetworkComboBox1.SelectedValueChanged += OnNetworkSelect;
            this.testNetworkComboBox1.Click += OnComboBoxClick;
            this.button1.Click += OnTestNetworkClick;
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
            foreach (var t in devices)
            {
                testNetworkListBox1.Items.Add(t);
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
            RootCrumbClick?.Invoke();
        }

        private void OnTestNetworkClick(object send, EventArgs e)
        {
            TestNetworkClick?.Invoke();
        }

        private void OnComboBoxClick(object sender, EventArgs e)
        {
            ComboBoxClick?.Invoke();
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

        private void OnNetworkSelect(object sender, EventArgs e)
        {

            this.NetworkSelected?.Invoke();

        }
    }
}
