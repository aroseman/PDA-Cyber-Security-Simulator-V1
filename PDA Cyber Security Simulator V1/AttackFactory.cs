using PDA_Cyber_Security_Simulator_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1
{
    class AttackFactory
    {
        public AttackFactory()
        {

        }

        public IAttack SynFlood(Network victimNetwork)
        {
            SynFloodAttack synFlood = new SynFloodAttack(victimNetwork);

            return synFlood;
        }
    }
}
