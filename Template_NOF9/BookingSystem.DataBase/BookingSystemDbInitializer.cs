using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BookingSystem.Model;
using System;

namespace BookingSystem.DataBase
{
    public class BookingSystemDbinitializer : DropCreateDatabaseAlways<BookingSystemDbContext> // change between always and IfModelChanges
    {
        private BookingSystemDbContext Context;
        protected override void Seed(BookingSystemDbContext context)
        {
            this.Context = context;
            AddNewStudent("Dave Geez", "MB@gmail.com", "Medium");
            AddNewStudent("Forrest Fortran", "HC@gmail.com", "Large");
            AddNewStudent("James Java",  "DM@gmail.com", "Extra Small");

            context.SaveChanges();
            AddNewAppointment(new DateTime(2017,05,18), 1);
            AddNewAppointment(new DateTime(2017, 05, 18), 2);
            AddNewAppointment(new DateTime(2017, 05, 18), 3);

        }


        private void AddNewStudent(string name, string Em, string ClothingSize)
        {
            var st = new Pupil() { FullName = name, Email = Em, size = ClothingSize };
            Context.Pupils.Add(st);
        }
        private void AddNewAppointment(DateTime Date, int pupilId)
        {
            var st = new Appointment() {DateofAppointment = Date,  PupilId = pupilId};
            Context.Appointments.Add(st);
        }
    }
}
