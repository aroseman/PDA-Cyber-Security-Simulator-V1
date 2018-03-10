using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1
{
    public interface TestNetworkInterface
    {
        event Action NetworkSelected;

        List<String> NetworkNames { get; }
        List<int> NetworkIDs { get; }
        List<Device> Devices { get; }
        List<Language> NetworkDataSource { get; }
        List<Language> DeviceDataSource { get; }
        NetworkTester NT { get; }

        void LoadNetworkNames(List<String> network);
        void LoadNetworkIDs(List<int> ids);
        void LoadDevices(List<Device> devices);
        void ShowView();
        void HideView();
    }
}
