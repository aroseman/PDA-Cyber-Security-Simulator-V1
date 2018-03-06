using System.Data.SQLite;
using System.Collections.Generic;

namespace PDA_Cyber_Security_Simulator_V1
{
    public struct Neighbor
    {
        public int d1;
        public int d2;
    }

    public class Neighbors
    {
        public static void makeNeighborsTable()
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;"))
            {
                dbConnection.Open();

                using (SQLiteCommand createDeviceTable = dbConnection.CreateCommand())
                {
                    createDeviceTable.CommandText = "CREATE TABLE IF NOT EXISTS Neighbors (d_one integer NOT NULL, d_two integer NOT NULL, PRIMARY KEY (d_one, d_two), FOREIGN KEY (d_one) REFERENCES device(id), FOREIGN KEY (d_two) REFERENCES device(id));";
                    createDeviceTable.ExecuteNonQuery();
                }
            }
        }

        public static void dropNeighborsTable()
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;"))
            { 
                dbConnection.Open();

                using (SQLiteCommand createDeviceTable = dbConnection.CreateCommand())
                {
                    createDeviceTable.CommandText = "DROP TABLE IF EXISTS Neighbors;";
                    createDeviceTable.ExecuteNonQuery();
                }
            }
        }

        public static void addNeighbors(int d_one, int d_two)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;"))
            {
                dbConnection.Open();

                using (SQLiteCommand insertDevice = dbConnection.CreateCommand())
                {
                    insertDevice.CommandText = "INSERT INTO Neighbors (d_one, d_two) VALUES (@parameter1, @parameter2);";
                    insertDevice.Parameters.Add(new SQLiteParameter("@parameter1", d_one.ToString()));
                    insertDevice.Parameters.Add(new SQLiteParameter("@parameter2", d_two.ToString()));
                    insertDevice.ExecuteNonQuery();
                }
            }
        }

        public static void removeNeighbor(int d_one, int d_two)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;"))
            {
                dbConnection.Open();

                using (SQLiteCommand insertDevice = dbConnection.CreateCommand())
                {
                    insertDevice.CommandText = "DELETE FROM Neighbors WHERE d_one= @parameter1 AND d_two= @parameter2;";
                    insertDevice.Parameters.Add(new SQLiteParameter("@parameter1", d_one.ToString()));
                    insertDevice.Parameters.Add(new SQLiteParameter("@parameter2", d_two.ToString()));
                    insertDevice.ExecuteNonQuery();
                }
            }
        }

        public static List<Neighbor> getNeighbors()
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;"))
            {
                dbConnection.Open();

                using (SQLiteCommand getNetworks = dbConnection.CreateCommand())
                {
                    getNetworks.CommandText = "SELECT * FROM Neighbors";
                    SQLiteDataReader neighborReader = getNetworks.ExecuteReader();

                    List<Neighbor> neighborList = new List<Neighbor>();

                    int counter = 0;

                    while (neighborReader.Read())
                    {
                        int d1 = neighborReader.GetInt32(0);
                        int d2 = neighborReader.GetInt32(1);
                        Neighbor n;
                        n.d1 = d1;
                        n.d2 = d2;
                        neighborList.Add(n);
                        counter++;
                    }

                    return neighborList;
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
                    getDevice.CommandText = "SELECT COUNT(*) FROM Neighbors";
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
