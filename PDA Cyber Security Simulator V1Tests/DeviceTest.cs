using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PDA_Cyber_Security_Simulator_V1Tests
{
    [TestClass]
    public class DeviceTest
    {
        [TestInitialize()]
        public void TestInit()
        {
            Device.dropDeviceTable();
            Device.makeDeviceTable();
            Device testDevice = new Device();
            testDevice.Name = "CiscoRouter";
            testDevice.IpAddress = "192.168.1.5";

            Device.addDevice(testDevice);
        }

        [TestMethod]
        public void AddDeviceTest()
        {

            Device testDevice = new Device();
            testDevice.Name = "CiscoRouter";
            testDevice.IpAddress = "192.168.1.5";

            Device.addDevice(testDevice);
        }

        [TestMethod]
        public void GetDevicesTest()
        {
            List<Device> devices = Device.getDevices();

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
            Device.addDevice(testDevice);
            Device.removeDevice(testDevice);
        }

        [TestMethod]
        public void DeviceMaxIDTest()
        {
            int testMax = Device.getMaxTableID();
            Console.WriteLine(testMax.ToString());
        }
            
    }
}
