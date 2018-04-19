using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Model
{
    public class ManagerRepository
    {

            #region Injected Services
            //An implementation of this interface is injected automatically by the framework
            public IDomainObjectContainer Container { set; protected get; }
            #endregion
            public Manager CreateNewManager()
            {
                //'Transient' means 'unsaved' -  returned to the user
                //for fields to be filled-in and the object saved.
                var a = Container.NewTransientInstance<Manager>();
                a.Email = Container.Principal.Identity.Name;
                return a;

            }

            public IQueryable<Manager> AllManagers()
            {
                //The 'Container' masks all the complexities of C:\Users\Max\Documents\GitHub\BookingSystem-\Template_NOF9\BookingSystem.Model\ManagerRepository.cs
                //dealing with the database directly.
                return Container.Instances<Manager>();
            }

        [NakedObjectsIgnore]
        public Manager Me()
            {
                var UserName = Container.Principal.Identity.Name;
                return AllManagers().Where(c => c.Email.Contains(UserName)).FirstOrDefault();

            }
        [NakedObjectsIgnore]
        public bool IsManager()
            {
                if (Me() != null)  
            {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }


