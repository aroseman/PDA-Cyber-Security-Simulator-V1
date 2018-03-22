using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDA_Cyber_Security_Simulator_Domain;

namespace PDA_Cyber_Security_Simulator_DAL.Interfaces
{
    public interface IDeviceManager
    {
        void AddDevice(Device newDevice);
        void DeleteDevice(Device deviceToDelete);
        List<string> GetDeviceNames();
        List<Device> GetDevices();
        void CreateDeviceTable();
        void DropDeviceTable();
        int GetMaxTableId();
        List<Device> GetDevicesByNetworkId(int networkId);
        int GetDeviceIdByNameAndNetworkId(string deviceName, int networkId);
        Device GetDeviceById(int deviceId);
    }
}
