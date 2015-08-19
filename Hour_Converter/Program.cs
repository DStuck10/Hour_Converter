using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Hour_Converter
{
    class Program
    {
        public static double hours, partsHours;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the amount of whole hours worked");
            hours = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the amount of parts of hours worked");
            partsHours = Convert.ToDouble(Console.ReadLine());
            DateTime date = DateTime.Now;

            var fromAddress = new MailAddress("stuckford9@gmail.com", "Dominick Stuck");
            var toAddress = new MailAddress("stuckford9@gmail.com", "Dominick Stuck");
            const string fromPassword = "Shannon!9";
            string subject = "Hours Worked Today: " + date;
            string body = hoursWorked();

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                    Subject = subject,
                    Body = body
            })
            {
                smtp.Send(message);
            }
        }
        public static string hoursWorked()
        {
            const double mins_IN_HOUR = 60;            
            double totalMins = partsHours * mins_IN_HOUR;
            return "Total hours worked for today: " + hours + " Hours and " + Math.Floor(totalMins) + " Minutes";            
        }
    }
}
