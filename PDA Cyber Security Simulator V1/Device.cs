using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using PDA_Cyber_Security_Simulator_V1;

public class Device
{
    public String Name { get; set; }

    public String IpAddress { get; set; }
   
    public String MacAddress { get; set; }

    public String Description { get; set; }

    //1 is connected, 0 is disconnected
    public bool Status { get; set; }

    //Contains Neighboring IP Addresses
    public List<Device> Neighbors { get; set; }

    public String Notes { get; set; }

    public bool Configured { get; set; }

    public Device()
    {
        
        Status = false;
        Neighbors = new List<Device>();
        Configured = false;
        
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
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
        dbConnection.Open();

        SQLiteCommand insertDevice = dbConnection.CreateCommand();
        insertDevice.CommandText = "INSERT INTO device (ip, name, mac, description, notes, netid) VALUES ('" + newDevice.IpAddress + "', '" + newDevice.Name + "', '" + newDevice.MacAddress + "', '" + newDevice.Description + "', '" + newDevice.Notes + "', '1');";
        insertDevice.ExecuteNonQuery();

        insertDevice.CommandText = "INSERT INTO device (ip, name, mac, description, notes, netid) VALUES ('192.168.2.5' , 'Cisco Router', '00:0a:95:9d:68:16', 'This a description', 'This is a note', '1');";
        insertDevice.ExecuteNonQuery();
    }

    public static void removeDevice(Device newDevice)
    {
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
        dbConnection.Open();

        SQLiteCommand insertDevice = dbConnection.CreateCommand();
        insertDevice.CommandText = "DELETE FROM device WHERE id='1';";
        insertDevice.ExecuteNonQuery();
    }

    public static String[] getDevices()
    {
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
        dbConnection.Open();
        
        SQLiteCommand getDevice = dbConnection.CreateCommand();
        getDevice.CommandText = "SELECT * FROM device";
        SQLiteDataReader deviceReader = getDevice.ExecuteReader();

        String[] deviceList;

        deviceList = new String[100];
        int counter = 0;

        while (deviceReader.Read())
        {
            int id = deviceReader.GetInt32(0);
            String ip = deviceReader.GetString(1);
            String name = deviceReader.GetString(2);
            int netid = deviceReader.GetInt32(3);

            deviceList[counter] = id.ToString() + " " + ip + " " + name + " " + netid.ToString();
            counter++;
        }

        return deviceList;
    }

    public static void makeDeviceTable()
    {
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
        dbConnection.Open();

        SQLiteCommand createDeviceTable = dbConnection.CreateCommand();
        createDeviceTable.CommandText = "CREATE TABLE device (id integer primary key autoincrement, ip varchar(15), name varchar(50),mac char(17),description varchar(50),notes varchar(200), netid integer, foreign key(netid) references network(id));";
        createDeviceTable.ExecuteNonQuery();
    }

    public static void dropDeviceTable()
    {
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
        dbConnection.Open();

        SQLiteCommand createDeviceTable = dbConnection.CreateCommand();
        createDeviceTable.CommandText = "DROP TABLE device;";
        createDeviceTable.ExecuteNonQuery();
    }
}