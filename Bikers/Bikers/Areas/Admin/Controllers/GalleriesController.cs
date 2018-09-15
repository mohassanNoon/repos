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
    public class GalleriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Gallery.ToList());
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Gallery.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        public ActionResult Create()
        {
            return View();
        }

        
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create( Gallery gallery)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        gallery.CreatedBy = User.Identity.GetUserId();
        //        gallery.CreatedOn = DateTime.UtcNow.AddHours(5);

        //        db.Gallery.Add(gallery);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(gallery);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase[] file, Gallery galleries)
        {

            if (ModelState.IsValid)
            {
                var check = 0;
                foreach (var item in file)
                {
                    if (item != null && item.ContentLength > 0)
                    {

                        var fileName = "";
                        var randomFile = "";
                        var uploadDir = "/Content/Images/GalleryImages";

                        System.IO.Directory.CreateDirectory(Server.MapPath(uploadDir));

                        fileName = item.FileName;
                        string extension = Path.GetExtension(item.FileName);
                        randomFile = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N") + extension;

                        var filePath = Path.Combine(Server.MapPath(uploadDir), randomFile);
                        item.SaveAs(filePath);

                        if (check != 0)
                        {
                            galleries.Images = galleries.Images + "," + randomFile;
                        }
                        else
                        {
                            galleries.Images = randomFile;
                        }
                        check = 1;
                    }
                }

                galleries.CreatedBy = User.Identity.GetUserId();
                galleries.CreatedOn = DateTime.UtcNow.AddHours(5);

                db.Gallery.Add(galleries);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(galleries);
            //ViewBag.GalleryId = new SelectList(db.GalleryFolder.Where(x => x.IsDeleted == false), "Id", "Name", gal.GalleryId);
            //return View(gal);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Gallery.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gallery gallery, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var gal = db.Gallery.Find(gallery.Id);
                gal.Name = gallery.Name;
                gal.Description = gallery.Description;
                gal.UpdatedBy = User.Identity.GetUserId();
                gal.UpdatedOn = DateTime.Now;

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = "";
                    var randomFile = "";
                    var uploadDir = "~/Content/Images/GalleryImages";

                    System.IO.Directory.CreateDirectory(Server.MapPath(uploadDir));

                    fileName = file.FileName;
                    string extension = Path.GetExtension(file.FileName);
                    randomFile = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N") + extension;

                    var filePath = Path.Combine(Server.MapPath(uploadDir), randomFile);
                    file.SaveAs(filePath);

                    gal.Images = randomFile;
                }

                db.Entry(gal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gallery);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,Images,Description,IsDeleted,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,DeletedBy,DeletedOn,IsActive,Remarks")] Gallery gallery)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(gallery).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(gallery);
        //}

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Gallery.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Gallery gallery = db.Gallery.Find(id);
            db.Gallery.Remove(gallery);
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
