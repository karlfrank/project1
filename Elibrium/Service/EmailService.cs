using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Elibrium.BO;

namespace Elibrium.Service
{
    public class EmailService
    {
        public static SmtpClient client = new SmtpClient
        {
            Host = "Smtp.Gmail.com",
            Port = 587,
            EnableSsl = true,
            Timeout = 10000,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new System.Net.NetworkCredential("elibriumapp", "application576"),
        };

        public static bool SendOffer(PersonBO a,string body,string subject)
        {
            string actualBody = String.Format("Hello " + a.Name + ",{0}{0}We at Elibrium have an wonderful offer for you, the details are below{0}{0}" + body + "{0}{0}Elibrium© " + DateTime.Now.Year, Environment.NewLine);
            return SendMessage(a, subject, actualBody);
        }

        public static bool SendBirthdayMessage(PersonBO a)
        {
            string subject = "Happy Birthday to you.";
            string suffix;
            switch (a.Age % 10)
            {
                case 1:
                    suffix = "st";
                    break;
                case 2:
                    suffix = "nd";
                    break;
                case 3:
                    suffix = "rd";
                    break;
                default:
                    suffix = "th";
                    break;
            }
            string msg = "Hello {1}!{0}{0}We wish you a very happy {2}{3} birthday!{0}{0}Your friends at Elibrium";
            string body = String.Format(msg, Environment.NewLine, a.Name, a.Age, suffix);
            return SendMessage(a, subject, body);
        }
        public static bool SendMessage(PersonBO a,string subject,string body)
        {
            string to = a.Email.Value;
            string from = "elibriumapp@gmail.com";
            MailMessage message = new System.Net.Mail.MailMessage(from, to, subject, body);

            try
            {
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in SendMessage(): {0}",
                      ex.ToString());
                return false;
            }
        }

    }
}
