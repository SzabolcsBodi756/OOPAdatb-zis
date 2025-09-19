using MySql.Data.MySqlClient;
using OOPAdatbázis;
using OOPAdatbázis.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OOPAdatbázis.Services
{
    internal class cars : ISqlStatement
    {
        public object AddNewItem(object newRecord)
        {
            throw new NotImplementedException();
        }

        public object DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public object GetById(int id)
        {
            Connect conn = new Connect("libary");

            conn.Connection.Open();

            string sql = "SELECT * FROM cars WHERE id = @id ";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            var record = new
            {
                id = dr.GetInt32("id"),
                brand = dr.GetString("brand"),
                type = dr.GetString("type"),
                mDate = dr.GetDateTime("mDate")
            };

            conn.Connection.Close();

            return record;
        }

        public object UpdateItem(object modifiedItem)
        {
            throw new NotImplementedException();
        }

        public List<object> GetAllData(string dbName)
        {
            Connect conn = new Connect(dbName);

            List<object> kocsi = new List<object>();

            conn.Connection.Open();

            string sql = "SELECT * FROM `cars` ";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            while (dr.Read())
            {
                var books = new
                {
                    id = dr.GetInt32("id"),
                    brand = dr.GetString("brand"),
                    type = dr.GetString("type"),
                    mDate = dr.GetDateTime("mDate")
                };

                kocsi.Add(books);
            }

            conn.Connection.Close();

            return kocsi;
        }
    }
}
