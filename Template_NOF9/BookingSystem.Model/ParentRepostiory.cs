using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Model
{
    public class ParentRepostiory
    {
        #region Injected Services
        //An implementation of this interface is injected automatically by the framework
        public IDomainObjectContainer Container { set; protected get; }
        #endregion
        public Parent CreateNewParent()
        {
            //'Transient' means 'unsaved' -  returned to the user
            //for fields to be filled-in and the object saved.
            return Container.NewTransientInstance<Parent>();
        }

        public IQueryable<Parent> AllParents()
        {
            //The 'Container' masks all the complexities of 
            //dealing with the database directly.
            return Container.Instances<Parent>();
        }

        public IQueryable<Parent> FindParentByName(string name)
        {
            //Filters students to find a match
            return AllParents().Where(c => c.FullName.ToUpper().Contains(name.ToUpper()));
        }
    }
}
