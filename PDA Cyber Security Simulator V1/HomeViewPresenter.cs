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
            this.view.Hide();
            this.view.ShowTestNetworkView();
        }

        public void HideTestNetworkView()
        {
            this.view.Show();
            this.view.HideTestNetworkView();
        }

        public void ShowNetBuilderView()
        {
            this.view.Hide();
            this.view.ShowNetBuilderView();
        }

        public void HideNetBuilderView()
        {
            this.view.Show();
            this.view.HideNetBuilderView();
        }

        public void ShowSimulateAttackView()
        {
            this.view.Hide();
            this.view.ShowSimulateAttackView();
        }

        public void HideSimulateAttackView()
        {
            this.view.Show();
            this.view.HideSimulateAttackView();
        }
    }
}
