using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1
{
    public class TestNetworkPresenter
    {
        private TestNetwork view;

        public TestNetworkPresenter(TestNetwork newView)
        {
            view = newView;

            this.view.LoadNetworkNames(Network.getNetworkNames());
            this.view.LoadDevices(Device.getDevices());
        }

        public void OnNetworkSelected()
        {

        }
    }
}
