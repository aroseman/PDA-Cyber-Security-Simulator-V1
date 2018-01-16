using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1
{
    public interface Attack
    {
        void startAttack();
        void stopAttack();
        void computeStats();
    }
}
