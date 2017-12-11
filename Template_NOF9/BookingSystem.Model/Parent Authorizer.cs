using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace BookingSystem.Model
{
    public class Parent_Authorizer : ITypeAuthorizer<Parent>
    {
        public bool IsEditable(IPrincipal principal, Parent target, string memberName)
        {
            return true;
        }

        public bool IsVisible(IPrincipal principal, Parent target, string memberName)
        {
            throw new NotImplementedException();
        }
    }
}
