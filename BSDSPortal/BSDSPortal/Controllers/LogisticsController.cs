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
        public ActionResult UnitStatusUpdate(string OperatorID, String Location)
        {
            ViewBag.Operator = OperatorID;
            ViewBag.Location = Location;
            return View();
        }

     
    }
}