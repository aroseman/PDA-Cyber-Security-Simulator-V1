using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDA_Cyber_Security_Simulator_V1.Presenters;
using PDA_Cyber_Security_Simulator_V1.Views;

namespace PDA_Cyber_Security_Simulator_V1.Interfaces
{
    public interface SimulateAttackInterface
    {
        event Action BreadCrumbClick;
        HomeView Form1 { get; }
        HomeViewPresenter Form1Presenter { get; }
    }
}
