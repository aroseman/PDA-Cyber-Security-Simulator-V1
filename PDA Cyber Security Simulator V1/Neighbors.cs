using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1
{
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
            insertDevice.CommandText = "DELETE FROM device WHERE d_one='" + d_one +"AND d_two=" + d_two +"';";
            insertDevice.ExecuteNonQuery();
        }
    }
}
