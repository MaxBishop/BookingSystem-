using NakedObjects;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BookingSystem.Model
{
    public class Appointment
    {
        #region injected services

        public PupilRepository BookingSystemService { set; protected get; }

        #endregion
        //All persisted properties on a domain object must be 'virtual'

        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int Id { get; set; }

        [Title]//This property will be used for the object's title at the top of the view and in a link
        public virtual Appointment Appointments { get; set; }

        public virtual Pupil Pupil { get; set; }

        [PageSize(10)]
        public IQueryable<Pupil> AutoCompleteForCustomer([MinLength(3)] string name)
        {
            return BookingSystemService.FindPupilByName(name);
        }


        public virtual DateTime DateofAppointment { get; set; }
    }
}
