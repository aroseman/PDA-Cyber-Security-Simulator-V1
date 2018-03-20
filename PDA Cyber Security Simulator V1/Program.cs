using PDA_Cyber_Security_Simulator_Domain;
using System;
using System.Windows.Forms;

namespace PDA_Cyber_Security_Simulator_V1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Makes tables on first install
            Device.makeDeviceTable();
            Network.makeNetworkTable();

            // Adds a test network on first install
            if (Network.getNetworkNames().Count == 0)
                Network.addNetwork(new Network("Test"));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            HomeView homeView = new HomeView();
            HomeViewPresenter homeViewPresenter = new HomeViewPresenter(homeView);
            Application.Run(homeView);
        }
    }
}
