using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDA_Cyber_Security_Simulator_V1;

namespace PDA_Cyber_Security_Simulator_V1Tests
{
    [TestClass]
    public class Layer2AttackTest : Layer2Attack
    {
        public Layer2AttackTest()
        {
            selectedNetwork = new Network("Test");
        }

        public Layer2AttackTest(Network netname)
        {
            selectedNetwork = netname;
        }

        [TestMethod]
        public void constructLayer2AttackTest()
        {
            Layer2AttackTest testAttack;
            Network testNetwork;

            testNetwork = new Network("Test");
            testAttack = new Layer2AttackTest(testNetwork);
            testAttack = new Layer2AttackTest();
        }
    }
}
