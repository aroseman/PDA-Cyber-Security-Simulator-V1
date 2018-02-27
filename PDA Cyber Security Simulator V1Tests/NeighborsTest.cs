﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDA_Cyber_Security_Simulator_V1;

namespace PDA_Cyber_Security_Simulator_V1Tests
{
    [TestClass]
    public class NeighborsTest
    {
        [TestInitialize()]
        public void TestInit()
        {
            Neighbors.dropNeighborsTable();
            Neighbors.makeNeighborsTable();

            Device.dropDeviceTable();
            Device.makeDeviceTable();

            Device testDevice = new Device();
            testDevice.Name = "CiscoRouter";
            testDevice.IpAddress = "192.168.1.5";
            Device.addDevice(testDevice);

            Device testDevice2 = new Device();
            testDevice.Name = "CiscoFirewall";
            testDevice.IpAddress = "192.168.1.6";
            Device.addDevice(testDevice);
        }

        [TestMethod]
        public void AddNeighborTest()
        {
            Neighbors.addNeighbors(0, 1);
        }
    }
}