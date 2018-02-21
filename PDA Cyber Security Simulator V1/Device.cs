﻿using System;
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

    public int ID { get; set; }

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
    }

    public static void removeDevice(Device newDevice)
    {
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
        dbConnection.Open();

        SQLiteCommand insertDevice = dbConnection.CreateCommand();
        insertDevice.CommandText = "DELETE FROM device WHERE id='1';";
        insertDevice.ExecuteNonQuery();
    }

    public static String[] getDeviceNames()
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
            String name = deviceReader.GetString(2);
            deviceList[counter] = name;
            counter++;
        }

        return deviceList;
    }

    public static Device[] getDevices()
    {
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
        dbConnection.Open();

        SQLiteCommand getDevice = dbConnection.CreateCommand();
        getDevice.CommandText = "SELECT * FROM device";
        SQLiteDataReader deviceReader = getDevice.ExecuteReader();

        Device[] deviceList;

        deviceList = new Device[50];
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

            deviceList[counter] = newD;
            counter++;
        }

        return deviceList;
    }

    public static void makeDeviceTable()
    {
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
        dbConnection.Open();

        SQLiteCommand createDeviceTable = dbConnection.CreateCommand();
        createDeviceTable.CommandText = "CREATE TABLE IF NOT EXISTS device (id integer primary key autoincrement, ip varchar(15), name varchar(50),mac char(17),description varchar(50),notes varchar(200), netid integer, foreign key(netid) references network(id));";
        createDeviceTable.ExecuteNonQuery();

    }

    public static void dropDeviceTable()
    {
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
        dbConnection.Open();

        SQLiteCommand createDeviceTable = dbConnection.CreateCommand();
        createDeviceTable.CommandText = "DROP TABLE IF EXISTS device;";
        createDeviceTable.ExecuteNonQuery();
    }

    public int getMaxTableID()
    {
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
        dbConnection.Open();

        SQLiteCommand getDevice = dbConnection.CreateCommand();
        getDevice.CommandText = "SELECT MAX(id) FROM device";
        SQLiteDataReader deviceReader = getDevice.ExecuteReader();
        deviceReader.Read();

        int maxID = deviceReader.GetInt32(0);
        return maxID;
    }
}