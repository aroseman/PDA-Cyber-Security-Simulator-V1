using System.Data.SQLite;
using System.Collections.Generic;

namespace PDA_Cyber_Security_Simulator_Domain
{
    public class Neighbors
    {
        public int DeviceId { get; set; }
        public int NeighborId { get; set; }

        public Neighbors()
        {
            DeviceId = default(int);
            NeighborId = default(int);
        }

        public Neighbors(int deviceId, int neighborId)
        {
            DeviceId = deviceId;
            NeighborId = neighborId;
        }
    }
}
