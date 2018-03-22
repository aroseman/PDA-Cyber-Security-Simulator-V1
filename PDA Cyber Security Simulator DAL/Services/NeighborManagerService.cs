using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDA_Cyber_Security_Simulator_DAL.Interfaces;
using PDA_Cyber_Security_Simulator_Domain;

namespace PDA_Cyber_Security_Simulator_DAL.Services
{
    class NeighborManagerService : INeighborManager
    {
        public SQLiteConnection DbConnection;
        public SQLiteCommand DbCommand;

        public NeighborManagerService(string dbConnection)
        {
            DbConnection = new SQLiteConnection(dbConnection);
            DbConnection.Open();
            DbCommand = DbConnection.CreateCommand();
        }

        public void MakeNeighborsTable()
        {
            DbCommand.CommandText = "CREATE TABLE IF NOT EXISTS Neighbors (Id integer primary key autoincrement, DeviceId integer NOT NULL, NeighborId integer NOT NULL, FOREIGN KEY (DeviceId) REFERENCES device(id), FOREIGN KEY (NeighborId) REFERENCES device(id));";
            DbCommand.ExecuteNonQuery();
        }

        public void DropNeighborsTable()
        {
            DbCommand.CommandText = "DROP TABLE IF EXISTS Neighbors;";
            DbCommand.ExecuteNonQuery();
        }

        public void AddNeighbor(int deviceId, int neighborId)
        {
            DbCommand.CommandText = "INSERT INTO Neighbors (DeviceId, NeighborId) VALUES (@parameter1, @parameter2);";
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter1", deviceId.ToString()));
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter2", neighborId.ToString()));
            DbCommand.ExecuteNonQuery();
        }

        public void RemoveNeighbor(int deviceId, int neighborId)
        {
            DbCommand.CommandText = "DELETE FROM Neighbors WHERE DeviceId=@parameter1 AND NeighborId=@parameter2;";
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter1", deviceId.ToString()));
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter2", neighborId.ToString()));
            DbCommand.ExecuteNonQuery();
        }

        public List<Neighbors> GetNeighbors(int deviceId)
        {
            DbCommand.CommandText = "SELECT * FROM Neighbors WHERE DeviceId=@parameter1;";
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter1", deviceId.ToString()));
            using (SQLiteDataReader neighborReader = DbCommand.ExecuteReader())
            {
                List<Neighbors> neighborList = new List<Neighbors>();

                while (neighborReader.Read())
                {
                    int id = neighborReader.GetInt32(0);
                    int devId = neighborReader.GetInt32(1);
                    int neighId = neighborReader.GetInt32(2);
                    Neighbors n = new Neighbors(devId, neighId);
                    neighborList.Add(n);
                }

                return neighborList;
            }
        }

        public int GetMaxTableID()
        {
            DbCommand.CommandText = "SELECT COUNT(*) FROM Neighbors";
            using (SQLiteDataReader deviceReader = DbCommand.ExecuteReader())
            {
                deviceReader.Read();

                int maxID = deviceReader.GetInt32(0);
                return maxID;
            }
        }
    }
}
