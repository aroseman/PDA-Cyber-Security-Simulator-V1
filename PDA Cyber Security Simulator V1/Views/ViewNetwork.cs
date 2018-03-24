using System;
using System.Collections.Generic;
using System.Drawing;
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

        public HomeView Home { get; }
        public TextBox TxtNetworkName { get; }
        public List<Label> DeviceNames { get; set; }
        public List<Label> IpLabels { get; set; }
        public List<Label> IpAddresses { get; set; }
        public List<PictureBox> DevicePictures { get; set; }
        public Panel PanelViewNetwork { get; set; }
        public Pen Pen = new Pen(Color.Black);
        public bool NetworkLoaded { get; set; }


        public PaintEventArgs PaintEventArgs { get; set; }

        public ViewNetwork(HomeView home)
        {
            InitializeComponent();
            InitializeLists();
            NetworkLoaded = false;
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Home = home;
            TxtNetworkName = txtNetworkName;
            PanelViewNetwork = pnlViewNetwork;
            btnLoadNetwork.Click += OnBtnLoadNetworkClick;
            this.pnlViewNetwork.Paint += OnFormPaint;
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

        private void OnFormPaint(object sender, PaintEventArgs e)
        {
            PaintEventArgs = e;
            FormPaint?.Invoke();
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
