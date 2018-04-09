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

        public IAttack GetAttack(string attackName)
        {
            switch (attackName)
            {
                case "SynFlood": return new SynFloodAttack();
                default: throw new Exception();
            }
        }
    }
}
