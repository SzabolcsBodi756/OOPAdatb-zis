using OOPAdatbázis.Services;
using Org.BouncyCastle.Crypto.Prng;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOPAdatbázis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Kérem az datbázis nevét: ");

            string dbName = Console.ReadLine();

            ISqlStatement database = new Library();

            /*foreach (var item in database.GetAllData(dbName))
            {
                var books = item.GetType().GetProperties();

                Console.WriteLine($"Id: {books[0].GetValue(item)}, Title: {books[1].GetValue(item)}, Author: {books[2].GetValue(item)}, ReleaseDate: {books[3].GetValue(item)}");
            }*/


            //books
            //Console.WriteLine(database.GetById(5));

            /*var book = new
            {
                title = "Star Wars",
                Author = "Lucas",
                releaseDate = "1980-01-01"
            };

            database.AddNewItem(book);*/

            //Console.WriteLine(database.DeleteItem(0));

            /*var book = new
            {
                id = 7,
                title = "Star Wars",
                Author = "Lucas",
                releaseDate = "1980-01-01"
            };

            database.UpdateItem(book);*/


            //cars
            //Console.WriteLine(database.GetById(5));

            /*var car = new
            {
                brand = "Star Wars",
                type = "Lucas",
                mDate = "1980-01-01"
            };

            database.AddNewItem(cae);*/

            //Console.WriteLine(database.DeleteItem(0));

            /*var car = new
            {
                id = 7,
                brand = "Star Wars",
                type = "Lucas",
                mDate = "1980-01-01"
            };

            database.UpdateItem(book);*/
        }
    }
}
