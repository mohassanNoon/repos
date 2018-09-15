using Bikers.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Bikers.Controllers.APi
{
    public class RegisterationController : ApiController
    {

        private ApplicationUserManager _userManager;

        public static string success = "Success";
        public static string failure = "Failed";

        public static string exception = "Exception Occured!";

        ApplicationDbContext db = new ApplicationDbContext();

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }

            private set
            {
                _userManager = value;
            }
        }
        [HttpPost]
        public async Task<IHttpActionResult> PostVisitor(VisitorsViewModel model)
        {

            try
            {
                var check = db.Users.Where(x => x.Email == model.Email || x.UserName == model.Username).FirstOrDefault();
                if (check == null)
                {
                   
                    var user = new ApplicationUser { UserName = model.Username, PhoneNumber = model.Phone, Email = model.Email};
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {

                        return Json(new
                        {
                            Status = 0,
                            Exception = "",
                            Message = success,
                            Data = ""
                        });
                    }
                    else
                    {
                        return Json(new
                        {
                            Status = 0,
                            Exception = "",
                            Message = failure,
                            Data = ""
                        });
                    }
                    
                }
                else
                {
                    return Json(new
                    {
                        Status = 0,
                        Exception = "",
                        Message = "Already",
                        Data = ""
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Status = 1,
                    Exception = ex.Message,
                    Message = failure,
                    Data = ""
                });
            }
        }
    }

    public class VisitorsViewModel
    {
        public string Username { get; set; }
       public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
