using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using NakedObjects.Util;

namespace BookingSystem.Model
{

    public class Authorizer : ITypeAuthorizer<Object>
    {
        public ManagerRepository Manager_Repository { set; protected get; }
        

        public bool IsEditable(IPrincipal principal, object target, string memberName)
        {
            if ((memberName == "CreateNewProduct") | (memberName == "Create") 
                | (typeof(Information).IsAssignableFrom(target.GetType())) 
                | (typeof(Product).IsAssignableFrom(target.GetType())))
            { 
                if (Manager_Repository.IsManager() == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
            
        }



        public bool IsVisible(IPrincipal principal, object target, string memberName)
        {

            if ((memberName == "TodaysAppointments") | (memberName == "SendEmailsToTomorrowsAppointments") 
                | (memberName == "AllAppointments") | (memberName == "CreateNewAppointment") 
                | (memberName == "AddOrChangePhotoInfo") | (memberName == "AddOrChangePhoto") 
                | (memberName == "CreateNewProduct") | (memberName == "Create") 
                | (memberName == "FindPupilByName") | (memberName == "AllPupils") 
                | (memberName == "AllOrders") | (typeof(ParentRepostiory).IsAssignableFrom(target.GetType())) 
                | (typeof(ManagerRepository).IsAssignableFrom(target.GetType())))
            {
                if (Manager_Repository.IsManager() == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
            




        }
    }
}

