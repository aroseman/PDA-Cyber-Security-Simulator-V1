using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDA_Cyber_Security_Simulator_V1;
using PDA_Cyber_Security_Simulator_Domain;
using PDA_Cyber_Security_Simulator_DAL.Common;

namespace PDA_Cyber_Security_Simulator_V1Tests
{
    [TestClass]
    public class NetworkTest
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        [TestInitialize()]
        public void TestInit()
        {
            unitOfWork.DeviceManager.DropDeviceTable();
            unitOfWork.DeviceManager.CreateDeviceTable();

            unitOfWork.NetworkManager.DropTable();
            unitOfWork.NetworkManager.CreateTable();
        }

        [TestMethod()]
        public void GetAndAddNetworksTest()
        {
            unitOfWork.NetworkManager.AddNetwork(new Network("Test"));

            int idCheck = unitOfWork.NetworkManager.GetMaxTableId();

            Assert.AreEqual(1, idCheck);
        }

        [TestMethod()]
        public void GetDeviceTest()
        {
            unitOfWork.NetworkManager.AddNetwork(new Network("Test2"));

            Device testDevice = new Device();
            testDevice.Name = "CiscoRouter";
            testDevice.IpAddress = "192.168.1.5";
            testDevice.Id = 1;
            unitOfWork.DeviceManager.AddDevice(testDevice);

            Device testDevice2 = new Device();
            testDevice2.Name = "CiscoFirewall";
            testDevice2.IpAddress = "192.168.1.6";
            testDevice2.Id = 1;
            unitOfWork.DeviceManager.AddDevice(testDevice2);

            int netid = unitOfWork.NetworkManager.GetNetworkIdByName("Test");

            List<Device> devices = unitOfWork.NetworkManager.GetDeviceByNetworkId(netid);

            Assert.AreEqual(2, devices.Count);
        }
    }
}
