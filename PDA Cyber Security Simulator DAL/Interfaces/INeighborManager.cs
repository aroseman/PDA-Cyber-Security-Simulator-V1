using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDA_Cyber_Security_Simulator_Domain;

namespace PDA_Cyber_Security_Simulator_DAL.Interfaces
{
    public interface INeighborManager
    {
        void MakeNeighborsTable();
        void DropNeighborsTable();
        void AddNeighbor(int deviceId, int neighborId);
        void RemoveNeighbor(int deviceId, int neighborId);
        List<Neighbors> GetNeighbors(int deviceId);
        int GetMaxTableID();
    }
}
