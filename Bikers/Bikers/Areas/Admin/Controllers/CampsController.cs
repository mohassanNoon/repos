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
    public class CampsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Camps.ToList());
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camps camps = db.Camps.Find(id);
            if (camps == null)
            {
                return HttpNotFound();
            }
            return View(camps);
        }

        public ActionResult Create()
        {
            return View();
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create( Camps camps)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        camps.CreatedBy = User.Identity.GetUserId();
        //        camps.CreatedOn = DateTime.UtcNow.AddHours(5);
        //        db.Camps.Add(camps);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(camps);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, Camps camps)
        {

            if (ModelState.IsValid)
            {

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = "";
                    var randomFile = "";
                    var uploadDir = "~/Content/Images/CampsImg";

                    System.IO.Directory.CreateDirectory(Server.MapPath(uploadDir));

                    fileName = file.FileName;
                    string extension = Path.GetExtension(file.FileName);
                    randomFile = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N") + extension;

                    var filePath = Path.Combine(Server.MapPath(uploadDir), randomFile);
                    file.SaveAs(filePath);

                    camps.Image = randomFile;
                    camps.CreatedBy = User.Identity.GetUserId();
                    camps.CreatedOn = DateTime.UtcNow.AddHours(5);

                    db.Camps.Add(camps);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

            }

            return View(camps);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camps camps = db.Camps.Find(id);
            if (camps == null)
            {
                return HttpNotFound();
            }
            return View(camps);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Camps camps)
        {
            if (ModelState.IsValid)
            {
                db.Entry(camps).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(camps);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camps camps = db.Camps.Find(id);
            if (camps == null)
            {
                return HttpNotFound();
            }
            return View(camps);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Camps camps = db.Camps.Find(id);
            db.Camps.Remove(camps);
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
