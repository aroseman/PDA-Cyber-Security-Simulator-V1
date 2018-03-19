using PDA_Cyber_Security_Simulator_V1.Domain;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

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
            Name = string.Empty;
            Id = default(int);
        }

        public List<Device> Devices { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        public static void makeNetworkTable()
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;"))
            {
                dbConnection.Open();

                using (SQLiteCommand createDeviceTable = dbConnection.CreateCommand())
                {
                    createDeviceTable.CommandText = "CREATE TABLE IF NOT EXISTS Network (id integer primary key autoincrement, name varchar(50));";
                    createDeviceTable.ExecuteNonQuery();
                }
            }
        }

        public static void dropNetworkTable()
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;"))
            {
                dbConnection.Open();

                using (SQLiteCommand createDeviceTable = dbConnection.CreateCommand())
                {
                    createDeviceTable.CommandText = "DROP TABLE IF EXISTS Network;";
                    createDeviceTable.ExecuteNonQuery();
                }
            }
        }

        public static void addNetwork(Network newNetwork)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;"))
            {
                dbConnection.Open();

                using (SQLiteCommand insertDevice = dbConnection.CreateCommand())
                {
                    insertDevice.CommandText = "INSERT INTO Network (name) VALUES (@parameter1);";
                    insertDevice.Parameters.Add(new SQLiteParameter("@parameter1", newNetwork.Name));
                    insertDevice.ExecuteNonQuery();
                }
            }
        }

        public static List<String> getNetworkNames()
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;"))
            {
                dbConnection.Open();

                using (SQLiteCommand getNetworks = dbConnection.CreateCommand())
                {
                    getNetworks.CommandText = "SELECT * FROM Network";
                    using (SQLiteDataReader networkReader = getNetworks.ExecuteReader())
                    {
                        List<String> networkList = new List<string>();

                        int counter = 0;

                        while (networkReader.Read())
                        {
                            int id = networkReader.GetInt32(0);
                            String name = networkReader.GetString(1);

                            networkList.Add(name);
                            counter++;
                        }

                        return networkList;
                    }
                }
            }
        }

        public static int getNetworkIdByName(string networkName)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;"))
            {
                dbConnection.Open();

                using (SQLiteCommand getNetworkIdByName = dbConnection.CreateCommand())
                {
                    getNetworkIdByName.CommandText = "SELECT * FROM Network WHERE name = @parameter1;";
                    getNetworkIdByName.Parameters.Add(new SQLiteParameter("@parameter1", networkName));

                    using (SQLiteDataReader networkReader = getNetworkIdByName.ExecuteReader())
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

        public static List<Device> getDevices(int NetworkID)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;"))
            {
                dbConnection.Open();

                using (SQLiteCommand getDevices = dbConnection.CreateCommand())
                {
                    getDevices.CommandText = "SELECT * FROM Device INNER JOIN Network ON Device.netid = Network.id";
                    using (SQLiteDataReader networkReader = getDevices.ExecuteReader())
                    {
                        List<Device> deviceList = new List<Device>();

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

                            Device d = new Device
                            {
                                ID = id,
                                IpAddress = ip,
                                Name = name,
                                MacAddress = mac,
                                Description = desc
                            };
                            d.Notes = d.Notes;
                            d.NetID = netid;

                            deviceList.Add(d);

                            counter++;
                        }

                        return deviceList;
                    }
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
                    getDevice.CommandText = "SELECT COUNT(*) FROM Network";
                    using (SQLiteDataReader deviceReader = getDevice.ExecuteReader())
                    {
                        deviceReader.Read();

                        int maxID = deviceReader.GetInt32(0);
                        return maxID;
                    }
                }
            }
        }
    }
}
