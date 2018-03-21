using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDA_Cyber_Security_Simulator_V1;
using PDA_Cyber_Security_Simulator_Domain;
using PDA_Cyber_Security_Simulator_DAL.Common;

namespace PDA_Cyber_Security_Simulator_V1Tests
{
    [TestClass]
    public class NeighborsTest
    {
        private UnitOfWork UnitofWork = new UnitOfWork();

        [TestInitialize()]
        public void TestInit()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            unitOfWork.DeviceManager.DropDeviceTable();
            unitOfWork.DeviceManager.CreateDeviceTable();

            unitOfWork.NeighborManager.DropNeighborsTable();
            unitOfWork.NeighborManager.MakeNeighborsTable();

            Device testDevice = new Device();
            testDevice.Name = "CiscoRouter";
            testDevice.IpAddress = "192.168.1.5";
            unitOfWork.DeviceManager.AddDevice(testDevice);

            Device testDevice2 = new Device();
            testDevice.Name = "CiscoFirewall";
            testDevice.IpAddress = "192.168.1.6";
            unitOfWork.DeviceManager.AddDevice(testDevice2);
        }

        [TestMethod()]
        public void AddNeighborTest()
        {
            UnitofWork.NeighborManager.AddNeighbor(1, 2);

            int idCheck = UnitofWork.NeighborManager.GetMaxTableID();

            Assert.AreEqual(1, idCheck);
        }

        [TestMethod()]
        public void GetNeighborsTest()
        {
            Device device = new Device();
            Device neighbor = new Device();

            device.Id = 1;
            neighbor.Id = 3;

            UnitofWork.NeighborManager.AddNeighbor(device.Id, neighbor.Id);

            List<PDA_Cyber_Security_Simulator_Domain.Neighbors> test = UnitofWork.NeighborManager.GetNeighbors(device.Id);

            Assert.AreEqual(1, test[0].DeviceId);
            Assert.AreEqual(3, test[0].NeighborId);
        }

    }
}
