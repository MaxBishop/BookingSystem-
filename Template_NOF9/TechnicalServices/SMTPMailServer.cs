using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalServices
{

        public class SMTPMailServer :  IEmailSender
        {
            private static string SMTP_HOST_NAME = "Smtp.gmail.com";
            private static string SMTP_USER = "@gmail.com";

            public void SendTextEmail(string toEmailAddress, string text) 
        {
              
                SmtpClient client = new SmtpClient();
                client.Host = SMTP_HOST_NAME;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("@gmail.com", ""); //to do

                MailMessage message = new MailMessage();
                message.Sender = new MailAddress(SMTP_USER);
                message.From = new MailAddress(SMTP_USER);
                message.To.Add(new MailAddress(toEmailAddress));
                message.Subject = "Stowe School Shop Appointment Reminder";
                message.Body = string.Format("Dear {0}, you have booked an appointment for {1}. We hope to see you soon. If you want to modify your appointment please call x", text ) ;

                client.Send(message);
            }
        }

    }

