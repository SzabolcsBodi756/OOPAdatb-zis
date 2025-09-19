using MySql.Data.MySqlClient;
using OOPAdatbázis;
using OOPAdatbázis.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OOPAdatbázis.Services
{
    internal class Library : ISqlStatement
    {
        public object AddNewItem(object newRecord)
        {
            Connect conn = new Connect("libary");

            conn.Connection.Open();

            string sql = "INSERT INTO books('Title', 'Author', 'RelesDate') VALUES (@title, @author, @releasedate)";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            var book = newRecord.GetType().GetProperties();

            cmd.Parameters.AddWithValue("@title", book[0].Name);
            cmd.Parameters.AddWithValue("@author", book[1].Name);
            cmd.Parameters.AddWithValue("@releasedate", book[2].Name);

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
            throw new NotImplementedException();
        }

        public object GetById(int id)
        {
            Connect conn = new Connect("libary");

            conn.Connection.Open();

            string sql = "SELECT * FROM books WHERE id = @id ";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            var record = new
            {
                id = dr.GetInt32("Id"),
                title = dr.GetString("Title"),
                author = dr.GetString("Author"),
                releaseDate = dr.GetDateTime("RelesDate")
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

            List<object> books = new List<object>();

            conn.Connection.Open();

            string sql = "SELECT * FROM `books` ";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            while (dr.Read())
            {
                var book = new
                {
                    id = dr.GetInt32("Id"),
                    title = dr.GetString("Title"),
                    author = dr.GetString("Author"),
                    releaseDate = dr.GetDateTime("RelesDate")
                };

                books.Add(book);
            }

            conn.Connection.Close();

            return books;
        }
    }
}
