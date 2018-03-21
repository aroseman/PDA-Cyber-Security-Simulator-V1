using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using PDA_Cyber_Security_Simulator_DAL.Interfaces;
using PDA_Cyber_Security_Simulator_DAL.Services;

namespace PDA_Cyber_Security_Simulator_DAL.Common
{
    public class UnitOfWork 
    {
        public INetworkManager NetworkManager { get; private set; }
        public IDeviceManager DeviceManager { get; private set; }
        public INeighborManager NeighborManager { get; private set; }
        private ConnectionStringSettings DbConnection = ConfigurationManager.ConnectionStrings["DbConnection"];

        public UnitOfWork()
        {
            string DbConnectionString = DbConnection.ConnectionString;
            NetworkManager = new NetworkManagerService(DbConnectionString);
            DeviceManager = new DeviceManagerService(DbConnectionString);
            NeighborManager = new NeighborManagerService(DbConnectionString);
        }
    }
}
