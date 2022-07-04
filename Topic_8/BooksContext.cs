using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic_8.Entities;

namespace Topic_8
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
            //.UseLazyLoadingProxies()
            .UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=BooksDb;Trusted_Connection=True;");

     }
}
