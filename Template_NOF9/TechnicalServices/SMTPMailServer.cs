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
            private static string SMTP_USER = "ManagerStowe@gmail.com";

            public void SendTextEmail(string Text, string Email) 
        {
              
                SmtpClient client = new SmtpClient();
                client.Host = SMTP_HOST_NAME;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("ManagerStowe@gmail.com", "ManagerRepository"); 

                MailMessage message = new MailMessage();
                message.Sender = new MailAddress(SMTP_USER);
                message.From = new MailAddress(SMTP_USER);
                message.To.Add(new MailAddress(Email));
                message.Subject = "Stowe School Shop Appointment Reminder";
                message.Body= Text;
                client.Send(message);
            }
        }

    }

