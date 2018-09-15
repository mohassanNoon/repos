using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bikers.Models;
using Microsoft.AspNet.Identity;

namespace Bikers.Areas.Admin.Controllers
{
    [Authorize]
    public class UpcomingEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.UpcomingEvents.ToList());
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpcomingEvents upcomingEvents = db.UpcomingEvents.Find(id);
            if (upcomingEvents == null)
            {
                return HttpNotFound();
            }
            return View(upcomingEvents);
        }

        public ActionResult Create()
        {
            return View();
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create( UpcomingEvents upcomingEvents)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        upcomingEvents.CreatedBy = User.Identity.GetUserId();
        //        upcomingEvents.CreatedOn = DateTime.UtcNow.AddHours(5);

        //        db.UpcomingEvents.Add(upcomingEvents);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(upcomingEvents);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, UpcomingEvents upcomingEvents)
        {

            if (ModelState.IsValid)
            {

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = "";
                    var randomFile = "";
                    var uploadDir = "~/Content/Images/UpcomingEvents";

                    System.IO.Directory.CreateDirectory(Server.MapPath(uploadDir));

                    fileName = file.FileName;
                    string extension = Path.GetExtension(file.FileName);
                    randomFile = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N") + extension;

                    var filePath = Path.Combine(Server.MapPath(uploadDir), randomFile);
                    file.SaveAs(filePath);

                    upcomingEvents.Images = randomFile;
                    upcomingEvents.CreatedBy = User.Identity.GetUserId();
                    upcomingEvents.CreatedOn = DateTime.UtcNow.AddHours(5);

                    db.UpcomingEvents.Add(upcomingEvents);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

            }

            return View(upcomingEvents);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpcomingEvents upcomingEvents = db.UpcomingEvents.Find(id);
            if (upcomingEvents == null)
            {
                return HttpNotFound();
            }
            return View(upcomingEvents);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( UpcomingEvents upcomingEvents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(upcomingEvents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(upcomingEvents);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpcomingEvents upcomingEvents = db.UpcomingEvents.Find(id);
            if (upcomingEvents == null)
            {
                return HttpNotFound();
            }
            return View(upcomingEvents);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            UpcomingEvents upcomingEvents = db.UpcomingEvents.Find(id);
            db.UpcomingEvents.Remove(upcomingEvents);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
