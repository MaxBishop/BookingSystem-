using NakedObjects;
using System.Linq;


namespace BookingSystem.Model
{
    //This example service acts as both a 'repository' (with methods for
    //retrieving objects from the database) and as a 'factory' i.e. providing
    //one or more methods for creating new object(s) from scratch.
    public class PupilRepository
    {
        #region Injected Services
        //An implementation of this interface is injected automatically by the framework
        public IDomainObjectContainer Container { set; protected get; }
        public ParentRepostiory Parent { set; protected get; }


        #endregion
        public Pupil CreateNewPupil()
        {
            //'Transient' means 'unsaved' -  returned to the user
            //for fields to be filled-in and the object saved.
            var a = Container.NewTransientInstance<Pupil>();
            a.Parent = Parent.Me();
            return a;
        }

        public IQueryable<Pupil> AllPupils()
        {
            //The 'Container' masks all the complexities of 
            //dealing with the database directly.
            return Container.Instances<Pupil>();
        }

        public IQueryable<Pupil> FindPupilByName(string name)
        {
            //Filters students to find a match
            return AllPupils().Where(c => c.FullName.ToUpper().Contains(name.ToUpper()));
        }
        public IQueryable<Pupil> MyChildren()
        {
            var parent = Parent.Me();
            string Email = parent.Email;
            return AllPupils().Where(c => c.Parent.Email == Email);

        }
    }

}
