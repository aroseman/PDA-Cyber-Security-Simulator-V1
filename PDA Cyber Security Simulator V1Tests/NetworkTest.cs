using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDA_Cyber_Security_Simulator_V1;

namespace PDA_Cyber_Security_Simulator_V1Tests
{
    [TestClass]
    public class NetworkTest
    {
        [TestMethod]
        public void addNetworkTest()
        {
            Network.dropNetworkTable();
            Network.makeNetworkTable();

            Network.addNetwork(new Network());
        }

        [TestMethod]
        public void getNetworksTest()
        {
            String[] networks = Network.getNetworks();

            for (int i = 0; i < networks.Length; i++)
            {
                Debug.WriteLine(networks[i]);
            }
        }

        [TestMethod]
        public void getDeviceTest()
        {
            String[] devices = Network.getDevices(1);

            for (int i = 0; i < devices.Length; i++)
            {
                Debug.WriteLine(devices[i]);
            }
        }
    }
}
