using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1
{
    public class TestNetworkPresenter
    {
        private TestNetworkView view;

        public TestNetworkPresenter(TestNetworkView newView)
        {
            view = newView;

            this.view.LoadNetworkNames(Network.getNetworkNames());
            this.view.LoadDevices(Device.getDevices());
        }

        public void OnNetworkSelected()
        {

        }

        public void ShowView()
        {
            this.view.ShowView();
        }

        public void HideView()
        {
            this.view.HideView();
        }
    }
}
