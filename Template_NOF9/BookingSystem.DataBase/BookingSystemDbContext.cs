
using System.Data.Entity;
using BookingSystem.Model;

namespace BookingSystem.DataBase
{
    public class BookingSystemDbContext : DbContext
    {
        public BookingSystemDbContext(string dbName) : base(dbName)
        {
            Database.SetInitializer(new BookingSystemDbinitializer());
        }

        public DbSet<Pupil> Pupils { get; set; }

        public DbSet<Appointment> Appointments { get; set; }
    }

}
