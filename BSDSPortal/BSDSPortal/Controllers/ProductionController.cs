﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSDSPortal.Controllers
{
    public class ProductionController : Controller
    {
        // GET: Production
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