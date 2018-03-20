using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDA_Cyber_Security_Simulator_Domain;

namespace PDA_Cyber_Security_Simulator_V1
{
    public interface TestNetworkInterface
    {
        event Action NetworkSelected;
        event Action RootCrumbClick;

        List<String> NetworkNames { get; }
        String SelectedNetwork { get; } 
        List<int> NetworkIDs { get; }
        List<Device> Devices { get; }
        List<Language> NetworkDataSource { get; }
        List<Language> DeviceDataSource { get; }
        NetworkTester NT { get; }
        HomeView Form1 { get; }
        HomeViewPresenter Form1Presenter { get; }

        void LoadNetworkNames(List<String> network);
        void LoadNetworkIDs(List<int> ids);
        void LoadDevices(List<Device> devices);
        void ShowView();
        void HideView();
    }
}
