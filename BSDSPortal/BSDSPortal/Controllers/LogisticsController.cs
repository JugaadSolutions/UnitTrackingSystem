using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSDSPortal.Controllers
{
    public class LogisticsController : Controller
    {
        // GET: Logistics
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UnitStatusUpdate()
        {
            return View();
        }
    }
}