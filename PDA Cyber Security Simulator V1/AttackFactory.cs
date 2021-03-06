﻿using PDA_Cyber_Security_Simulator_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1
{
    public class AttackFactory
    {
        public AttackFactory()
        {

        }

        public IAttack GetAttack(string attackName)
        {
            switch (attackName)
            {
                case "SynFlood": return new SynFloodAttack();
                case "ArpFlood": return new ArpFloodAttack();
                case "MacFlood": return new MacFloodAttack();
                default: throw new Exception();
            }
        }
    }
}
