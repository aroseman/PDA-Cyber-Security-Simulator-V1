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
        [TestInitialize()]
        public void TestInit()
        {
            Device.dropDeviceTable();
            Device.makeDeviceTable();

            Network.dropNetworkTable();
            Network.makeNetworkTable();
        }

        [TestMethod()]
        public void GetAndAddNetworksTest()
        {
            Network.addNetwork(new Network());

            int idCheck = Network.getMaxTableID();

            Assert.AreEqual(1, idCheck);
        }

        [TestMethod()]
        public void GetDeviceTest()
        {
            Network.addNetwork(new Network());

            Device testDevice = new Device();
            testDevice.Name = "CiscoRouter";
            testDevice.IpAddress = "192.168.1.5";
            testDevice.NetID = 1;
            Device.addDevice(testDevice);

            Device testDevice2 = new Device();
            testDevice2.Name = "CiscoFirewall";
            testDevice2.IpAddress = "192.168.1.6";
            testDevice2.NetID = 1;
            Device.addDevice(testDevice2);

            List<Device> devices = Network.getDevices(1);

            Assert.AreEqual(2, devices.Count);
        }
    }
}
