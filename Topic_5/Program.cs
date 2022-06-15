using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Topic_5
{
    class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new BookContext();

            //INSERT

            //var page = new Page(1, "1 skyrius");
            //dbContext.Pages.Add(page);
            //dbContext.SaveChanges();

            //SELECT AND DELETE

            //var pageFromDb = dbContext.Pages.FirstOrDefault(x => x.Number == 1);
            //dbContext.Pages.Remove(pageFromDb);
            //dbContext.SaveChanges();

            //SELECT AND UPDATE

            //var pageFromDb = dbContext.Pages.AsNoTracking().FirstOrDefault(x => x.Number == 1);
            //pageFromDb.Content += ". Adding update";
            //dbContext.SaveChanges();

            // CREATE BOOK WITH PAGES

            //var book = new Book("Harry Potter");
            //for (int i = 1; i < 500; i++)
            //{
            //    book.Pages.Add(new Page(i, $"content: {i}"));
            //}
            //dbContext.Add(book);
            //dbContext.SaveChanges();

            // SELECT BOOK WITH PAGES

            //var bookFromDb = dbContext.Books.Include(x => x.Pages).FirstOrDefault(x => x.Name == "Harry Potter");
            //Console.WriteLine(bookFromDb.Id);

            // SELECT PAGE WITH BOOK

            //var pageFromBook = dbContext.Pages.Include(x=>x.Book).FirstOrDefault(x => x.Number == 12);
            //Console.WriteLine(pageFromBook.Book.Name);

            // DELETE BOOK WITH PAGES

            //var bookFromDb = dbContext.Books.Include(x => x.Pages).FirstOrDefault(x => x.Name == "Harry Potter");
            //dbContext.Books.Remove(bookFromDb);
            //dbContext.SaveChanges();
        }
    }
}
