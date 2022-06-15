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


        }
    }
}
