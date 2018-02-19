using System;
using MySql.Data.MySqlClient;
using WorldDataApp;

namespace WorldDataApp.Models
{
    public class DB
    {
        public static MySqlConnection Connection()
        {
            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
            return conn;
        }
    }
}
