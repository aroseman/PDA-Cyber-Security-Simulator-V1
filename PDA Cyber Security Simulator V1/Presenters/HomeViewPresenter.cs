using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1
{
    public class HomeViewPresenter
    {
        private HomeView View { get; set; }

        public HomeViewPresenter(HomeView newView)
        {
            this.View = newView;
            this.View.TestNetworkButtonClicked += ShowTestNetworkView;
            this.View.ConfigureNetworkButtonClicked += ShowNetBuilderView;
            this.View.SimulateAttackButtonClicked += ShowSimulateAttackView;
            this.View.RootCrumbClicked += ShowHomeView;
            View.ViewNetworkButtonClicked += ShowViewNetworkView;
        }

        public void ShowHomeView()
        {
            this.View.Load_Home();
        }

        public void ShowTestNetworkView()
        {
            this.View.Hide();
            this.View.ShowTestNetworkView();
        }

        public void HideTestNetworkView()
        {
            this.View.Show();
            this.View.HideTestNetworkView();
        }

        public void ShowNetBuilderView()
        {
            this.View.Hide();
            this.View.ShowNetBuilderView();
        }

        public void ShowViewNetworkView()
        {
            View.Hide();
            View.ShowViewNetworkView();
        }

        public void HideNetBuilderView()
        {
            this.View.Show();
            this.View.HideNetBuilderView();
        }

        public void ShowSimulateAttackView()
        {
            this.View.Hide();
            this.View.ShowSimulateAttackView();
        }

        public void HideSimulateAttackView()
        {
            this.View.Show();
            this.View.HideSimulateAttackView();
        }

        public void HideViewNetworkView()
        {
            View.Show();
            View.HideViewNetworkView();
        }
    }
}
