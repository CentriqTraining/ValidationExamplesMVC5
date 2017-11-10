using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateBlogUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBlogUser(BlogUser user)
        {
            //  Remote validation is ONLY for CLIENT-SIDE validation'
            //  So make sure you validate server-side as well
            //  Here we are manually validating the incoming UserName\
            //  And manually adding any error message that comes back
            //  into the ModelState Model Error collection
            var result = ValidateUserName(user.UserName);
            if (result != string.Empty)
            {
                ModelState.AddModelError("UserName", result);
            }

            if (ModelState.IsValid)
            {

            }
            return View();
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

        //  Return Json Result
        //  TRUE, means validation success
        //  ANYTHING ELSE is automatically used as the 
        //  Error validation message
        public JsonResult IsUserName_Available(string UserName)
        {
            var result = ValidateUserName(UserName);
            if (result == string.Empty)
            {
                return Json(true, JsonRequestBehavior.AllowGet);

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private string ValidateUserName(string userName)
        {
            //  Easy to validate.  Set it to Bubba to get
            //  A client-side validation error.
            //  Set it to anything else for success
            if (userName == "Bubba")
            {
                return "That username is already taken";
            }
            return string.Empty;
        }
    }
}