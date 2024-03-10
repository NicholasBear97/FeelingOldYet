using FeelingOldYet.Models;
using Microsoft.EntityFrameworkCore;

namespace DataService
{
    public class DbDataService : DbContext
    {
        #region Constructors
        public DbDataService() { }
        #endregion

        #region Properties
        public DbSet<Person> People { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Configure in memory db
        /// </summary>
        /// <param name="dbcOptionsBuilder">Simple API to configure the db options</param>
        protected override void OnConfiguring(DbContextOptionsBuilder dbcOptionsBuilder)
        {
            dbcOptionsBuilder.UseInMemoryDatabase("DataService");
        }

        /// <summary>
        /// Add a person to the people table and order the table by descending ids (last inserted). Save changes.
        /// </summary>
        /// <param name="person"></param>
        public void ProccessData(Person person)
        {
            Add(person);
            People.OrderByDescending(x => x.Id);
            SaveChanges();
        }

        /// <summary>
        /// Clear the People table.
        /// </summary>
        public void ClearPeople()
        {
            foreach (Person person in People) 
            {
                People.Remove(person);
            }
            SaveChanges();
        }
        #endregion
    }
}