using NakedObjects;
using System.Linq;


namespace BookingSystem.Model
{
    //This example service acts as both a 'repository' (with methods for
    //retrieving objects from the database) and as a 'factory' i.e. providing
    //one or more methods for creating new object(s) from scratch.
    public class BookingSystemService
    {
        #region Injected Services
        //An implementation of this interface is injected automatically by the framework
        public IDomainObjectContainer Container { set; protected get; }
        #endregion
        public Appointments CreateNewStudent()
        {
            //'Transient' means 'unsaved' -  returned to the user
            //for fields to be filled-in and the object saved.
            return Container.NewTransientInstance<Appointments>();
        }

        public IQueryable<Appointments> AllStudents()
        {
            //The 'Container' masks all the complexities of 
            //dealing with the database directly.
            return Container.Instances<Appointments>();
        }

        public IQueryable<Appointments> FindStudentByName(string name)
        {
            //Filters students to find a match
            return AllStudents().Where(c => c.FullName.ToUpper().Contains(name.ToUpper()));
        }
    }

}
