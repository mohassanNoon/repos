using Bikers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bikers.Controllers.APi
{
    public class TeamMembersController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public IHttpActionResult GetTeam()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.TeamMembers.Select(x => new { x.Name, x.PhoneNumber, x.Image, x.Designation, x.Description }).ToList();
            return  Ok(data); 
        }

        public IHttpActionResult GetGallery()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var galleryData = db.Gallery.Select(x => new { x.Name, x.Images, x.Description }).ToList();
            return Ok(galleryData);
        }

        public IHttpActionResult GetNews()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var newsData = db.News.Select(x => new { x.Remarks, x.Image, x.Heading, x.Description}).ToList();
            return Ok(newsData);
        }

        public IHttpActionResult GetUpEvents()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var eventsData = db.UpcomingEvents.Select(x => new { x.EventName, x.Description, x.Images, x.Remarks, x.Location, x.EventDate }).ToList();
            return Ok(eventsData);
        }

        public IHttpActionResult GetHotels()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var hotelsData = db.Hotels.Select(x => new { x.Name, x.Remarks, x.Phone, x.Image, x.Address }).ToList();
            return Ok(hotelsData);
        }

        public IHttpActionResult GetCamps()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var campsData = db.Camps.Select(x => new { x.Name, x.Remarks, x.Phone, x.Image, x.Address }).ToList();
            return Ok(campsData);
        }
    }
}
