using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDA_Cyber_Security_Simulator_V1;

namespace PDA_Cyber_Security_Simulator_V1Tests
{
    [TestClass]
    public class AttackTest
    {
        AttackFactory factory = new AttackFactory();

        [TestMethod()]
        public void SynFloodTest()
        {
            IAttack attack = factory.GetAttack("SynFlood");
            attack.AttackDevice("192.168.1.200", "00-00-00-00-00-00");
        }

        [TestMethod()]
        public void ArpFloodTest()
        {
            IAttack attack = factory.GetAttack("ArpFlood");
            attack.AttackDevice("192.168.1.200", "00-00-00-00-00-00");
        }

        [TestMethod()]
        public void MacFloodTest()
        {
            IAttack attack = factory.GetAttack("MacFlood");
            attack.AttackDevice("192.168.1.200", "00-00-00-00-00-00");
        }

    }
}
