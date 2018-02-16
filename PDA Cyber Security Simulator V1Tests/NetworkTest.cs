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
        public void AddNetworkTest()
        {
            Network.dropNetworkTable();
            Network.makeNetworkTable();

            Network.addNetwork(new Network());
        }

        [TestMethod]
        public void GetNetworksTest()
        {
            String[] networks = Network.getNetworkNames();

            for (int i = 0; i < networks.Length; i++)
            {
                Debug.WriteLine(networks[i]);
            }
        }

        [TestMethod]
        public void GetDeviceTest()
        {
            String[] devices = Network.getDeviceNames(1);

            for (int i = 0; i < devices.Length; i++)
            {
                Debug.WriteLine(devices[i]);
            }
        }
    }
}
