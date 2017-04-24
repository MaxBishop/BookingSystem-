using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Template.Model;

namespace ExampleDbContext.DataBase
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
            var st = new Student() { FullName = name };
            Context.Students.Add(st);
        }
    }
}
