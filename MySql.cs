using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Malshinon.DataBase
{
    public class MySqlData
    {
        static string connectionString = "Server=localhost;Database=eagleeyedb;User=root;Password='';Port=3307";
        public MySqlConnection connection;

        public void Connect()
        {
            var conn = new MySqlConnection(connectionString);
            connection = conn;
            try
            {
                conn.Open();
                Console.WriteLine("Connected to MySql database successfully.");
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error connection to MySql database: {ex.Message}");
            }
        }

        public MySqlConnection GetConnection()
        {
            try
            {
                var connection = new MySqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Connected to MySql database successfully.");
                return connection;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error {ex.Message}");
                return null;
            }   
        }

        public MySqlConnection DisConnection()
        {
            try
            {
                var connection = new MySqlConnection(connectionString);
                connection.Close();
                return connection;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error {ex.Message}");
                return null;
            }
        }
    }
}