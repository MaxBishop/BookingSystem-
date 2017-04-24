
using System.Data.Entity;
using Template.Model;

namespace ExampleDbContext.DataBase
{
    public class BookingSystemDbContext : DbContext
    {
        public BookingSystemDbContext(string dbName) : base(dbName)
        {
            Database.SetInitializer(new BookingSystemDbinitializer());
        }

        public DbSet<Student> Students { get; set; }
    }

}
