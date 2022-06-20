using Microsoft.EntityFrameworkCore;

namespace GradeBookDb
{
    public class GradeBookContext : DbContext
    {
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=GradeBookDb;Trusted_Connection=True;");
    }
}
