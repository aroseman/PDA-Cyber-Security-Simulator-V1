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
        insertDevice.CommandText = "INSERT INTO device (ip, name) VALUES ('192.168.1.5' , 'Cisco Router');";
        insertDevice.ExecuteNonQuery();
    }

    public static String getDevices()
    {
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
        dbConnection.Open();
        
        SQLiteCommand getDevice = dbConnection.CreateCommand();
        getDevice.CommandText = "SELECT * FROM device";
        SQLiteDataReader deviceReader = getDevice.ExecuteReader();

        deviceReader.Read();
        deviceReader.Read();
        String ip = deviceReader.GetString(0);
        String name = deviceReader.GetString(1);

        return ip + name;
    }

    public static void makeDeviceTable()
    {
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
        dbConnection.Open();

        SQLiteCommand createDeviceTable = dbConnection.CreateCommand();
        createDeviceTable.CommandText = "CREATE TABLE device (ip varchar(15) primary key, name varchar(50));";
        createDeviceTable.ExecuteNonQuery();
    }
}