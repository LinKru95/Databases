using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic_5
{
    public class BookContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=BooksWithPagesDb;Trusted_Connection=True;");
    }
}
