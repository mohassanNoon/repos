using Bikers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bikers.Controllers
{
    public class HomeController : Controller
    {
        private const double V = .1d;
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Events()
        {
            var events = db.Events.OrderByDescending(x=>x.Id).Take(3);
            return PartialView("_Events", events);
        }

        public ActionResult EventDetails(long id)
        {
            var details = db.Events.Where(x => x.Id == id).OrderByDescending(x => x.CreatedOn).FirstOrDefault();
            return View(details);
        }

        public ActionResult TotalEvents()
        {
            var total = db.Events.OrderByDescending(x => x.Id).ToList();
            return View(total);
        }

        public ActionResult UpcomingEvents()
        {
            var Upevents = db.UpcomingEvents.OrderByDescending(x => x.Id).Take(4);
            return PartialView("_UpcomingEvents", Upevents);
        }

        public ActionResult UpcomingEventDetails(long id)
        {
            var det = db.UpcomingEvents.Where(x => x.Id == id).OrderByDescending(x => x.CreatedOn).FirstOrDefault();
            return View(det);
        }

        public ActionResult TotalUpEvents()
        {
            var total = db.UpcomingEvents.OrderByDescending(x => x.Id).ToList();
            return View(total);
        }

        public ActionResult OurTeam()
        {
            var members = db.TeamMembers.Where(x => x.Image != null).ToList();
            return View(members);
        }

        public ActionResult OurTeams()
        {
            var tmembers = db.TeamMembers.Where(x => x.Image != null).ToList();
            return PartialView("_OurTeams", tmembers);
        }

        public ActionResult HotelsDet()
        {
        //    var hotels = db.UpcomingEvents.Where(x => x.Id == id).OrderByDescending(x => x.CreatedOn).FirstOrDefault();
                var hotels = db.Hotels.Where(x => x.Image != null).ToList();
            return View(hotels);
        }
        public ActionResult Hotels()
        {
            //      var hotel = db.UpcomingEvents.OrderByDescending(x => x.Id).Take(4);

            var hotel = db.Hotels.OrderByDescending(x => x.Id).ToList();
            return PartialView("_Hotels", hotel);
        }

        public ActionResult HotelsNews(long id)
        {
            var hotelnews = db.Hotels.Where(x => x.Id == id).OrderByDescending(x => x.CreatedOn).FirstOrDefault();
            return View(hotelnews);
        }

        public ActionResult CampsNews(long id)
        {
            var campnews = db.Camps.Where(x => x.Id == id).OrderByDescending(x => x.CreatedOn).FirstOrDefault();
            return View(campnews);
        }

        public ActionResult Camps()
        {
            var camps = db.Camps.OrderByDescending(x => x.Id).ToList();
            return PartialView("_Camps", camps);
            
        }

        public ActionResult SightsCamps()
        {
            var Scamps = db.Camps.Where(x => x.Image != null).ToList();
            return View(Scamps);
        }

        public ActionResult Galleries()
        {
            var galleries = db.Gallery.Where(x => x.Images != null).ToList();
            return View(galleries);
        }

        public ActionResult Gallery()
        {
            var gal = db.Gallery.OrderByDescending(x => x.Id).Take(3);
            return PartialView("_Gallery",gal);
        }

        public ActionResult Latestnews()
        {
            var latestnews = db.News.OrderByDescending(x => x.Id).ToList();
            return View(latestnews);
        }
        public ActionResult NewsBlog(long id)
        {
            var news = db.News.Where(x => x.Id == id).OrderByDescending(x => x.CreatedOn).FirstOrDefault();
            return View(news);
        }

        public ActionResult News()
        {
            var news = db.News.OrderByDescending(x => x.Id).ToList();
            return PartialView("_News", news);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}