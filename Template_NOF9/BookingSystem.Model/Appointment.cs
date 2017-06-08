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

        public IDomainObjectContainer Container { set; protected get; }

        #endregion
        //All persisted properties on a domain object must be 'virtual'


        public string Title()
        {
            var t = Container.NewTitleBuilder();
            t.Append(DateofAppointment, "dd MMM yy", null).Append(Pupil);

            return t.ToString();
        }



        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int Id { get; set; }

       //This property will be used for the object's title at the top of the view and in a link
        //public virtual Appointment Appointments { get; set; }

        [NakedObjectsIgnore]
        public virtual int PupilId { get; set; }

        public virtual Pupil Pupil { get; set; }

        [PageSize(10)]
        public IQueryable<Pupil> AutoCompletePupil([MinLength(3)] string name)
        {
            return BookingSystemService.FindPupilByName(name);
        }

     
        public virtual DateTime DateofAppointment { get; set; }


        public virtual TimeSlots Timeslot { get; set; }




    }
}
