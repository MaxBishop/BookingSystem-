using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BookingSystem.Model;

namespace BookingSystem.DataBase
{
    public class BookingSystemDbinitializer : DropCreateDatabaseIfModelChanges<BookingSystemDbContext>
    {
        private BookingSystemDbContext Context;
        protected override void Seed(BookingSystemDbContext context)
        {
            this.Context = context;
            AddNewStudent("Alie Algol");
            AddNewStudent("Forrest Fortran");
            AddNewStudent("James Java");
        }

        private void AddNewStudent(string name)
        {
            var st = new Appointments() { FullName = name };
            Context.Appointments.Add(st);
        }
    }
}
