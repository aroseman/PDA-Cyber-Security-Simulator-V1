﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace PDA_Cyber_Security_Simulator_Domain
{
    public class Network
    {

        public Network(string name)
        {
                Name = name;
        }

        public Network(string name, List<Device> devices)
        {
            Name = name;
            Devices = devices;
        }

        public Network()
        {
            Devices = new List<Device>();
            Name = string.Empty;
            Id = default(int);
        }

        public List<Device> Devices { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        /// <summary>
        /// This will add a device to a network
        /// </summary>
        /// <param name="dev"></param>
        public void AddDevice(Device dev)
        {
            Devices.Add(dev);
        }

        /// <summary>
        ///  Adds a virtual link between two devices.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void AddLink(Device a, Device b)
        {
            a.Neighbors.Add(b);
            b.Neighbors.Add(a);
        }

        /// <summary>
        /// Removes a device from the network.
        /// </summary>
        /// <param name="dev"></param>
        public void RemoveDevice(Device dev)
        {
            Devices.Remove(dev);
        }

        /// <summary>
        ///  Removes a link from two Devices.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void RemoveLink(Device a, Device b)
        {
            a.Neighbors.Remove(b);
            b.Neighbors.Remove(a);
        }
    }
}
