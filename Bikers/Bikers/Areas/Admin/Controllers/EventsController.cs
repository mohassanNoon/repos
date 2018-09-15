using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bikers.Models;
using Bikers.Models.ImageProcessor;
using Microsoft.AspNet.Identity;

namespace Bikers.Areas.Admin.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Events events)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        events.CreatedBy = User.Identity.GetUserId();
        //        events.CreatedOn = DateTime.UtcNow.AddHours(5);

        //        db.Events.Add(events);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(events);
        //}

        [HttpPost,ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase[] file, Events events)
        {
            try
            {
                var check = 0;
                foreach (var item in file)
                {

                    if (item != null && item.ContentLength > 0)
                    {
                        var fileName = "";
                        var randomFile = "";
                        var uploadDir = "~/Content/Images/EventsPictures";

                        System.IO.Directory.CreateDirectory(Server.MapPath(uploadDir));

                        fileName = item.FileName;
                        string extension = Path.GetExtension(item.FileName);
                        randomFile = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N") +
                                     extension;

                        var filePath = Path.Combine(Server.MapPath(uploadDir), randomFile);


                        //code to compress n save image
                        Image i = Image.FromStream(item.InputStream);
                        ImageProcessingManager imgprocess = new ImageProcessingManager(filePath);
                        imgprocess.SaveCompressedImage(i);

                        if (check != 0)
                        {
                            events.Images = events.Images + "," + randomFile;
                        }
                        else
                        {
                            events.Images = randomFile;
                        }
                        check = 1;
                    }
                }

                events.CreatedBy = User.Identity.GetUserId();
                events.CreatedOn = DateTime.UtcNow.AddHours(5);
                
                db.Events.Add(events);
                db.SaveChanges();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Events events)
        {
            if (ModelState.IsValid)
            {



                db.Entry(events).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(events);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Events events = db.Events.Find(id);
            db.Events.Remove(events);
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
