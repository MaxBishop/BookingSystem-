using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace BookingSystem.Model
{
    [NotMapped]
    public class RegistrationForm : IViewModelEdit
    {
        

        public IDomainObjectContainer Container { set; protected get; }  

        public virtual string PupilName { get; set; }
        


        public virtual TimeSlots Timeslot { get; set; }

        public virtual Size Size { get; set; }

        public virtual Form Form { get; set; }

        public virtual Sex Sex { get; set; }

        public virtual string ParentName { get; set; }
    
        public virtual long Mobile { get; set; }

        public AppointmentRepository appointmentrepository { set; protected get; }

        public virtual DateTime DateofAppointment { get; set; }   
        
        public string ValidateDateofAppointment(DateTime date)
        {
            var rb = new ReasonBuilder();
            rb.AppendOnCondition(appointmentrepository.FindConflictingTimes(date, Timeslot) == false, "Enter another timeslot, this one is already booked"); 
            rb.AppendOnCondition((date < DateTime.Today) | (date > DateTime.Today.AddYears(1)), "Enter correct date");
            return rb.Reason;

        }

        public DateTime DefaultDateofAppointment()
        {
            return DateTime.Today;
        }


public void Register()// saving objects
        {
            var pup = Container.NewTransientInstance<Pupil>();
            pup.FullName = PupilName;
            pup.size = Size;
            pup.Form = Form;
            pup.Sex = Sex;
            Container.Persist(ref pup);
            var par = Container.NewTransientInstance<Parent>();
            par.FullName = ParentName;
            par.Mobile = Mobile;
            par.Email = Container.Principal.Identity.Name; 
            Container.Persist(ref par);
            pup.Parent = par;
            var app = Container.NewTransientInstance<Appointment>();
            app.DateofAppointment = DateofAppointment;
            app.Timeslot = Timeslot;
            Container.Persist(ref app);
            app.Pupil = pup;
        }

        public string[] DeriveKeys()
        {
            return new string[] {  "1" };  
        }

        public void PopulateUsingKeys(string[] keys)
        {

        }
       
    }


}

