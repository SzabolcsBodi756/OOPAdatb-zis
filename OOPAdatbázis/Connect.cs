using MySql.Data.MySqlClient;
using System;

namespace OOPAdatbázis
{
    internal class Connect
    {
        public MySqlConnection Connection;

        private string _host;
        private string _database;
        private string _user;
        private string _password;
        private string _connectionString;

        public Connect(string database)
        {
            _host = "localhost";
            _database = database;
            _user = "root";
            _password = "";

            _connectionString = $"SERVER={_host};DATABASE={_database};UID={_user};PASSWORD={_password};SslMode=None";

            Connection = new MySqlConnection(_connectionString);

            try
            {
                Connection.Open();
                Console.WriteLine("Sikeres cstlakozás.");
                Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }





    }
}
