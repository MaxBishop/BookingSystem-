using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BookingSystem.Model;
using System;

namespace BookingSystem.DataBase
{
    public class BookingSystemDbinitializer : DropCreateDatabaseIfModelChanges<BookingSystemDbContext>
    {
        private BookingSystemDbContext Context;
        protected override void Seed(BookingSystemDbContext context)
        {
            this.Context = context;
            AddNewStudent("Dave Geez", "MB@gmail.com", "Medium");
            AddNewStudent("Forrest Fortran", "MB@gmail.com", "Medium");
            AddNewStudent("James Java",  "MB@gmail.com", "Medium");
        }

        private void AddNewStudent(string name, string Em, string ClothingSize)
        {
            var st = new Pupil() { FullName = name, Email = Em, size = ClothingSize };
            Context.Pupil.Add(st);
        }
    }
}
