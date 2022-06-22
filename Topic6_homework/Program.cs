using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Topic6_homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb+srv://LinKru95:Kompiuteris.1@cluster0.8l9v5zd.mongodb.net/?retryWrites=true&w=majority");
            var bookCollection = client.GetDatabase("Book").GetCollection<Book>("Books");

            //var book = new Book("Knyga");
            //var pages = new List<Page>
            //{
            //    new Page
            //    {
            //        Content = "pirmas puslapis"
            //    }
            //};
            //book.Pages = pages;
            //bookCollection.InsertOne(book);

            Console.WriteLine("Welcome to library");
            bool repeat = true;
            string userInput;
            string bookName;

            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("MENIU\n[1]-Prideti irasa\n[2]-Istrinti irasa\n[3]-Atnaujinti irasa\n[4]-ieskoti\n[5]-Iseiti is programos");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Iveskite knygos pavadinima:");

                        bookName = Console.ReadLine();

                        Console.WriteLine("Iveskite puslapio turini:");

                        string content = Console.ReadLine();

                        var book = new Book(bookName);
                        var pages = new List<Page>
                            {
                                new Page
                                {
                                    Content = content
                                }
                            };

                        book.Pages = pages;

                        bookCollection.InsertOne(book);

                        break;
                    case "2":
                        Console.Clear();

                        Console.WriteLine("Iveskite knygos pavadinima:");

                        bookName = Console.ReadLine();

                        var deleteFilter = Builders<Book>.Filter.Eq("Name", bookName);

                        bookCollection.DeleteOne(deleteFilter);

                        break;
                    case "3":
                        Console.Clear();

                        Console.WriteLine("Iveskite esama knygos pavadinima:");

                        bookName = Console.ReadLine();

                        Console.WriteLine("Iveskite nauja turinio pavadinima:");

                        string newContext = Console.ReadLine();

                        var updateFilter = Builders<Book>.Filter.Eq("Name", bookName);
                        var update = Builders<Book>.Update.AddToSet<string>("Pages", newContext);

                        bookCollection.UpdateMany(updateFilter, update);

                        break;
                    case "4":
                        Console.Clear();

                        Console.WriteLine("Iveskite ieskomos knygos pavadinima:");

                        bookName = Console.ReadLine();

                        var searchFilter = Builders<Book>.Filter.Eq("Name", bookName);

                        var results = bookCollection.Find(searchFilter).ToList();

                        foreach (var bookItem in results)
                        {
                            foreach (var item in bookItem.Pages)
                            {
                                Console.WriteLine(item.Content);
                            }
                        }

                        Console.ReadLine();

                        break;
                    case "5":
                        Console.Clear();
                        repeat = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Bloga ivestis, bandykite dar karta");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
