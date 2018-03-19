using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDA_Cyber_Security_Simulator_V1;
using PDA_Cyber_Security_Simulator_V1.Domain;

namespace PDA_Cyber_Security_Simulator_V1Tests
{
    [TestClass]
    public class Layer3AttackTest : Layer3Attack
    {
        public Layer3AttackTest()
        {
            selectedNetwork = new Network("Test");
        }

        public Layer3AttackTest(Network netname)
        {
            selectedNetwork = netname;
        }

        [TestMethod]
        public void constructLayer3AttackTest()
        {
            Layer3AttackTest testAttack;
            Network testNetwork;

            testNetwork = new Network("Test");
            testAttack = new Layer3AttackTest(testNetwork);
            testAttack = new Layer3AttackTest();
        }
    }
}
