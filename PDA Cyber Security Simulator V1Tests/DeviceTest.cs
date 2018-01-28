using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDA_Cyber_Security_Simulator_V1;

namespace PDA_Cyber_Security_Simulator_V1Tests
{
    [TestClass]
    public class DeviceTest
    {
        [TestMethod]
        public void addDeviceTest()
        {
            Device testDevice = new Device();
            testDevice.Name = "CiscoRouter";
            testDevice.IpAddress = "192.168.1.5";

            Device.addDevice(testDevice);
        }

        [TestMethod]
        public void getDevicesTest()
        {
            String devices = Device.getDevices();

            Debug.WriteLine(devices);
        }
    }
}
