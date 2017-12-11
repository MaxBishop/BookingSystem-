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
    

    public class DefaultAuthorizer : ITypeAuthorizer<Object>
    {
        public ParentRepostiory Parent_Repository { set; protected get; }

        public bool IsEditable(IPrincipal principal, object target, string memberName)
        {
            if (typeof(Product).IsAssignableFrom(target.GetType()) & Parent_Repository.IsManager() == true) //is the target a product 
            {
                return true;
            }
            else
            {
                return false;
            }
            //TypeUtils.IsPropertyMatch<Parent, long>(target, memberName, x => x.Mobile);  typesafe way of checking a member name 
        }



        public bool IsVisible(IPrincipal principal, object target, string memberName)
        {
            return true;
        }
    }
}
