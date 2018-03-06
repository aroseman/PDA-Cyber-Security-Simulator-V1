using System;
using System.Collections.Generic;
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
            List<String> networks = Network.getNetworkNames();

            for (int i = 0; i < networks.Count; i++)
            {
                Debug.WriteLine(networks[i]);
            }
        }

        [TestMethod]
        public void GetDeviceTest()
        {
            List<String> devices = Network.getDeviceNames(1);

            for (int i = 0; i < devices.Count; i++)
            {
                Debug.WriteLine(devices[i]);
            }
        }

        [TestMethod]
        public void NetworkMaxIDTest()
        {
            int testMax = Network.getMaxTableID();
            Console.WriteLine(testMax.ToString());
        }
    }
}
