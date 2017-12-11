using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;
using NakedObjects.Value;

namespace BookingSystem.Model
{
    public class Pupil

    {
        #region injected services

        public IDomainObjectContainer Container { set; protected get; }

        #endregion
        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int Id { get; set; }

        [Title]//This property will be used for the object's title at the top of the view and in a link
        public virtual string FullName { get; set; }

        public virtual string size { get; set; }


        public virtual Form Form { get; set; }

        public virtual Sex Sex { get; set; }

        [Disabled]
        public virtual Parent Parent { get; set; }






    }
}
