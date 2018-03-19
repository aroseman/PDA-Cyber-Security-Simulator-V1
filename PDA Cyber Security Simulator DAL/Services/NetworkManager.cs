using PDA_Cyber_Security_Simulator_V1.Domain;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1.DAL
{
    public class NetworkManager : IManager<Network>
    {
        public SQLiteConnection dbConnection;
        public SQLiteCommand dbCommand;

        public NetworkManager()
        {
            dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
            dbCommand = dbConnection.CreateCommand();
        }

        public void AddItem(Network newItem)
        {
            dbCommand.CommandText = "INSERT INTO Network (name) VALUES (@parameter1);";
            dbCommand.Parameters.Add(new SQLiteParameter("@parameter1", newItem.Name));
            dbCommand.ExecuteNonQuery();
        }

        public void DeleteItem(int networkID)
        {
            dbCommand.CommandText = "DELETE FROM Network WHERE id=@parameter1;";
            dbCommand.Parameters.Add(new SQLiteParameter("@parameter1", networkID));
            dbCommand.ExecuteNonQuery();
        }

        public Network GetItem()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(int id, Network updatedItem)
        {
            throw new NotImplementedException();
        }

        public void CreateTable()
        {
            dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS Network (id integer primary key autoincrement, name varchar(50));";
            dbCommand.ExecuteNonQuery();
        }

        public void DropTable()
        {
            dbCommand.CommandText = "DROP TABLE IF EXISTS Network;";
            dbCommand.ExecuteNonQuery();
        }

        public List<Device> getDeviceByNetworkId(int networkId)
        {
            dbCommand.CommandText = "SELECT * FROM Device WHERE netid = @parameter1";
            dbCommand.Parameters.Add(new SQLiteParameter("@parameter1", networkId));
            using (SQLiteDataReader networkReader = dbCommand.ExecuteReader())
            {

                List<Device> deviceList = new List<Device>();

                while (networkReader.Read())
                {
                    var device = new Device();
                    device.ID = networkReader.GetInt32(0);
                    device.IpAddress = networkReader.GetString(1);
                    device.Name = networkReader.GetString(2);
                    device.MacAddress = networkReader.GetString(3);
                    device.Description = networkReader.GetString(4);
                    device.Notes = networkReader.GetString(5);
                    device.NetID = networkReader.GetInt32(6);

                    deviceList.Add(device);
                }

                return deviceList;
            }
        }

        public int GetMaxTableId()
        {
            dbCommand.CommandText = "SELECT COUNT(*) FROM Network";
            using (SQLiteDataReader deviceReader = dbCommand.ExecuteReader())
            {
                deviceReader.Read();

                int maxID = deviceReader.GetInt32(0);
                return maxID;
            }
        }

        public int GetNetworkIdByName(string networkName)
        {
            dbCommand.CommandText = "SELECT * FROM Network WHERE name = @parameter1;";
            dbCommand.Parameters.Add(new SQLiteParameter("@parameter1", networkName));

            using (SQLiteDataReader networkReader = dbCommand.ExecuteReader())
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
