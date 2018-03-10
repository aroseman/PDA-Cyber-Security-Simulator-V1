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

        NetBuilder NetBuilder { get; }
        TestNetworkView TestNetwork { get; }
        TestNetworkPresenter TestNetworkPresenter { get; }
        SimulateAttack SimulateAttack { get; }

        void ShowTestNetworkView();
        void HideTestNetworkView();
        void ShowNetBuilderView();
        void HideNetBuilderView();
        void ShowSimulateAttackView();
        void HideSimulateAttackView();
    }
}
