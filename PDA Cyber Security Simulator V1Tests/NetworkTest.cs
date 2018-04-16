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

            unitOfWork.NeighborManager.DropNeighborsTable();
            unitOfWork.NeighborManager.MakeNeighborsTable();
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

        [TestMethod()]
        public void PushAndPullEntireNetworkTest()
        {
            unitOfWork.NetworkManager.AddNetwork(new Network("TestNetwork"));
            var id = unitOfWork.NetworkManager.GetNetworkIdByName("TestNetwork");

            var device1 = new Device()
            {
                Name = "dev1",
                Configured = false,
                Description = "This is a test",
                Id = default(int),
                IpAddress = "1.1.1.1",
                MacAddress = "00-00-00-00-00-00",
                Neighbors = new List<Device>(),
                NetworkId = id,
                Notes = "This is a test",
                Status = false
            };

            var device2 = new Device()
            {
                Name = "dev2",
                Configured = false,
                Description = "This is a test",
                Id = default(int),
                IpAddress = "2.2.2.2",
                MacAddress = "00-00-00-00-00-01",
                Neighbors = new List<Device>(),
                NetworkId = id,
                Notes = "This is a test",
                Status = false
            };

            var device3 = new Device()
            {
                Name = "dev3",
                Configured = false,
                Description = "This is a test",
                Id = default(int),
                IpAddress = "3.3.3.3",
                MacAddress = "00-00-00-00-00-02",
                Neighbors = new List<Device>(),
                NetworkId = id,
                Notes = "This is a test",
                Status = false
            };

            unitOfWork.DeviceManager.AddDevice(device1);
            unitOfWork.DeviceManager.AddDevice(device2);
            unitOfWork.DeviceManager.AddDevice(device3);
            device1.Id = unitOfWork.DeviceManager.GetDeviceIdByNameAndNetworkId(device1.Name, id);
            device2.Id = unitOfWork.DeviceManager.GetDeviceIdByNameAndNetworkId(device2.Name, id);
            device3.Id = unitOfWork.DeviceManager.GetDeviceIdByNameAndNetworkId(device3.Name, id);

            device1.Neighbors.Add(device2);
            device1.Neighbors.Add(device3);
            device2.Neighbors.Add(device1);
            device2.Neighbors.Add(device3);
            device3.Neighbors.Add(device1);
            device3.Neighbors.Add(device2);

            foreach (var neighbor in device1.Neighbors)
            {
                unitOfWork.NeighborManager.AddNeighbor(device1.Id, neighbor.Id);
            }

            foreach (var neighbor in device2.Neighbors)
            {
                unitOfWork.NeighborManager.AddNeighbor(device2.Id, neighbor.Id);
            }

            foreach (var neighbor in device3.Neighbors)
            {
                unitOfWork.NeighborManager.AddNeighbor(device3.Id, neighbor.Id);
            }

            var network = unitOfWork.NetworkManager.GetNetworkByName("TestNetwork");
            var devices = unitOfWork.NetworkManager.GetDeviceByNetworkId(network.Id);

            foreach (var device in devices)
            {
                var neighbors = unitOfWork.NeighborManager.GetNeighbors(device.Id);

                foreach (var neighbor in neighbors)
                {
                    var neighborDevice = unitOfWork.DeviceManager.GetDeviceById(neighbor.NeighborId);
                    device.Neighbors.Add(neighborDevice);
                }
            }

            var neighborCheckList = true;
            var neighborCheck1 = false;
            var neighborCheck2 = false;
            var neighborCheck3 = false;

            foreach (var device in devices)
            {
                if (device.Neighbors.Count != 2)
                {
                    neighborCheckList = false;
                    break;
                }

                foreach (var neighbor in device.Neighbors)
                {
                    if (neighbor.Name == device1.Name)
                        neighborCheck1 = true;
                    else if (neighbor.Name == device2.Name)
                        neighborCheck2 = true;
                    else if (neighbor.Name == device3.Name)
                        neighborCheck3 = true;
                    else
                    {
                        neighborCheck1 = false;
                        neighborCheck2 = false;
                        neighborCheck3 = false;
                        break;
                    }
                }
            }

            Assert.IsTrue(neighborCheckList && neighborCheck1 && neighborCheck2 && neighborCheck3);
        }
    }
}
