﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1.DAL
{
    public class UnitOfWork 
    {
        public NetworkManager networkManager;
        public DeviceManager deviceManager;

        public UnitOfWork()
        {
            networkManager = new NetworkManager();
            deviceManager = new DeviceManager();
        }
    }
}
