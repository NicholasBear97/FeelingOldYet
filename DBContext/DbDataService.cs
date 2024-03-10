using FeelingOldYet.Models;
using Microsoft.EntityFrameworkCore;

namespace DataService
{
    public class DbDataService : DbContext
    {
        public DbDataService() { }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbcOptionsBuilder)
        {
            dbcOptionsBuilder.UseInMemoryDatabase("DataService");
        }
    }
}