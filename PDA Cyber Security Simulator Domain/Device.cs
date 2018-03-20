using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace PDA_Cyber_Security_Simulator_Domain
{
    public class Device
    {
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public string MacAddress { get; set; }
        public string Description { get; set; }
        //1 is connected, 0 is disconnected
        public bool Status { get; set; }
        //Contains Neighboring IP Addresses
        public List<Device> Neighbors { get; set; }
        public string Notes { get; set; }
        public int Id { get; set; }
        public bool Configured { get; set; }

        public int NetworkId { get; set; }

        public Device()
        {
            Name = string.Empty;
            IpAddress = string.Empty;
            MacAddress = string.Empty;
            Description = string.Empty;
            Status = false;
            Neighbors = new List<Device>();
            Notes = string.Empty;
            Id = default(int);
            Configured = false;
            NetworkId = default(int);
        }
        public Device(string name, string ip, string mac, string description, string notes)
        {
            Name = name;
            IpAddress = ip;
            MacAddress = mac;
            Description = description;
            Notes = notes;
            Neighbors = new List<Device>();
            Configured = false;
        }
    }
}