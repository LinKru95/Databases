using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kokia knyga jums surasti?");
            var bookName = Console.ReadLine();

            GetBooksBySP(bookName);

            void GetBooksBySP(string bookName)
            {
                //string sql = "EXECUTE getBooks @book_name";
                var procedure = "getBooks";
                string connectionString = $"Server=(localdb)\\mssqllocaldb;Database=BooksWithPagesDb;Trusted_Connection=True;";

                using var connection = new SqlConnection(connectionString);
                connection.Open();

                var sqlParams = new { bookName = bookName };
                var result = connection.Query<Book>(procedure, sqlParams, commandType: CommandType.StoredProcedure);

                if (result.Any())
                {
                    foreach (var item in result)
                    {
                        Console.WriteLine(item.Name);
                    }
                }
                else
                {
                    Console.WriteLine("Nieko neradau :(");
                }
            }

            void GetBooks(string bookName)
            {
                string sql = $"SELECT * FROM Books WHERE Name LIKE '@book_name'";
                string connectionString = $"Server=(localdb)\\mssqllocaldb;Database=BooksWithPagesDb;Trusted_Connection=True;";

                using var connection = new SqlConnection(connectionString);
                connection.Open();

                var sqlParams = new { book_name = bookName };
                var result = connection.Query<Book>(sql, sqlParams);

                if (result.Any())
                {
                    foreach (var item in result)
                    {
                        Console.WriteLine(item.Name);
                    }
                }
                else
                {
                    Console.WriteLine("Nieko neradau :(");
                }
            }
        }        
    }
}
