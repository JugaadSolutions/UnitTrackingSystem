using BSDSPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSDSPortal.Controllers
{
    public class BayStatusController : Controller
    {
        
        // GET: BayStatus
        public ActionResult Index()
        {

            //BayStatusController jsdata = new BayStatusController();
            var bs=new BayStatus();
            bs.id=10;
            bs.name="avi";
            bs.value=3;
            
            return Json(bs, JsonRequestBehavior.AllowGet);
        }
    }
}