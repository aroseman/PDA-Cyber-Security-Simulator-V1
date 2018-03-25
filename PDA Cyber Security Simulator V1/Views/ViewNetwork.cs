using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using PDA_Cyber_Security_Simulator_V1.Interfaces;
using PDA_Cyber_Security_Simulator_V1.Presenters;


namespace PDA_Cyber_Security_Simulator_V1.Views
{
    public partial class ViewNetwork : Form, IViewNetwork
    {
        public event Action BtnLoadNetworkClick;
        public event Action FormPaint;
        public event Action RootCrumbClick;
        public event Action ComboViewNetworkClick;
        public event Action BtnResetViewNetworkClick;

        public HomeView Home { get; }
        public List<Label> DeviceNames { get; set; }
        public List<Label> IpLabels { get; set; }
        public List<Label> IpAddresses { get; set; }
        public List<PictureBox> DevicePictures { get; set; }
        public Button BtnResetViewNetwork { get; set; }
        public Button BtnLoadNetwork { get; set; }
        public ComboBox ComboNetworkNames { get; set; }
        public Panel PanelViewNetwork { get; set; }
        public Pen Pen = new Pen(Color.Black, 3);
        public bool NetworkLoaded { get; set; }

        public PaintEventArgs PaintEventArgs { get; set; }

        public ViewNetwork(HomeView home)
        {
            InitializeComponent();
            InitializeLists();
            NetworkLoaded = false;
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Home = home;
            ComboNetworkNames = comboNetworkNames;
            PanelViewNetwork = pnlViewNetwork;
            BtnResetViewNetwork = btnResetViewNetwork;
            BtnLoadNetwork = btnLoadNetwork;
            btnLoadNetwork.Click += OnBtnLoadNetworkClick;
            pnlViewNetwork.Paint += OnFormPaint;
            rootCrumb.Click += OnRootCrumbClick;
            comboNetworkNames.Click += OnComboViewNetworkClick;
            btnResetViewNetwork.Click += OnBtnResetViewNetworkClick;
        }

        private void InitializeLists()
        {
            DeviceNames = new List<Label>();
            IpLabels = new List<Label>();
            var unsortedIpAddresses = new List<Label>();
            var unsortedDevicePictures = new List<PictureBox>();
            var unsortedDeviceNames = new List<Label>();
            var unsortedIpLabels = new List<Label>();

            foreach (Control c in pnlViewNetwork.Controls)
            {
                if (c is Label && c.Name.Contains("lblDevice"))
                {
                    unsortedDeviceNames.Add((Label)c);
                }
                else if (c is Label && c.Name.Contains("lblIp"))
                {
                    unsortedIpLabels.Add((Label)c);
                }
                else if (c is Label && c.Name.Contains("lblAddress"))
                {
                    unsortedIpAddresses.Add((Label)c);
                }
                else if (c is PictureBox && c.Name.Contains("picDevice"))
                {
                    unsortedDevicePictures.Add((PictureBox)c);
                }
            }

            DevicePictures = unsortedDevicePictures.OrderBy(o => o.Name).ToList();
            IpAddresses = unsortedIpAddresses.OrderBy(o => o.Name).ToList();
            DeviceNames = unsortedDeviceNames.OrderBy(o => o.Name).ToList();
            IpLabels = unsortedIpLabels.OrderBy(o => o.Name).ToList();

            for (var i = 0; i < DeviceNames.Count; i++)
            {
                DeviceNames[i].Visible = false;
                IpLabels[i].Visible = false;
                IpAddresses[i].Visible = false;
                DevicePictures[i].Visible = false;
            }
        }

        private void OnRootCrumbClick(object sender, EventArgs e)
        {
            RootCrumbClick?.Invoke();
        }

        private void OnFormPaint(object sender, PaintEventArgs e)
        {
            PaintEventArgs = e;
            FormPaint?.Invoke();
        }

        private void OnBtnLoadNetworkClick(object sender, EventArgs e)
        {
            BtnLoadNetworkClick?.Invoke();
        }

        private void OnComboViewNetworkClick(object sender, EventArgs e)
        {
            ComboViewNetworkClick?.Invoke();
        }

        private void OnBtnResetViewNetworkClick(object sender, EventArgs e)
        {
            BtnResetViewNetworkClick?.Invoke();
        }

        public void ShowHomeView()
        {
            Home.ViewNetwork = this;
            Home.Show();
            this.Hide();
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
