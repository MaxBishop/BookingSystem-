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
            var DG = AddNewStudent("Dave Geez",  "Medium");
            var FF = AddNewStudent("Forrest Fortran", "Large");
            var JJ = AddNewStudent("James Java",   "Extra Small");

            context.SaveChanges();
            var Ap1 = AddNewAppointment(new DateTime(2017,05,21), DG);
            var Ap2 = AddNewAppointment(new DateTime(2017, 05, 21), FF);
            var Ap3 = AddNewAppointment(new DateTime(2017, 05, 21), JJ);

            context.SaveChanges();
            var DB = AddNewParent("Dave Bishop", "davebishop@gmail.com");
            var BH = AddNewParent("Boris Harding", "boris@hotmail.com");
            var JW = AddNewParent("John Woods", "Jw@gmail.com");

        }


        private Pupil AddNewStudent(string name,  string ClothingSize)
        {
            var ppl = new Pupil() { FullName = name,  size = ClothingSize };
            Context.Pupils.Add(ppl);
            return (ppl);
        }
        private Appointment AddNewAppointment(DateTime Date, Pupil pupil)
        {
            var App = new Appointment() {DateofAppointment = Date,  Pupil = pupil};
            Context.Appointments.Add(App);
            return (App);
        }
        private Parent AddNewParent(string name, string email)
        {
            var Prnt = new Parent() { FullName = name, Email = email};
            Context.Parents.Add(Prnt);
            return (Prnt);
        }
    }
}
