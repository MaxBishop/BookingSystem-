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
            private static string SMTP_USER = "maxbishop3@gmail.com";

            public void SendTextEmail(string toEmailAddress, string text)
            {
                SmtpClient client = new SmtpClient();
                client.Host = SMTP_HOST_NAME;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("maxbishop3@gmail.com", "password"); //to do

                MailMessage message = new MailMessage();
                message.Sender = new MailAddress(SMTP_USER);
                message.From = new MailAddress(SMTP_USER);
                message.To.Add(new MailAddress(toEmailAddress));
                message.Subject = "Expenses notification";
                message.Body = text;

                client.Send(message);
            }
        }

    }

