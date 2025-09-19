using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
            Connect conn = new Connect("libary");

            conn.Connection.Open();

            string sql = "INSERT INTO cars(brand, type, mDate) VALUES (@brand, @type, @mDate)";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            var car = newRecord.GetType().GetProperties();

            cmd.Parameters.AddWithValue("@brand", car[0].GetValue(newRecord));
            cmd.Parameters.AddWithValue("@type", car[1].GetValue(newRecord));
            cmd.Parameters.AddWithValue("@mDate", car[2].GetValue(newRecord));

            cmd.ExecuteNonQuery();

            conn.Connection.Close();

            var result = new
            {
                message = "Sikeres felvétel",
                result = newRecord
            };

            return result;
        }

        public object DeleteItem(int id)
        {
            Connect conn = new Connect("libary");

            conn.Connection.Open();

            string sql = "DELETE FROM `cars` WHERE id = @id";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conn.Connection.Close();

            var result = new
            {
                message = "Sikeres törlés.",

            };

            return result;
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
            Connect conn = new Connect("libary");

            conn.Connection.Open();

            string sql = "UPDATE cars SET brand = @brand, type = @type, mDate = @mDate  WHERE Id = @id";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            var car = modifiedItem.GetType().GetProperties();

            cmd.Parameters.AddWithValue("@id", car[0].GetValue(modifiedItem));
            cmd.Parameters.AddWithValue("@brand", car[1].GetValue(modifiedItem));
            cmd.Parameters.AddWithValue("@type", car[2].GetValue(modifiedItem));
            cmd.Parameters.AddWithValue("@mDate", car[3].GetValue(modifiedItem));

            cmd.ExecuteNonQuery();

            conn.Connection.Close();

            var result = new
            {
                message = "Sikeres felvétel",
                result = modifiedItem
            };

            return result;
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
