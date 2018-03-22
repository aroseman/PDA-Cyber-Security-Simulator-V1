using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PDA_Cyber_Security_Simulator_V1.Interfaces;


namespace PDA_Cyber_Security_Simulator_V1.Views
{
    public partial class ViewNetwork : Form, IViewNetwork
    {
        public event Action BtnLoadNetworkClick;

        public HomeView Home { get; }
        public TextBox TxtNetworkName { get; }
        public List<Label> DeviceNames { get; set; }
        public List<Label> IpLabels { get; set; }
        public List<Label> IpAddresses { get; set; }

        public ViewNetwork(HomeView home)
        {
            InitializeComponent();
            InitializeLists();
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Home = home;
            TxtNetworkName = txtNetworkName;
            btnLoadNetwork.Click += OnBtnLoadNetworkClick;
        }

        private void InitializeLists()
        {
            DeviceNames = new List<Label>();
            IpLabels = new List<Label>();
            IpAddresses = new List<Label>();

            foreach (Control c in pnlViewNetwork.Controls)
            {
                if (c is Label && c.Name.Contains("lblDevice"))
                {
                    DeviceNames.Add((Label)c);
                }
                else if (c is Label && c.Name.Contains("lblIp"))
                {
                    IpLabels.Add((Label)c);
                }
                else if (c is Label && c.Name.Contains("lblAddress"))
                {
                    IpAddresses.Add((Label)c);
                }
            }

            for (var i = 0; i < DeviceNames.Count; i++)
            {
                DeviceNames[i].Visible = false;
                IpLabels[i].Visible = false;
                IpAddresses[i].Visible = false;
            }
        }

        private void OnBtnLoadNetworkClick(object sender, EventArgs e)
        {
            BtnLoadNetworkClick?.Invoke();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (Visible)
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
}
