using System;
using System.Windows.Forms;
using PDA_Cyber_Security_Simulator_V1.Interfaces;


namespace PDA_Cyber_Security_Simulator_V1.Views
{
    public partial class ViewNetwork : Form, IViewNetwork
    {
        public event Action BtnLoadNetworkClick;

        public HomeView Home { get; }
        public TextBox TxtNetworkName { get; }

        public ViewNetwork(HomeView home)
        {
            InitializeComponent();
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Home = home;
            TxtNetworkName = txtNetworkName;
            btnLoadNetwork.Click += OnBtnLoadNetworkClick;
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
