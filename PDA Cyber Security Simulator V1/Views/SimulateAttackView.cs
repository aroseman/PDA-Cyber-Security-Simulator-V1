using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PDA_Cyber_Security_Simulator_V1.Controls;
using PDA_Cyber_Security_Simulator_Domain;
using PDA_Cyber_Security_Simulator_V1.Interfaces;
using PDA_Cyber_Security_Simulator_V1.Presenters;

namespace PDA_Cyber_Security_Simulator_V1.Views
{
    public partial class SimulateAttackView : Form, SimulateAttackInterface
    {
        #region Attributes
        private bool test = false;
        private bool IsThinClient = false;

        public List<Label> DeviceNames;
        public List<Label> PingLabels;
        public List<Label> PingTime;
        public List<Label> IpLabels;
        public List<Label> DeviceIp;

        public List<CirclePanelRed> RedDots;
        public List<CirclePanelGreen> GreenDots;

        public event Action NetworkSelected;
        public event Action RootCrumbClick;
        //public event Action BreadCrumbClick;
        public event Action ComboBoxClick;
        public event Action AttackNetworkClick;

        
        public HomeView Form1 { get; }
        public HomeViewPresenter Form1Presenter { get; }

        public List<String> NetworkNames { get { return this.attackNetworkComboBox1.DataSource as List<String>; } }
        public List<int> NetworkIDs { get; set; }
        //public List<Device> Devices { get { return this.attackNetworkListBox1.DataSource as List<Device>; } }
        public List<Device> Devices { get; set; }

        public List<Language> NetworkDataSource { get; set; }
        public List<Language> DeviceDataSource { get; set; }
        public NetworkTester NT { get; }
        public ComboBox AttackNetworkComboBox1 { get; set; }
        public ListBox AttackNetworkListBox1 { get; set; }
        #endregion


        public SimulateAttackView(HomeView form1)
        {
            this.Form1 = form1;
            NT = new NetworkTester();
            NetworkDataSource = new List<Language>();
            DeviceDataSource = new List<Language>();
            InitializeComponent();
            BindComponents();
            AttackNetworkComboBox1 = attackNetworkComboBox1;
            AttackNetworkListBox1 = attackNetworkListBox1;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            InitializeGraphics();
        }

        public SimulateAttackView(HomeViewPresenter form1Presenter)
        {
            Form1Presenter = form1Presenter;
            NT = new NetworkTester();

            InitializeComponent();
            BindComponents();
            AttackNetworkComboBox1 = attackNetworkComboBox1;
            AttackNetworkListBox1 = attackNetworkListBox1;
            //this.Form1Presenter = form1Presenter;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            InitializeGraphics();
        }

        private void BindComponents()
        {
            this.rootCrumb.Click += OnRootCrumbClick;
            this.attackNetworkComboBox1.DropDown += OnComboBoxClick;
            //this.testNetworkComboBox1.SelectionChangeCommitted += OnNetworkSelect; //( SelectionChangeCommitted += OnNetworkSelect);
            this.button1.Click += OnAttackNetworkClick;
        }

        private void InitializeGraphics()
        {
            var unsortedDeviceNames = new List<Label>();
            var unsortedPingLabels = new List<Label>();
            var unsortedPingTime = new List<Label>();
            var unsortedIpLabels = new List<Label>();
            var unsortedDeviceIp = new List<Label>();
            var unsortedRedDots = new List<CirclePanelRed>();
            var unsortedGreenDots = new List<CirclePanelGreen>();

            foreach (Control c in pnlTestStatus.Controls)
            {
                if (c is Label && c.Name.Contains("lblDevice"))
                {
                    unsortedDeviceNames.Add((Label)c);
                }
                else if (c is Label && c.Name.Contains("lblPingTime"))
                {
                    unsortedPingTime.Add((Label)c);
                }
                else if (c is Label && c.Name.Contains("lblPing"))
                {
                    unsortedPingLabels.Add((Label)c);
                }
                else if (c is Label && c.Name.Contains("lblIp"))
                {
                    unsortedIpLabels.Add((Label)c);
                }
                else if (c is Label && c.Name.Contains("lblAddress"))
                {
                    unsortedDeviceIp.Add((Label)c);
                }
                else if (c is CirclePanelGreen)
                {
                    unsortedGreenDots.Add((CirclePanelGreen)c);
                }
                else if (c is CirclePanelRed)
                {
                    unsortedRedDots.Add((CirclePanelRed)c);
                }
            }

            GreenDots = unsortedGreenDots.OrderBy(o => o.Name).ToList();
            RedDots = unsortedRedDots.OrderBy(o => o.Name).ToList();
            DeviceIp = unsortedDeviceIp.OrderBy(o => o.Name).ToList();
            DeviceNames = unsortedDeviceNames.OrderBy(o => o.Name).ToList();
            IpLabels = unsortedIpLabels.OrderBy(o => o.Name).ToList();
            PingLabels = unsortedPingLabels.OrderBy(o => o.Name).ToList();
            PingTime = unsortedPingTime.OrderBy(o => o.Name).ToList();

            for (int i = 0; i < RedDots.Count; i++)
            {
                RedDots[i].Hide();
                GreenDots[i].Hide();
                DeviceNames[i].Hide();
                DeviceIp[i].Hide();
                IpLabels[i].Hide();
                PingLabels[i].Hide();
                PingTime[i].Hide();
            }

            if (IsThinClient)
            {
                var bottom = tableLayoutPanel1.GetRowHeights();
                button1.Location = new Point(20, bottom[1] + bottom[0] + 100);
            }
            else
            {
                var bottom = tableLayoutPanel1.GetRowHeights();
                button1.Location = new Point(20, bottom[1] + bottom[0] - button1.Height - 15);
            }
        }

        /**
         * Populates testNetworkComboBox1 with all available networks.
         *
         **/

        public void LoadNetworkNames(List<String> network)
        {
            attackNetworkComboBox1.DataSource = network;
        }

        public void LoadDevices(List<Device> devices)
        {
            attackNetworkListBox1.DataSource = null;
            attackNetworkListBox1.Items.Clear();
            foreach (var t in devices)
            {
                attackNetworkListBox1.Items.Add(t);
            }
            attackNetworkListBox1.DataSource = devices;
        }

        public void LoadNetworkIDs(List<int> ids)
        {
            attackNetworkListBox1.DataSource = ids;
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

        private void OnAttackNetworkClick(object send, EventArgs e)
        {
            AttackNetworkClick?.Invoke();
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

        /*
        private void RootCrumbClick(object sender, System.EventArgs e)
        {
            if (this.BreadCrumbClick != null)
            {
                this.BreadCrumbClick();
            }

            //Need to relink this page to the home form (this needs to happen if the form has been cleared)
            Form1.SimulateAttackView = this;
            Form1.Show();
            this.Hide();
            

        }
        */


        
        private void lblDevices_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void AttacksComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NetworkComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.NetworkSelected?.Invoke();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
