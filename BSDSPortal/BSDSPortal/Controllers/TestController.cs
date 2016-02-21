using BSDSPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSDSPortal.Controllers
{
    public class TestController : Controller
    {
        OperatorInfo OperatorInfo;
        BayDTO BayDTO;
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BaySelection(OperatorInfo operatorInfo)
        {
            OperatorInfo = operatorInfo;
            
            return View();
        }

        public ActionResult TestStatusUpdate(BayDTO bayDTO)
        {
            BayDTO = bayDTO;

            
            List<ProductModelDTO> ProductsList = new List<ProductModelDTO>();
            using (UTSContext db = new UTSContext())
            {
                var bay = db.Bays.SingleOrDefault(b => b.Name == BayDTO.Name);
                if (bay == null) return null;
                if (bay.Status == BAY_STATUS.IDLE)
                {
                    var Products = db.ProductModels.ToList();
                    foreach (ProductModel p in Products)
                    {
                        ProductsList.Add(new ProductModelDTO
                        {
                            ProductModelID = p.ProductModelID,
                            Name = p.Name,


                        });
                    }
                    ViewBag.Products = ProductsList;
                    return View("~/Views/Test/BayIdle.cshtml");
                }

                else return View("~/Views/Test/BayBreakDown.cshtml");
            }
        }
    


        public JsonResult StartTest(UnitUpdateInfo unitUpdateInfo)
        {
            bool result = true;
            
            using(UTSContext db = new UTSContext())
            {
                var unit = db.Units.Include("Transactions").SingleOrDefault(u => u.SerialNo == unitUpdateInfo.SerialNo);
                if(unit == null)
                {
                    //show error page
                }

                var transactions = unit.Transactions.ToList();
                if( unit.Status == UNIT_STATUS.RELEASED || unit.Status == UNIT_STATUS.REPAIR )
                {
                    Transaction lt = new Transaction();

                    lt.SerialNo = unit.SerialNo;
                    lt.Location = unitUpdateInfo.Location;
                    lt.OperatorID = unitUpdateInfo.Operator;
                    lt.Timestamp = DateTime.Now;
                    lt.Status = TransactionStatus.TEST_STARTED;
                    //unit.Status = (int)TransactionStatus.TEST_STARTED;


                    unit.Transactions.Add(lt);



                    db.Units.Add(unit);
                    db.SaveChanges();
                }
            }


            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}