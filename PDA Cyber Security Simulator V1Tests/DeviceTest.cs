using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDA_Cyber_Security_Simulator_V1;

namespace PDA_Cyber_Security_Simulator_V1Tests
{
    [TestClass]
    public class DeviceTest
    {
        /*[TestInitialize]
        public void testInit()
        {
            Device.dropDeviceTable();
            Device.makeDeviceTable();
        }*/

        [TestMethod]
        public void addDeviceTest()
        {
            Device.dropDeviceTable();
            Device.makeDeviceTable();

            Device testDevice = new Device();
            testDevice.Name = "CiscoRouter";
            testDevice.IpAddress = "192.168.1.5";

            Device.addDevice(testDevice);
        }

        [TestMethod]
        public void getDevicesTest()
        {
            Device[] devices = Device.getDevices();

            for (int i = 0; i < devices.Length; i++)
            {
                Console.WriteLine(devices[i].Name);
            }
        }

        [TestMethod]
        public void dropDeviceTest()
        {
            Device testDevice = new Device();
            Device.removeDevice(testDevice);
        }
    }
}
