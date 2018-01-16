using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace PDA_Cyber_Security_Simulator_V1
{
    class DeviceTester
    {
        public bool TestDevice(Device dev)
        {
            bool isAvailable = false;
            Ping pinger = new Ping();
            PingReply reply = pinger.Send(dev.IP);
            if (reply.Status == IPStatus.Success)
            {
                dev.Status = "Available";
                isAvailable = true;
            }
            return isAvailable;
        }

        public bool TestDevice(Network network)
        {
            bool isAvailable = false;
            Ping pinger = new Ping();
            foreach (Device dev in network.Devices)
            {
                PingReply reply = pinger.Send(dev.IP);
                dev.Status = "Available";
                isAvailable = true;
            }

            return isAvailable;
        }
    }
}
