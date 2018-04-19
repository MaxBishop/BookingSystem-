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
            var Me = AddNewParent("Boris Harding", "CustomerStowe@gmail.com", 07470473876);  
            var DB = AddNewParent("Dave Bishop", "davebishop@gmail.com", 70480789789);
            var BH = AddNewParent("Boris Harding", "boris@hotmail.com", 70480789789);
            var JW = AddNewParent("John Woods", "Jw@gmail.com", 70480789789);

            context.SaveChanges();
            var DG = AddNewStudent("Dave Geez", Size.M, Sex.Female, Form._6thForm, DB);
            var FF = AddNewStudent("Forrest Fortran", Size.L, Sex.Male, Form._3rdForm, Me);
            var JJ = AddNewStudent("James Java", Size.XS, Sex.Female, Form._6thForm, BH);

            context.SaveChanges();
            var Ap1 = AddNewAppointment(DateTime.Today.AddDays(1), FF); 
            var Ap2 = AddNewAppointment(DateTime.Today.AddDays(2), FF);
            var Ap3 = AddNewAppointment(DateTime.Today.AddDays(3), JJ);

            context.SaveChanges();
            var Blazer = AddNewProduct("Blazer", "Blue", 30.00m, Form._3rdForm, Sex.NotSpecified);
            var shorts = AddNewProduct("shorts", "tight", 10.00m, Form._3rdForm, Sex.Male);
            var tshirt = AddNewProduct("tshirt", "sline", 14.99m, Form._3rdForm, Sex.Male);

            context.SaveChanges();
            var li = AddNewOrder(Status.Arrived);
            var lo = AddNewOrder(Status.Pending);
            var le = AddNewOrder(Status.Shipping);

            context.SaveChanges();
            var hi = AddNewOrderLine(Blazer, 2, li);
            var ho = AddNewOrderLine(shorts, 2, lo);
            var he = AddNewOrderLine(tshirt, 4, lo);

            context.SaveChanges();
            var ma = AddNewManager("ManagerStowe@gmail.com", "JB");
           


        }

        private Parent AddNewParent(string name, string email, long mobile)
        {
            var Prnt = new Parent() { FullName = name, Email = email, Mobile = mobile };
             Context.Parents.Add(Prnt);
            return (Prnt);
        }

        private Pupil AddNewStudent(string name,  Size ClothingSize, Sex sex, Form form, Parent parent)
        {
            var ppl = new Pupil() { FullName = name,  size = ClothingSize, Sex = sex, Form = form, Parent = parent};
            Context.Pupils.Add(ppl);
            return (ppl);
        }
        private Appointment AddNewAppointment(DateTime Date, Pupil pupil)
        {
            var App = new Appointment() {DateofAppointment = Date,  Pupil = pupil};
            Context.Appointments.Add(App);
            return (App);
        }
        

        private Product AddNewProduct(string name, string Description, decimal Price,  Form form, Sex sex)
        {
            var Prod = new Product() { ProductName = name, description = Description, price = Price, Form = form, Sex = sex  };
            Context.Product.Add(Prod);
            return (Prod);
        }
        private OrderLine AddNewOrderLine(Product product, int quantity, Order order)
        {
            var Ol = new OrderLine() { Product = product, Quantity = quantity , Order = order};
            Context.OrderLine.Add(Ol);
            return (Ol);

        }
        private Order AddNewOrder(Status stat)
        {
            var Ord = new Order() { status = stat };
            Context.Order.Add(Ord);
            return (Ord);
        }
        private Manager AddNewManager(string email, string  fullname)
        {
            var Mang = new Manager() {Email = email, FullName = fullname  };
            Context.Manager.Add(Mang);
            return (Mang);
        }

    }
}
