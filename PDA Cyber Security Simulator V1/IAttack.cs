using PDA_Cyber_Security_Simulator_Domain;

namespace PDA_Cyber_Security_Simulator_V1
{
    public interface IAttack
    {
        Network Victim { get; set; }
        void AttackNetwork();
        void AttackDevice(string victimIpAddress, string victimMacAddress);
    }
}
