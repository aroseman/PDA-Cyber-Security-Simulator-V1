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

    public Device()
    {
        Name = "";
        IpAddress = "";
        MacAddress = "";
        Description = "";
        Status = false;
        Neighbors = new List<Device>();
        Notes = "";
    }

    public static void addDevice(Device newDevice)
    {
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
        dbConnection.Open();

        SQLiteCommand insertDevice = dbConnection.CreateCommand();
        insertDevice.CommandText = "INSERT INTO device (id, ip, name, netid) VALUES ('1', '192.168.1.5' , 'Cisco Router', '1');";
        insertDevice.ExecuteNonQuery();

        insertDevice.CommandText = "INSERT INTO device (id, ip, name, netid) VALUES ('2', '192.168.2.5' , 'Cisco Router', '1');";
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
        createDeviceTable.CommandText = "CREATE TABLE device (id integer primary key, ip varchar(15), name varchar(50), netid integer, foreign key(netid) references network(id));";
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