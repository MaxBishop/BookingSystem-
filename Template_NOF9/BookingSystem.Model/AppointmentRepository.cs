using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalServices;

namespace BookingSystem.Model
{
    public class AppointmentRepository 
    {
        //This example service acts as both a 'repository' (with methods for
        //retrieving objects from the database) and as a 'factory' i.e. providing
        //one or more methods for creating new object(s) from scratch.

            #region Injected Services
            //An implementation of this interface is injected automatically by the framework
            public IDomainObjectContainer Container { set; protected get; }
            public IEmailSender EmailSender { set; protected get; }
            public Parent Parent { set; protected get; }
        #endregion

        public Appointment CreateNewAppointment()
            {
                //'Transient' means 'unsaved' -  returned to the user
                //for fields to be filled-in and the object saved.
                return Container.NewTransientInstance<Appointment>();
            }

            public IQueryable<Appointment> AllAppointments()
            {
                //The 'Container' masks all the complexities of 
                //dealing with the database directly.
                return Container.Instances<Appointment>();
            }

          // public IQueryable<Pupil> FindPupilByName(string name)
            //{
                //Filters students to find a match
               //// return null; //AllAppointments().Where(c => c.FullName.ToUpper().Contains(name.ToUpper()));
         //  }
        public void SendEmailsToTomorrowsAppointments() //to do
        {
            var tomorrow = DateTime.Today.AddDays(1);
            var appointments = AppointmentsFor(tomorrow);
            foreach (var appt in appointments)
            {
                string Text = string.Format("Dear {0}, you have booked an appointment for {1}. We hope to see you soon. If you want to modify your appointment please call x",Parent.FullName, Parent.Email);
                EmailSender.SendTextEmail(Text);
            }          
                           
        }

        [Eagerly(EagerlyAttribute.Do.Rendering)]
        public IQueryable<Appointment> TodaysAppointments()
        {
            return AppointmentsFor(DateTime.Today);
        }

        private IQueryable<Appointment> AppointmentsFor(DateTime d)
        {
            return AllAppointments().Where(C => C.DateofAppointment == d);
        }


    }

}







