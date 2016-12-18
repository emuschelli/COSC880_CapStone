using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WarApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Why the WAR?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "For Technical Support, please contact the Technical Support Team.";

            return View();
        }
    }
}