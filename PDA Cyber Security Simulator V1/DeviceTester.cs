using PDA_Cyber_Security_Simulator_Domain;
using System.Net.NetworkInformation;

namespace PDA_Cyber_Security_Simulator_V1
{
    class DeviceTester
    {
        public bool TestDevice(Device dev)
        {
            bool isAvailable = false;
            Ping pinger = new Ping();
            PingReply reply = pinger.Send(dev.IpAddress);
            if (reply.Status == IPStatus.Success)
            {
                dev.Status = true;
                isAvailable = true;
            }
            return isAvailable;
        }

        public void TestDevice(Network network)
        {
            
            Ping pinger = new Ping();
            foreach (Device dev in network.Devices)
            {
                PingReply reply = pinger.Send(dev.IpAddress);
                if(reply.Status == IPStatus.Success)
                {
                    dev.Status = true;
                }
                
                
            }

           
        }
    }
}
