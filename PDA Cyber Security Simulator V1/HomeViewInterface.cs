using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1
{
    public interface HomeViewInterface
    {
        event Action TestNetworkButtonClicked;
        event Action ConfigureNetworkButtonClicked;
        event Action SimulateAttackButtonClicked;
        event Action ViewNetworkButtonClicked;
        event Action RootCrumbClicked;

        NetBuilder NetBuilder { get; }
        NetBuilderPresenter NetBuilderPresenter { get; }
        TestNetworkView TestNetwork { get; }
        TestNetworkPresenter TestNetworkPresenter { get; }
        SimulateAttackView SimulateAttackView { get; }
        SimulateAttackPresenter SimulateAttackPresenter { get; }

        void ShowTestNetworkView();
        void HideTestNetworkView();
        void ShowNetBuilderView();
        void HideNetBuilderView();
        void ShowSimulateAttackView();
        void HideSimulateAttackView();
    }
}
