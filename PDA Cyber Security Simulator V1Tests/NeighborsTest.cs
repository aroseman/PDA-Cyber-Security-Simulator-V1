using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDA_Cyber_Security_Simulator_V1;
using PDA_Cyber_Security_Simulator_V1.Domain;

namespace PDA_Cyber_Security_Simulator_V1Tests
{
    [TestClass]
    public class NeighborsTest
    {
        [TestInitialize()]
        public void TestInit()
        {
            Device.dropDeviceTable();
            Device.makeDeviceTable();

            Neighbors.dropNeighborsTable();
            Neighbors.makeNeighborsTable();

            Device testDevice = new Device();
            testDevice.Name = "CiscoRouter";
            testDevice.IpAddress = "192.168.1.5";
            Device.addDevice(testDevice);

            Device testDevice2 = new Device();
            testDevice.Name = "CiscoFirewall";
            testDevice.IpAddress = "192.168.1.6";
            Device.addDevice(testDevice);
        }

        [TestMethod()]
        public void AddNeighborTest()
        {
            Neighbors.addNeighbors(0, 1);

            int idCheck = Neighbors.getMaxTableID();

            Assert.AreEqual(1, idCheck);
        }

        [TestMethod()]
        public void GetNeighborsTest()
        {
            Neighbors.addNeighbors(0, 1);

            List<Neighbor> test = Neighbors.getNeighbors();

            Assert.AreEqual(0, test[0].d1);
            Assert.AreEqual(1, test[0].d2);
        }

    }
}
