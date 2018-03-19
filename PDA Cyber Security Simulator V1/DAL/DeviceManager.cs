using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1.DAL
{
    public class DeviceManager : IManager<Device>
    {
        public SQLiteConnection dbConnection;
        public SQLiteCommand dbCommand;

        public DeviceManager()
        {
            dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
            dbCommand = dbConnection.CreateCommand();
        }

        public void AddItem(Device newDevice)
        {
            dbCommand.CommandText = "INSERT INTO Device (ip, name, mac, description, notes, netid) VALUES (@parameter1, @parameter2, @parameter3, @parameter4, @parameter5, @parameter6);";
            dbCommand.Parameters.Add(new SQLiteParameter("@parameter1", newDevice.IpAddress));
            dbCommand.Parameters.Add(new SQLiteParameter("@parameter2", newDevice.Name));
            dbCommand.Parameters.Add(new SQLiteParameter("@parameter3", newDevice.MacAddress));
            dbCommand.Parameters.Add(new SQLiteParameter("@parameter4", newDevice.Description));
            dbCommand.Parameters.Add(new SQLiteParameter("@parameter5", newDevice.Notes));
            dbCommand.Parameters.Add(new SQLiteParameter("@parameter6", newDevice.NetID));
            dbCommand.ExecuteNonQuery();
        }

        public void DeleteItem(Device deviceToDelete)
        {
            dbCommand.CommandText = "DELETE FROM Device WHERE id=@parameter1;";
            dbCommand.Parameters.Add(new SQLiteParameter("@parameter1", deviceToDelete.ID));
            dbCommand.ExecuteNonQuery();
        }

        public Device GetItem()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(int id, Device updatedItem)
        {
            throw new NotImplementedException();
        }

        public List<String> GetDeviceNames()
        {
            dbCommand.CommandText = "SELECT * FROM Device";
            using (SQLiteDataReader deviceReader = dbCommand.ExecuteReader())
            {
                List<String> deviceList = new List<string>();

                int counter = 0;

                while (deviceReader.Read())
                {
                    String name = deviceReader.GetString(2);
                    deviceList.Add(name);
                    counter++;
                }

                return deviceList;
            }
        }

        public List<Device> GetDevices()
        {
            dbCommand.CommandText = "SELECT * FROM Device";
            using (SQLiteDataReader deviceReader = dbCommand.ExecuteReader())
            {

                List<Device> deviceList = new List<Device>();

                int counter = 0;

                while (deviceReader.Read())
                {
                    Device newD = new Device();

                    int id = deviceReader.GetInt32(0);
                    String ip = deviceReader.GetString(1);
                    String name = deviceReader.GetString(2);
                    String mac = deviceReader.GetString(3);
                    String desc = deviceReader.GetString(4);
                    String notes = deviceReader.GetString(5);
                    int netid = deviceReader.GetInt32(6);

                    newD.ID = id;
                    newD.IpAddress = ip;
                    newD.Name = name;
                    newD.MacAddress = mac;
                    newD.Description = desc;
                    newD.Notes = notes;

                    deviceList.Add(newD);
                    counter++;
                }

                return deviceList;
            }
        }

        public void CreateDeviceTable()
        {
            dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS Device (id integer primary key autoincrement, ip varchar(15), name varchar(50),mac char(17),description varchar(50),notes varchar(200), netid integer, foreign key(netid) references network(id));";
            dbCommand.ExecuteNonQuery();
        }

        public void DropDeviceTable()
        {
            dbCommand.CommandText = "DROP TABLE IF EXISTS Device;";
            dbCommand.ExecuteNonQuery();
        }

        public int GetMaxTableId()
        {
            dbCommand.CommandText = "SELECT MAX(id) FROM device";
            using (SQLiteDataReader deviceReader = dbCommand.ExecuteReader())
            {
                deviceReader.Read();

                int maxID = deviceReader.GetInt32(0);
                return maxID;
            }
        }
    }
}
