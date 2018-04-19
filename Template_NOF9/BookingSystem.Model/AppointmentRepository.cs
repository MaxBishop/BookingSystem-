using NakedObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
          //  public IEmailSender EmailSender { set; protected get; }
           public SMTPMailServer email { set; protected get; }
        public Parent Parent { set; protected get; }
        #endregion

        public Appointment CreateNewAppointment()
            {
                //'Transient' means 'unsaved' -  returned to the user
                //for fields to be filled-in and the object saved.
                return Container.NewTransientInstance<Appointment>();
            }
        public Appointment MyAppointment()
        {
            var UserName = Container.Principal.Identity.Name;
            return AllAppointments().Where(c => c.Pupil.Parent.Email.Contains(UserName)).FirstOrDefault();
            

        }
        

    public IQueryable<Appointment> AllAppointments()
            {
                //The 'Container' masks all the complexities of 
                //dealing with the database directly.
                return Container.Instances<Appointment>();
            }

        

        public void SendEmailsToTomorrowsAppointments() 
        {
            var tomorrow = DateTime.Today.AddDays(1);
            var appointments = AppointmentsFor(tomorrow);
            foreach (var appt in appointments)
            {
                string Text = string.Format("Dear {0}, you have booked an appointment for tomorrow. We hope to see you at the shop. If you want to modify your appointment please call us", appt.Pupil.Parent.FullName); //
                email.SendTextEmail(Text, appt.Pupil.Parent.Email.ToString());
            }          
                           
        }

        [Eagerly(EagerlyAttribute.Do.Rendering)][DisplayName("Todays Appointment's") ]
        public IQueryable<Appointment> TodaysAppointments()
        {
            return AppointmentsFor(DateTime.Today);
        }


        [DataType(DataType.DateTime)]
        private IQueryable<Appointment> AppointmentsFor(DateTime d)
        {
            return AllAppointments().Where(C => C.DateofAppointment == d);
        }

        [NakedObjectsIgnore]
        public bool FindConflictingTimes(DateTime date, TimeSlots timeSlot)
        {
            List<Appointment> a = AllAppointments().Where(c => c.DateofAppointment.Equals(date)).ToList();
            List<Appointment> b = new List<Appointment>();
            b = (a.Where(c => c.Timeslot.Equals(timeSlot)).ToList());
            if (b.Count() > 0)
            {
                return false;
            }
            return true;
        }



    }

}







