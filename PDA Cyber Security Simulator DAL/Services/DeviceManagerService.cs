using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDA_Cyber_Security_Simulator_Domain;

namespace PDA_Cyber_Security_Simulator_DAL.Interfaces
{
    public class DeviceManagerService : IDeviceManager
    {
        public SQLiteConnection DbConnection;
        public SQLiteCommand DbCommand;

        public DeviceManagerService(string dbConnection)
        {
            DbConnection = new SQLiteConnection(dbConnection);
            DbConnection.Open();
            DbCommand = DbConnection.CreateCommand();
        }

        public void AddDevice(Device newDevice)
        {
            DbCommand.CommandText = "INSERT INTO Device (ip, name, mac, description, notes, netid) VALUES (@parameter1, @parameter2, @parameter3, @parameter4, @parameter5, @parameter6);";
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter1", newDevice.IpAddress));
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter2", newDevice.Name));
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter3", newDevice.MacAddress));
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter4", newDevice.Description));
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter5", newDevice.Notes));
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter6", newDevice.NetworkId));
            DbCommand.ExecuteNonQuery();
        }

        public void DeleteDevice(Device deviceToDelete)
        {
            DbCommand.CommandText = "DELETE FROM Device WHERE id=@parameter1;";
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter1", deviceToDelete.Id));
            DbCommand.ExecuteNonQuery();
        }

        public Device GetDevice()
        {
            throw new NotImplementedException();
        }

        public void UpdateDevice(int id, Device updatedItem)
        {
            throw new NotImplementedException();
        }

        public List<string> GetDeviceNames()
        {
            DbCommand.CommandText = "SELECT * FROM Device";
            using (SQLiteDataReader deviceReader = DbCommand.ExecuteReader())
            {
                List<string> deviceList = new List<string>();

                int counter = 0;

                while (deviceReader.Read())
                {
                    string name = deviceReader.GetString(2);
                    deviceList.Add(name);
                    counter++;
                }

                return deviceList;
            }
        }

        public List<Device> GetDevices()
        {
            DbCommand.CommandText = "SELECT * FROM Device";
            using (SQLiteDataReader deviceReader = DbCommand.ExecuteReader())
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

                    newD.Id = id;
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
            DbCommand.CommandText = "CREATE TABLE IF NOT EXISTS Device (id integer primary key autoincrement, ip varchar(15), name varchar(50),mac char(17),description varchar(50),notes varchar(200), netid integer, foreign key(netid) references network(id));";
            DbCommand.ExecuteNonQuery();
        }

        public void DropDeviceTable()
        {
            DbCommand.CommandText = "DROP TABLE IF EXISTS Device;";
            DbCommand.ExecuteNonQuery();
        }

        public int GetMaxTableId()
        {
            DbCommand.CommandText = "SELECT MAX(id) FROM device";
            using (SQLiteDataReader deviceReader = DbCommand.ExecuteReader())
            {
                deviceReader.Read();

                int maxID = deviceReader.GetInt32(0);
                return maxID;
            }
        }

        public List<Device> GetDevicesByNetworkId(int networkId)
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
                    device.Neighbors = new List<Device>();

                    deviceList.Add(device);
                }

                return deviceList;
            }
        }

        public int GetDeviceIdByNameAndNetworkId(string deviceName, int networkId)
        {
            DbCommand.CommandText = "SELECT id FROM Device WHERE netid = @parameter1 AND name = @parameter2;";
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter1", networkId));
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter2", deviceName));
            using (SQLiteDataReader reader = DbCommand.ExecuteReader())
            {
                reader.Read();

                int id = reader.GetInt32(0);

                return id;
            }
        }

        public Device GetDeviceById(int deviceId)
        {
            DbCommand.CommandText = "SELECT * FROM Device WHERE id = @parameter1;";
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter1", deviceId));
            using (SQLiteDataReader deviceReader = DbCommand.ExecuteReader())
            {
                deviceReader.Read();
                Device device = new Device
                {
                    Id = deviceReader.GetInt32(0),
                    IpAddress = deviceReader.GetString(1),
                    Name = deviceReader.GetString(2),
                    MacAddress = deviceReader.GetString(3),
                    Description = deviceReader.GetString(4),
                    Notes = deviceReader.GetString(5),
                    NetworkId = deviceReader.GetInt32(6),
                    Configured = true,
                    Neighbors = new List<Device>(),
                    Status = false
                };

                return device;
            }
        }

        public void UpdateDevice(Device device)
        {
            DbCommand.CommandText =
                "UPDATE Device SET ip = @parameter1, name = @parameter2, mac = @parameter3, description = @parameter4, notes = @parameter5 WHERE id = @parameter6;";
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter1", device.IpAddress));
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter2", device.Name));
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter3", device.MacAddress));
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter4", device.Description));
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter5", device.Notes));
            DbCommand.Parameters.Add(new SQLiteParameter("@parameter6", device.Id));
            DbCommand.ExecuteNonQuery();
        }
    }
}
