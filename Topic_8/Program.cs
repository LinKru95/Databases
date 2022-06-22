using System;
using Topic_8.Entities;

namespace Topic_8
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new BooksRepository();

            var harryPotterBook = new Book("Harry Potter");
            var lordOfTheRingBook = new Book("Lord of the rings");

            var adventuresCategory = new Category("Adventure");
            var fantasyCategory = new Category("Fantasy");

            adventuresCategory.Books.Add(harryPotterBook);
            fantasyCategory.Books.Add(harryPotterBook);
            fantasyCategory.Books.Add(lordOfTheRingBook);

            repository.CreateCategory(adventuresCategory);
            repository.CreateCategory(fantasyCategory);
            repository.SaveChanges();
        }
    }
}
