using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            if (String.IsNullOrEmpty(Network.getNetworkNames()[0]))
                //Network.addNetwork(new Network("Test"));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
