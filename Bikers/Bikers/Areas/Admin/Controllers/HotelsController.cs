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
    public class HotelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Hotels
        public ActionResult Index()
        {
            return View(db.Hotels.ToList());
        }

        // GET: Admin/Hotels/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotels hotels = db.Hotels.Find(id);
            if (hotels == null)
            {
                return HttpNotFound();
            }
            return View(hotels);
        }

        // GET: Admin/Hotels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Hotels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //     [HttpPost]
        //     [ValidateAntiForgeryToken]
        //public ActionResult Create( Hotels hotels)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        hotels.CreatedBy = User.Identity.GetUserId();
        //        hotels.CreatedOn = DateTime.UtcNow.AddHours(5);
        //        db.Hotels.Add(hotels);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(hotels);
        //}


        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, Hotels hotels)
        {

            if (ModelState.IsValid)
            {

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = "";
                    var randomFile = "";
                    var uploadDir = "~/Content/Images/HotelsImg";

                    System.IO.Directory.CreateDirectory(Server.MapPath(uploadDir));

                    fileName = file.FileName;
                    string extension = Path.GetExtension(file.FileName);
                    randomFile = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N") + extension;

                    var filePath = Path.Combine(Server.MapPath(uploadDir), randomFile);
                    file.SaveAs(filePath);

                    hotels.Image = randomFile;
                    hotels.CreatedBy = User.Identity.GetUserId();
                    hotels.CreatedOn = DateTime.UtcNow.AddHours(5);

                    db.Hotels.Add(hotels);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

            }

            return View(hotels);
        }


        // GET: Admin/Hotels/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotels hotels = db.Hotels.Find(id);
            if (hotels == null)
            {
                return HttpNotFound();
            }
            return View(hotels);
        }

        // POST: Admin/Hotels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Image,IsDeleted,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,DeletedBy,DeletedOn,IsActive,Remarks")] Hotels hotels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotels);
        }

        // GET: Admin/Hotels/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotels hotels = db.Hotels.Find(id);
            if (hotels == null)
            {
                return HttpNotFound();
            }
            return View(hotels);
        }

        // POST: Admin/Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Hotels hotels = db.Hotels.Find(id);
            db.Hotels.Remove(hotels);
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
