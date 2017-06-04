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
        #region Injected Services

        public IEmailSender EmailSender { set; protected get; }

        #endregion
        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int Id { get; set; }

        [Title]//This property will be used for the object's title at the top of the view and in a link
        public virtual string FullName { get; set; }

        [RegEx(Validation = @"^[\-\w\.]+@[\-\w\.]+\.[A-Za-z]+$")] // THis validates the email to check its in the correct format- go to manual under "email"
        public virtual string Email { get; set; }

        public virtual long Mobile { get; set; }

       
     public void emailallert()
       {
            string parent = FullName;
           // DateTime now = DateofAppointment;
            string text = "Dear {parent}, / You have booked an appointment for the ";
            EmailSender.SendTextEmail(Email, text);
       }
    }
}
