using System;
using System.Collections.Generic;
using System.Data.SQLite;

public class Device
{
    public string Name { get; set; }

    public string IpAddress { get; set; }
   
    public string MacAddress { get; set; }

    public string Description { get; set; }

    //1 is connected, 0 is disconnected
    public bool Status { get; set; }

    //Contains Neighboring IP Addresses
    public List<Device> Neighbors { get; set; }

    public string Notes { get; set; }

    public int ID { get; set; }

    public bool Configured { get; set; }

    public int NetID { get; set; }

    public Device()
    {
        Name = string.Empty;
        IpAddress = string.Empty;
        MacAddress = string.Empty;
        Description = string.Empty;
        Status = false;
        Neighbors = new List<Device>();
        Notes = string.Empty;
        ID = default(int);
        Configured = false;
        NetID = default(int);
    }
    public Device(string name, string ip, string mac, string description, string notes)
    {
        Name = name;
        IpAddress = ip;
        MacAddress = mac;
        Description = description;
        Notes = notes;
        Neighbors = new List<Device>();
        Configured = false;
    }

    public static void addDevice(Device newDevice)
    {
        using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;"))
        {
            dbConnection.Open();

            using (SQLiteCommand insertDevice = dbConnection.CreateCommand())
            {
                insertDevice.CommandText = "INSERT INTO Device (ip, name, mac, description, notes, netid) VALUES (@parameter1, @parameter2, @parameter3, @parameter4, @parameter5, @parameter6);";
                insertDevice.Parameters.Add(new SQLiteParameter("@parameter1", newDevice.IpAddress));
                insertDevice.Parameters.Add(new SQLiteParameter("@parameter2", newDevice.Name));
                insertDevice.Parameters.Add(new SQLiteParameter("@parameter3", newDevice.MacAddress));
                insertDevice.Parameters.Add(new SQLiteParameter("@parameter4", newDevice.Description));
                insertDevice.Parameters.Add(new SQLiteParameter("@parameter5", newDevice.Notes));
                insertDevice.Parameters.Add(new SQLiteParameter("@parameter6", newDevice.NetID));
                insertDevice.ExecuteNonQuery();
            }
        }
    }

    public static void removeDevice(Device newDevice)
    {
        using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;"))
        {
            dbConnection.Open();

            using (SQLiteCommand insertDevice = dbConnection.CreateCommand())
            {
                insertDevice.CommandText = "DELETE FROM Device WHERE id=@parameter1;";
                insertDevice.Parameters.Add(new SQLiteParameter("@parameter1", newDevice.ID));
                insertDevice.ExecuteNonQuery();
            }
        }
    }

    public static List<String> getDeviceNames()
    {
        using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;"))
        {
            dbConnection.Open();

            using (SQLiteCommand getDevice = dbConnection.CreateCommand())
            {
                getDevice.CommandText = "SELECT * FROM Device";
                using (SQLiteDataReader deviceReader = getDevice.ExecuteReader())
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
        }
    }

    public static List<Device> getDevices()
    {
        using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;"))
        {
            dbConnection.Open();

            using (SQLiteCommand getDevice = dbConnection.CreateCommand())
            {
                getDevice.CommandText = "SELECT * FROM Device";
                using (SQLiteDataReader deviceReader = getDevice.ExecuteReader())
                {

                    List<Device> deviceList = new List<Device> ();

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
        }
    }

    public static void makeDeviceTable()
    {
        using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;"))
        {
            dbConnection.Open();

            using (SQLiteCommand createDeviceTable = dbConnection.CreateCommand())
            {
                createDeviceTable.CommandText = "CREATE TABLE IF NOT EXISTS Device (id integer primary key autoincrement, ip varchar(15), name varchar(50),mac char(17),description varchar(50),notes varchar(200), netid integer, foreign key(netid) references network(id));";
                createDeviceTable.ExecuteNonQuery();
            }
        }
    }

    public static void dropDeviceTable()
    {
        using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;"))
        {
            dbConnection.Open();

            using (SQLiteCommand createDeviceTable = dbConnection.CreateCommand())
            {
                createDeviceTable.CommandText = "DROP TABLE IF EXISTS Device;";
                createDeviceTable.ExecuteNonQuery();
            }
        }
    }

    public static int getMaxTableID()
    {
        using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;"))
        {
            dbConnection.Open();

            using (SQLiteCommand getDevice = dbConnection.CreateCommand())
            {
                getDevice.CommandText = "SELECT MAX(id) FROM device";
                using (SQLiteDataReader deviceReader = getDevice.ExecuteReader())
                {
                    deviceReader.Read();

                    int maxID = deviceReader.GetInt32(0);
                    return maxID;
                }
            }
        }
    }

    public static List<Device> getDevicesByNetworkID(int networkID)
    {
        using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;"))
        {
            dbConnection.Open();

            using (SQLiteCommand getDevices = dbConnection.CreateCommand())
            {
                getDevices.CommandText = "SELECT * FROM Device WHERE netid = @parameter1";
                getDevices.Parameters.Add(new SQLiteParameter("@parameter1", networkID));
                using (SQLiteDataReader networkReader = getDevices.ExecuteReader())
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
        }
    }
}