using MySql.Data.MySqlClient;
using OOPAdatbázis;
using OOPAdatbázis.Services;
using System.Collections.Generic;

namespace OOPAdatbázis.Services
{
    internal class Library : ISqlStatement
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
            throw new NotImplementedException();
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
