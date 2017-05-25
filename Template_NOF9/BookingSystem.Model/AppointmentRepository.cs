using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

           public IQueryable<Pupil> FindPupilByName(string name)
            {
                //Filters students to find a match
                return null; //AllAppointments().Where(c => c.FullName.ToUpper().Contains(name.ToUpper()));
            }

        [Eagerly(EagerlyAttribute.Do.Rendering)]
        public IQueryable<Appointment> TodaysAppointments()
        {
            return AllAppointments().Where(C => C.DateofAppointment == (DateTime.Today));
        }
        
        }
   
    }







