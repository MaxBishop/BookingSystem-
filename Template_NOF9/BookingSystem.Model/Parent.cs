using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalServices;



namespace BookingSystem.Model
{
    public class Parent 
    {

        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int Id { get; set; }

        [Title]//This property will be used for the object's title at the top of the view and in a link
        public virtual string FullName { get; set; }

        [Disabled] [RegEx(Validation = @"^[\-\w\.]+@[\-\w\.]+\.[A-Za-z]+$")]// THis validates the email to check its in the correct format- go to manual under "email"
        public virtual string Email { get; set; }

        [RegEx(Validation = @"^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$")]
        public virtual long Mobile { get; set; }


       

         
    }
}
