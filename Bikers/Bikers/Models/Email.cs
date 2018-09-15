using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Http;

namespace Bikers.Models
{
    public class EmailSMS
    {
        //public static API_CLONEEntities db = new API_CLONEEntities();
        public static string ToEmailAddress = "mohassannoon@gmail.com";
        public static string SMTP = "smtp.gmail.com";
        public static string Password = "99799092";
        [HttpPost]



        public void SendEmail(string from, string subject, string body)
        {

            MailMessage mail = new MailMessage();
            mail.To.Add(ToEmailAddress);
            mail.From = new MailAddress(from);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient(SMTP);
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential
            (ToEmailAddress, Password) as ICredentialsByHost; ;// Enter seders User name and password
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }



        public static void SendEmail(string to, string body)
        {
            try
            {
                //  var url = db.SMSAPIs.Where(x => x.ID == 1).Select(u => u.SMSLINK);
                WebClient wc = new WebClient();
                //   wc.DownloadString(url + "To=0" + to + "&Message=" + body + "");
            }
            catch (Exception e)
            {

            }


        }
    }
}