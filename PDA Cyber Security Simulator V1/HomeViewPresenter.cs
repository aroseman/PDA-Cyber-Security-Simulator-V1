using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1
{
    public class HomeViewPresenter
    {
        private HomeView view { get; set; }

        public HomeViewPresenter(HomeView newView)
        {
            this.view = newView;
            this.view.TestNetworkButtonClicked += ShowTestNetworkView;
            this.view.ConfigureNetworkButtonClicked += ShowNetBuilderView;
            this.view.SimulateAttackButtonClicked += ShowSimulateAttackView;
        }

        public void ShowTestNetworkView()
        {
            this.view.ShowTestNetworkView();
        }

        public void HideTestNetworkView()
        {
            this.view.HideTestNetworkView();
        }

        public void ShowNetBuilderView()
        {
            this.ShowNetBuilderView();
        }

        public void HideNetBuilderView()
        {
            this.HideNetBuilderView();
        }

        public void ShowSimulateAttackView()
        {
            this.ShowSimulateAttackView();
        }

        public void HideSimulateAttackView()
        {
            this.HideSimulateAttackView();
        }
    }
}
