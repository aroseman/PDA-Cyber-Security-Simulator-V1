using PDA_Cyber_Security_Simulator_Domain;
using PDA_Cyber_Security_Simulator_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_DAL.Services
{
    public class NetworkManagerService : INetworkManager
    {
        public SQLiteConnection DbConnection;
        public SQLiteCommand DbCommand;

        public NetworkManagerService(string dbConnection)
        {
            DbConnection = new SQLiteConnection(dbConnection);
            DbConnection.Open();
            DbCommand = DbConnection.CreateCommand();
        }

        public void AddNetwork(Network newNetwork)
        {
            DbCommand.CommandText = "INSERT INTO Network (name) VALUES (@parameter1);";
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter1", newNetwork.Name));
            DbCommand.ExecuteNonQuery();
        }

        public void DeleteNetwork(int networkID)
        {
            DbCommand.CommandText = "DELETE FROM Network WHERE id=@parameter1;";
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter1", networkID));
            DbCommand.ExecuteNonQuery();
        }

        public Network GetNetwork()
        {
            throw new NotImplementedException();
        }

        public void UpdateNetwork(int id, Network updatedItem)
        {
            throw new NotImplementedException();
        }

        public void CreateTable()
        {
            DbCommand.CommandText = "CREATE TABLE IF NOT EXISTS Network (id integer primary key autoincrement, name varchar(50));";
            DbCommand.ExecuteNonQuery();
        }

        public void DropTable()
        {
            DbCommand.CommandText = "DROP TABLE IF EXISTS Network;";
            DbCommand.ExecuteNonQuery();
        }

        public List<Device> GetDeviceByNetworkId(int networkId)
        {
            DbCommand.CommandText = "SELECT * FROM Device WHERE netid = @parameter1";
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter1", networkId));
            using (SQLiteDataReader networkReader = DbCommand.ExecuteReader())
            {

                List<Device> deviceList = new List<Device>();

                while (networkReader.Read())
                {
                    var device = new Device();
                    device.Id = networkReader.GetInt32(0);
                    device.IpAddress = networkReader.GetString(1);
                    device.Name = networkReader.GetString(2);
                    device.MacAddress = networkReader.GetString(3);
                    device.Description = networkReader.GetString(4);
                    device.Notes = networkReader.GetString(5);
                    device.NetworkId = networkReader.GetInt32(6);

                    deviceList.Add(device);
                }

                return deviceList;
            }
        }

        public int GetMaxTableId()
        {
            DbCommand.CommandText = "SELECT COUNT(*) FROM Network";
            using (SQLiteDataReader deviceReader = DbCommand.ExecuteReader())
            {
                deviceReader.Read();

                int maxID = deviceReader.GetInt32(0);
                return maxID;
            }
        }

        public int GetNetworkIdByName(string networkName)
        {
            DbCommand.CommandText = "SELECT * FROM Network WHERE name = @parameter1;";
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter1", networkName));

            using (SQLiteDataReader networkReader = DbCommand.ExecuteReader())
            {
                int id = 0;

                while (networkReader.Read())
                {
                    id = networkReader.GetInt32(0);
                }

                return id;
            }
        }
    }
}
