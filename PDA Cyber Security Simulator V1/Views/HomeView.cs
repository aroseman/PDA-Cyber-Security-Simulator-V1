using System;
using System.Drawing;
using System.Windows.Forms;
using PDA_Cyber_Security_Simulator_V1.Interfaces;
using PDA_Cyber_Security_Simulator_V1.Presenters;

namespace PDA_Cyber_Security_Simulator_V1.Views
{
    public partial class HomeView : Form, HomeViewInterface
    {
        public event Action TestNetworkButtonClicked;
        public event Action ConfigureNetworkButtonClicked;
        public event Action SimulateAttackButtonClicked;
        public event Action ViewNetworkButtonClicked;
        public event Action RootCrumbClicked;
        public NetBuilder NetBuilder { get; set; }
        public NetBuilderPresenter NetBuilderPresenter { get; set; }
        public TestNetworkView TestNetwork { get; set; }
        public TestNetworkPresenter TestNetworkPresenter { get; set; }
        public SimulateAttackView SimulateAttackView { get; set; }
        public SimulateAttackPresenter SimulateAttackPresenter { get; set; }
        public ViewNetwork ViewNetwork { get; set; }
        public ViewNetworkPresenter ViewNetworkPresenter { get; set; }
        public Rectangle ScreenSize { get; set; }

        public HomeView()
        {
            InitializeComponent();
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            testNetwork.Click += OnTestNetworkButtonClicked;
            testNetworkLabel.Click += OnTestNetworkButtonClicked;
            simulateAttack.Click += OnSimulateAttackButtonClicked;
            simulateAttackLabel.Click += OnSimulateAttackButtonClicked;
            viewNetwork.Click += OnViewNetworkButtonClicked;
            viewNetworkLabel.Click += OnViewNetworkButtonClicked;
            configureNetwork.Click += OnConfigureNetworkButtonClicked;
            configureNetworkLabel.Click += OnConfigureNetworkButtonClicked;
            rootCrumb.Click += OnRootCrumbClicked;
            NetBuilder = new NetBuilder(this);
            NetBuilderPresenter = new NetBuilderPresenter(this.NetBuilder);
            TestNetwork = new TestNetworkView(this);
            TestNetworkPresenter = new TestNetworkPresenter(this.TestNetwork);
            SimulateAttackView = new SimulateAttackView(this);
            SimulateAttackPresenter = new SimulateAttackPresenter(this.SimulateAttackView);
            ViewNetwork = new ViewNetwork(this);
            ViewNetworkPresenter = new ViewNetworkPresenter(ViewNetwork);
            var screen = Screen.FromControl(this);
            ScreenSize = screen.WorkingArea;
        }

        private void OnTestNetworkButtonClicked(object sender, EventArgs e)
        {
            if (this.TestNetworkButtonClicked != null)
                this.TestNetworkButtonClicked();
        }

        private void OnConfigureNetworkButtonClicked(object sender, EventArgs e)
        {
            if (this.ConfigureNetworkButtonClicked != null)
                this.ConfigureNetworkButtonClicked();
        }

        private void OnSimulateAttackButtonClicked(object sender, EventArgs e)
        {
            if (this.SimulateAttackButtonClicked != null)
                this.SimulateAttackButtonClicked();
        }

        private void OnViewNetworkButtonClicked(object sender, EventArgs e)
        {
            if (this.ViewNetworkButtonClicked != null)
                this.ViewNetworkButtonClicked();
        }

