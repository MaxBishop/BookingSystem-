using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Model
{
    public class Information_Repository
    {
        #region Injected Services
        //An implementation of this interface is injected automatically by the framework
        public IDomainObjectContainer Container { set; protected get; }
        #endregion
        public Information Create()
        {
            //'Transient' means 'unsaved' -  returned to the user
            //for fields to be filled-in and the object saved.
            var a = Container.NewTransientInstance<Information>();
            return a;

        }
        public IQueryable<Information> AllInformation()
        {
            //The 'Container' masks all the complexities of 
            //dealing with the database directly.
            return Container.Instances<Information>();
        }
    }
}
