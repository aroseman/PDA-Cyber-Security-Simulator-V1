using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1
{
    public class Network
    {

        public Network(string name)
        {
                Name = name;
        }

        public Network(string name, List<Device> devices)
        {
            Name = name;
            Devices = devices;
        }

        public Network()
        {
            Devices = new List<Device>();
        }

        public List<Device> Devices { get; set; }
        public string Name { get; set; }    

        /// <summary>
        /// This will add a device to a network
        /// </summary>
        /// <param name="dev"></param>
        public void AddDevice(Device dev)
        {
            Devices.Add(dev);
        }

        /// <summary>
        ///  Adds a virtual link between two devices.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void AddLink(Device a, Device b)
        {
            a.Neighbors.Add(b);
            b.Neighbors.Add(a);
        }

        /// <summary>
        /// Removes a device from the network.
        /// </summary>
        /// <param name="dev"></param>
        public void RemoveDevice(Device dev)
        {
            Devices.Remove(dev);
        }

        /// <summary>
        ///  Removes a link from two Devices.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void RemoveLink(Device a, Device b)
        {
            a.Neighbors.Remove(b);
            b.Neighbors.Remove(a);
        }

        public static void makeNetworkTable()
        {
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
            dbConnection.Open();

            SQLiteCommand createDeviceTable = dbConnection.CreateCommand();
            createDeviceTable.CommandText = "CREATE TABLE IF NOT EXISTS network (id integer primary key autoincrement, name varchar(50));";
            createDeviceTable.ExecuteNonQuery();

            /*SQLiteCommand insertDevice = dbConnection.CreateCommand();
            insertDevice.CommandText = "INSERT INTO network (name) VALUES ('test');";
            insertDevice.ExecuteNonQuery();*/
        }

        public static void dropNetworkTable()
        {
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
            dbConnection.Open();

            SQLiteCommand createDeviceTable = dbConnection.CreateCommand();
            createDeviceTable.CommandText = "DROP TABLE IF EXISTS network;";
            createDeviceTable.ExecuteNonQuery();
        }

        public static void addNetwork(Network newNetwork)
        {
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
            dbConnection.Open();

            SQLiteCommand insertDevice = dbConnection.CreateCommand();
            insertDevice.CommandText = "INSERT INTO network (name) VALUES ('" + newNetwork.Name + "');";
            insertDevice.ExecuteNonQuery();
        }

        public static String[] getNetworks()
        {
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
            dbConnection.Open();

            SQLiteCommand getNetworks = dbConnection.CreateCommand();
            getNetworks.CommandText = "SELECT * FROM network";
            SQLiteDataReader networkReader = getNetworks.ExecuteReader();

            String[] networkList;

            networkList = new String[100];
            int counter = 0;

            while (networkReader.Read())
            {
                int id = networkReader.GetInt32(0);
                String name = networkReader.GetString(1);

                networkList[counter] = id.ToString() + " " + name;
                counter++;
            }

            return networkList;
        }

        public static String[] getDevices(int networkID)
        {
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
            dbConnection.Open();

            SQLiteCommand getDevices = dbConnection.CreateCommand();
            getDevices.CommandText = "SELECT * FROM device INNER JOIN network ON device.netid = network.id";
            SQLiteDataReader networkReader = getDevices.ExecuteReader();

            String[] deviceList;

            deviceList = new String[100];
            int counter = 0;

            while (networkReader.Read())
            {
                int id = networkReader.GetInt32(0);
                String ip = networkReader.GetString(1);
                String name = networkReader.GetString(2);
                String mac = networkReader.GetString(3);
                String desc = networkReader.GetString(4);
                String notes = networkReader.GetString(5);
                int netid = networkReader.GetInt32(6);
                deviceList[counter] = id.ToString() + " " + name;

                counter++;
            }

            return deviceList;
        }
    }
}