        private void OnRootCrumbClicked(object sender, EventArgs e)
        {
            if (this.RootCrumbClicked != null)
                this.RootCrumbClicked();
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

        /*private void conifgureNetworkOnClick(object sender, EventArgs e)
        {

            //homeScreen.Visible = false;
            //breadCrumbFlowLayoutPanel.BackColor = Color.FromArgb(240,144,24);
            //imagePanel.BackColor = Color.FromArgb(240, 144, 24);
            //networkConfigurationPanel.Visible = true;

            if(NetBuilder == null)
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
            //////////////////////////////////DO NOT DELETE////////////////////////////
            if (TestNetwork == null)
            {
                TestNetworkView newTestNetwork = new TestNetworkView(this);
                TestNetwork = newTestNetwork;
                TestNetworkPresenter testNetworkPresenter = new TestNetworkPresenter(newTestNetwork);
                TestNetworkPresenter = testNetworkPresenter;
                TestNetworkPresenter.ShowView();
            }
            else
            {
                TestNetworkPresenter.ShowView();
                this.Hide();
            }
            //////////////////////////////////DO NOT DELETE////////////////////////////

            //homeScreen.Visible = false;
            //breadCrumbFlowLayoutPanel.BackColor = Color.FromArgb(0, 144, 120);
            //imagePanel.BackColor = Color.FromArgb(0, 144, 120);

            //testNetworkComboBox1.ResetText();
            //testNetworkComboBox1.SelectedIndex = -1;
            //testNetworkComboBox1.Items.Clear();
            //testNetworkListBox1.Items.Clear();

            //String[] nList = Network.getNetworkNames();
            //for (int i = 0; i < nList.Length; i++)
            //{
            //    if (!String.IsNullOrEmpty(nList[i]))
            //        testNetworkComboBox1.Items.Add(nList[i]);
            //}

            //testNetworkTableLayoutPanel.Visible = true;
        }

        private void testNetworkComboBoxOnClick(object sender, EventArgs e)
        {
            if (testNetworkComboBox1.SelectedIndex != -1)
            {
                testNetworkListBox1.Items.Clear();

                List<Device> dList = Network.getDevices(testNetworkComboBox1.SelectedIndex);
                for (int i = 0; i < dList.Count; i++)
                {
                    if (!String.IsNullOrEmpty(dList[i].Name))
                        testNetworkListBox1.Items.Add(dList[i].Name);
                }

                /*String[] dList = Network.getDeviceNames(testNetworkComboBox1.SelectedIndex);
                for (int i = 0; i < dList.Length; i++)
                {
                    if (!String.IsNullOrEmpty(dList[i]))
                        testNetworkListBox1.Items.Add(dList[i]);
                }
            }
        }

        private void simulateAttackPanelOnClick(object sender, EventArgs e)
        {
            //working on it
            if (SimulateAttack == null)
            {
                SimulateAttackView newsimulateattack = new SimulateAttackView(this);
                SimulateAttack = newsimulateattack;
                this.Hide();
                newsimulateattack.Show();
            }
            else
            {
                SimulateAttack.Show();
                this.Hide();
            }

            // DON'T DELETE
            /*
            homeScreen.Visible = false;
            breadCrumbFlowLayoutPanel.BackColor = Color.FromArgb(0, 120, 192);
            imagePanel.BackColor = Color.FromArgb(0, 120, 192);
            simulateAttackTableLayoutPanel.Visible = true;
            Console.WriteLine("Simulate Attack");
            
        }*/

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Load_Home()
        {
           
            homeScreen.Visible = true;
            breadCrumbFlowLayoutPanel.BackColor = Color.FromName("Control");
            imagePanel.BackColor = Color.FromName("Control");
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
   //         networkTester.TestDevice("www.google.com", pingResultTextBox);

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

        private void simulateAttackTableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void ShowTestNetworkView()
        {
            this.TestNetwork.ShowView();
        }

        public void HideTestNetworkView()
        {
            this.TestNetwork.HideView();
        }

        public void ShowNetBuilderView()
        {
            this.NetBuilder.Show();
        }

        public void ShowViewNetworkView()
        {
            ViewNetwork.Show();
        }

        public void HideNetBuilderView()
        {
            this.NetBuilder.Hide();
        }

        public void ShowSimulateAttackView()
        {
            this.SimulateAttackView.Show();
        }

        public void HideSimulateAttackView()
        {
            this.SimulateAttackView.Hide();
        }

        public void HideViewNetworkView()
        {
            ViewNetwork.Hide();
        }
    }
}
