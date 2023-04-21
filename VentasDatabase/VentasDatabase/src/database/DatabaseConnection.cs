using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasDatabase.src.utils;

namespace VentasDatabase.src.database
{
    internal class DatabaseConnection
    {
        public MySqlConnection connection { get; set; }

        public DatabaseConnection()
        {
            this.connection = new MySqlConnection();
        }

        public MySqlConnection connect()
        {
            DatabaseConfigReader reader = new DatabaseConfigReader();
            connection.ConnectionString = reader.ConnectionString;
            connection.Open();
            return connection;
        }

        public void disconnect()
        {
            connection.Close();
        }
    }
}
