using Bikers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bikers.Controllers
{
    public class EmailController : Controller
    {
        // GET: Admin/Email
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmailBody(string Name, string Email, string Message)
        {

            string body = "<h3>User Name:</h3>" + Name + "<br><h3>Email Address:</h3>" + Email + "<br><h3>Phone Number:</h3>  <br><h3>Message:</h3>" + Message;
            string subject = "Contact From Website";
            string to = "mohassannoon@gmail.com";
            EmailSMS send = new EmailSMS();
            send.SendEmail(Email, subject, body);
            return Json(new { status = true, message = "success" }, JsonRequestBehavior.AllowGet);
        }
    }
}