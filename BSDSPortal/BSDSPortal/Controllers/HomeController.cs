using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSDSPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Manage()
        {
            ViewBag.Title = "Manage";
            return View();
        }

        public ActionResult RealTime()
        {
            ViewBag.Title = "Real Time";
            return View();
        }

        public ActionResult TesterGroup_1MVA()
        {
           
            return View();
        }
    }
}
