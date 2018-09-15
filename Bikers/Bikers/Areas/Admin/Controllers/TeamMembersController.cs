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
    public class TeamMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.TeamMembers.ToList());
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMembers teamMembers = db.TeamMembers.Find(id);
            if (teamMembers == null)
            {
                return HttpNotFound();
            }
            return View(teamMembers);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(TeamMembers teamMembers)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        teamMembers.CreatedBy = User.Identity.GetUserId();
        //        teamMembers.CreatedOn = DateTime.UtcNow.AddHours(5);

        //        db.TeamMembers.Add(teamMembers);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(teamMembers);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, TeamMembers teamMembers)
        {

            if (ModelState.IsValid)
            {

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = "";
                    var randomFile = "";
                    var uploadDir = "~/Content/Images/TeamMembers";

                    System.IO.Directory.CreateDirectory(Server.MapPath(uploadDir));

                    fileName = file.FileName;
                    string extension = Path.GetExtension(file.FileName);
                    randomFile = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N") + extension;

                    var filePath = Path.Combine(Server.MapPath(uploadDir), randomFile);
                    file.SaveAs(filePath);

                    teamMembers.Image = randomFile;
                    teamMembers.CreatedBy = User.Identity.GetUserId();
                    teamMembers.CreatedOn = DateTime.UtcNow.AddHours(5);

                    db.TeamMembers.Add(teamMembers);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

            }

            return View(teamMembers);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMembers teamMembers = db.TeamMembers.Find(id);
            if (teamMembers == null)
            {
                return HttpNotFound();
            }
            return View(teamMembers);
        }
        
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(TeamMembers teamMembers)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(teamMembers).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(teamMembers);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeamMembers teamMembers, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var tm = db.TeamMembers.Find(teamMembers.Id);


                tm.Designation = teamMembers.Designation;
                tm.Name = teamMembers.Name;
                tm.Email = teamMembers.Email;
                tm.PhoneNumber = teamMembers.PhoneNumber;
                tm.Description = teamMembers.Description;
                tm.UpdatedBy = User.Identity.GetUserId();
                tm.UpdatedOn = DateTime.Now;

                tm.Remarks = teamMembers.Remarks;

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = "";
                    var randomFile = "";
                    var uploadDir = "~/Content/Images/TeamMembers";

                    System.IO.Directory.CreateDirectory(Server.MapPath(uploadDir));

                    fileName = file.FileName;
                    string extension = Path.GetExtension(file.FileName);
                    randomFile = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N") + extension;

                    var filePath = Path.Combine(Server.MapPath(uploadDir), randomFile);
                    file.SaveAs(filePath);

                    tm.Image = randomFile;
                }

                db.Entry(tm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teamMembers);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMembers teamMembers = db.TeamMembers.Find(id);
            if (teamMembers == null)
            {
                return HttpNotFound();
            }
            return View(teamMembers);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TeamMembers teamMembers = db.TeamMembers.Find(id);
            db.TeamMembers.Remove(teamMembers);
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
