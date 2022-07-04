using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic_8.Entities;

namespace Topic_8
{
    public class BooksRepository
    {
        private readonly BooksContext _dbContext;
        public BooksRepository()
        {
            _dbContext = new BooksContext();
        }
        public void CreateCategory(Category category)
        {
            _dbContext.Categories.Add(category);
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public List<Book> GetBooksLazily(string bookNameSubString)
        {
            return _dbContext.Books.Include(x => x.Categories).Where(x => x.Name.Contains(bookNameSubString)).ToList();
        }
    }
}
