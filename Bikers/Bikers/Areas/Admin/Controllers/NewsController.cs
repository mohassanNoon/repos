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
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.News.ToList());
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create( News news)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        news.CreatedBy = User.Identity.GetUserId();
        //        news.CreatedOn = DateTime.UtcNow.AddHours(5);

        //        db.News.Add(news);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(news);
        //}



        [HttpPost,ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, News news)
        {

            if (ModelState.IsValid)
            {

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = "";
                    var randomFile = "";
                    var uploadDir = "~/Content/Images/NewsFolder";

                    System.IO.Directory.CreateDirectory(Server.MapPath(uploadDir));

                    fileName = file.FileName;
                    string extension = Path.GetExtension(file.FileName);
                    randomFile = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N") + extension;

                    var filePath = Path.Combine(Server.MapPath(uploadDir), randomFile);
                    file.SaveAs(filePath);

                    news.Image = randomFile;
                    news.CreatedBy = User.Identity.GetUserId();
                    news.CreatedOn = DateTime.UtcNow.AddHours(5);

                    db.News.Add(news);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

            }

            return View(news);
        }


        // GET: Admin/News/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( News news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
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
