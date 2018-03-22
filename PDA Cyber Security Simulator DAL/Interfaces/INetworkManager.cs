using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDA_Cyber_Security_Simulator_Domain;

namespace PDA_Cyber_Security_Simulator_DAL.Interfaces
{
    public interface INetworkManager
    {
        void AddNetwork(Network newNetwork);
        void DeleteNetwork(int networkId);
        Network GetNetwork();
        void UpdateNetwork(int id, Network updatedItem);
        void CreateTable();
        void DropTable();
        List<Device> GetDeviceByNetworkId(int networkId);
        int GetMaxTableId();
        int GetNetworkIdByName(string networkName);
        Network GetNetworkByName(string networkName);
    }
}
