using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDA_Cyber_Security_Simulator_V1.Views;

namespace PDA_Cyber_Security_Simulator_V1.Presenters
{
    public class SimulateAttackPresenter
    {
        private SimulateAttackView view { get; set; }

        public SimulateAttackPresenter(SimulateAttackView newView)
        {
            this.view = newView;
            this.view.BreadCrumbClick += OnBreadCrumbClick;
        }

        public void OnBreadCrumbClick()
        {
            this.view.Hide();
            this.view.Form1.Show();
        }
    }
}
