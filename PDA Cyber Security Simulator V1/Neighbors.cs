using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1
{
    public struct neighbor
    {
        public int d1;
        public int d2;
    }

    public class Neighbors
    {
        public static void makeNeighborsTable()
        {
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
            dbConnection.Open();

            SQLiteCommand createDeviceTable = dbConnection.CreateCommand();
            createDeviceTable.CommandText = "CREATE TABLE IF NOT EXISTS neighbors (d_one integer NOT NULL, d_two integer NOT NULL, PRIMARY KEY (d_one, d_two), FOREIGN KEY (d_one) REFERENCES device(id), FOREIGN KEY (d_two) REFERENCES device(id));";
            createDeviceTable.ExecuteNonQuery();
        }

        public static void dropNeighborsTable()
        {
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
            dbConnection.Open();

            SQLiteCommand createDeviceTable = dbConnection.CreateCommand();
            createDeviceTable.CommandText = "DROP TABLE IF EXISTS neighbors;";
            createDeviceTable.ExecuteNonQuery();
        }

        public static void addNeighbors(int d_one, int d_two)
        {
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
            dbConnection.Open();

            SQLiteCommand insertDevice = dbConnection.CreateCommand();
            insertDevice.CommandText = "INSERT INTO neighbors (d_one, d_two) VALUES ('" + d_one + "','" + d_two + "');";
            insertDevice.ExecuteNonQuery();
        }

        public static void removeNeighbor(int d_one, int d_two)
        {
            SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
            dbConnection.Open();

            SQLiteCommand insertDevice = dbConnection.CreateCommand();
            insertDevice.CommandText = "DELETE FROM neighbors WHERE d_one='" + d_one +"AND d_two=" + d_two +"';";
            insertDevice.ExecuteNonQuery();
        }

        public static neighbor[] getNeighbors()
        {
            SQLiteConnection dbConnection = new SQLiteConnection("DataSource = db.sqlite; Version = 3; ");
            dbConnection.Open();

            SQLiteCommand getNetworks = dbConnection.CreateCommand();
            getNetworks.CommandText = "SELECT * FROM neighbors";
            SQLiteDataReader neighborReader = getNetworks.ExecuteReader();

            neighbor[] neighborList;

            neighborList = new neighbor[100];
            int counter = 0;

            while (neighborReader.Read())
            {
                int d1 = neighborReader.GetInt32(0);
                int d2 = neighborReader.GetInt32(1);
                neighborList[counter].d1 = d1;
                neighborList[counter].d2 = d2;
                counter++;
            }

            return neighborList;
        }

    }
}
