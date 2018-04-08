using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDA_Cyber_Security_Simulator_Domain;
using PDA_Cyber_Security_Simulator_DAL.Common;

namespace PDA_Cyber_Security_Simulator_V1Tests
{
    [TestClass]
    public class DeviceTest
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        [TestInitialize()]
        public void TestInit()
        {
            unitOfWork.DeviceManager.DropDeviceTable();
            unitOfWork.DeviceManager.CreateDeviceTable();
            Device testDevice = new Device();
            testDevice.Name = "CiscoRouter";
            testDevice.IpAddress = "192.168.1.5";

            unitOfWork.DeviceManager.AddDevice(testDevice);
        }

        [TestMethod]
        public void AddDeviceTest()
        {

            Device testDevice = new Device();
            testDevice.Name = "CiscoRouter";
            testDevice.IpAddress = "192.168.1.5";

            unitOfWork.DeviceManager.AddDevice(testDevice);
        }

        [TestMethod]
        public void GetDevicesTest()
        {
            List<Device> devices = unitOfWork.DeviceManager.GetDevices();

            for (int i = 0; i < devices.Count; i++)
            {
                if (devices[i] != null)
                    Console.WriteLine(devices[i].Name);
            }
        }

        [TestMethod]
        public void DropDeviceTest()
        {
            Device testDevice = new Device();
            unitOfWork.DeviceManager.AddDevice(testDevice);
            unitOfWork.DeviceManager.DeleteDevice(testDevice);
        }

        [TestMethod]
        public void DeviceMaxIDTest()
        {
            int testMax = unitOfWork.DeviceManager.GetMaxTableId();
            Console.WriteLine(testMax.ToString());
        }
            
    }
}
