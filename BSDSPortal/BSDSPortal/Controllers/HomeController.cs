using BSDSPortal.Models;
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

        #region AJAX_METHODS
        public JsonResult ValidateOperator(OperatorInfo operatorInfo)
        {
            string Location = "";
            using (UTSContext db = new UTSContext())
            {
                var member = db.Members.SingleOrDefault(m => m.Name == operatorInfo.OperatorID && m.Department.Name == operatorInfo.Department);
                if (member != null)
                {
                    Location = member.Location.Name;
                }
            }
            return Json(Location, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LogisticsUpdate(UnitUpdateInfo unitUpdateInfo)
        {
            List<TransactionDTO> transactions = new List<TransactionDTO>();
            using (UTSContext db = new UTSContext())
            {
                var unit = db.Units.SingleOrDefault(u => u.SerialNo == unitUpdateInfo.SerialNo);
                if (unit == null)
                {
                    unit = new Unit();
                    unit.SerialNo = unitUpdateInfo.SerialNo;
                    Transaction lt = new Transaction();

                    lt.SerialNo = unit.SerialNo;
                    lt.Location = unitUpdateInfo.Location;
                    lt.OperatorID = unitUpdateInfo.Operator;
                    lt.Timestamp = DateTime.Now;
                    lt.Status = TransactionStatus.DISPATCHED;
                    unit.Status = (int)TransactionStatus.DISPATCHED;


                    unit.Transactions.Add(lt);



                    db.Units.Add(unit);
                    db.SaveChanges();

                }

                else
                {
                    if ((TransactionStatus)unit.Status == TransactionStatus.RELEASED)
                    {

                        return Json(transactions, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        updateUnitStatus(unit, unitUpdateInfo);

                        db.SaveChanges();


                    }

                }

                foreach (Transaction l in unit.Transactions)
                {
                    transactions.Add(new TransactionDTO
                    {
                        OperatorID = l.OperatorID,
                        Location = l.Location,
                        Timestamp = DateTime.Parse(l.Timestamp.Value.ToString("yyyy/MM/dd HH:mm:ss")),
                        Status = l.Status.Value.ToString(),
                        SerialNo = unit.SerialNo
                    });
                }
                return Json(transactions, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ProductionUpdate(UnitUpdateInfo unitUpdateInfo)
        {
            List<TransactionDTO> transactions = new List<TransactionDTO>();
            using (UTSContext db = new UTSContext())
            {
                var unit = db.Units.SingleOrDefault(u => u.SerialNo == unitUpdateInfo.SerialNo);
                if (unit == null)
                {
                    return Json(transactions, JsonRequestBehavior.AllowGet); ;
                   
                }

                else
                {
                    if ((TransactionStatus)unit.Status == TransactionStatus.RELEASED)
                    {

                        return Json(transactions, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        updateUnitStatus(unit, unitUpdateInfo);

                        db.SaveChanges();


                    }

                }

                foreach (Transaction l in unit.Transactions)
                {
                    transactions.Add(new TransactionDTO
                    {
                        OperatorID = l.OperatorID,
                        Location = l.Location,
                        Timestamp = DateTime.Parse(l.Timestamp.Value.ToString("yyyy/MM/dd HH:mm:ss")),
                        Status = l.Status.Value.ToString(),
                        SerialNo = unit.SerialNo
                    });
                }
                return Json(transactions, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SearchUnitTransactions(UnitUpdateInfo unitUpdateInfo)
        {
            List<Transaction> transactions = new List<Transaction>();
            using (UTSContext db = new UTSContext())
            {
                var unit = db.Units.SingleOrDefault(u => u.SerialNo == unitUpdateInfo.SerialNo);

                if (unit != null)
                {
                    foreach (Transaction l in unit.Transactions)
                    {
                        transactions.Add(new Transaction
                        {
                            OperatorID = l.OperatorID,
                            Location = l.Location,
                            Timestamp = l.Timestamp,
                            Status = l.Status,
                            SerialNo = l.SerialNo
                        });
                    }
                }
            }
            return Json(transactions, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBayStatus(String label )
        {
            Bay bay = null;
            using (UTSContext db = new UTSContext())
            {
                bay = db.Bays.SingleOrDefault(b => b.Name == label);
            }
            return Json(bay, JsonRequestBehavior.AllowGet);
        }

       

        #endregion






        private void updateUnitStatus(Unit unit, UnitUpdateInfo unitUpdateInfo)
        {
            Transaction t = new Transaction();

            t.Location = unitUpdateInfo.Location;
            t.OperatorID = unitUpdateInfo.Operator;
            t.Timestamp = DateTime.Now;

            if ((TransactionStatus)unit.Status == TransactionStatus.REWORK && (unitUpdateInfo.Department == "Logistics"))
            {

                unit.Status = UNIT_STATUS.DESPATCHED;





                t.Status = TransactionStatus.DISPATCHED;
                unit.Transactions.Add(t);

                return;

            }

            if ((TransactionStatus)unit.Status == TransactionStatus.DISPATCHED && (unitUpdateInfo.Department == "Logistics"))
            {

                unit.Status = UNIT_STATUS.RECEIVED;


                t.Status = TransactionStatus.RECEIVED;
                unit.Transactions.Add(t);
                return;

            }

            if ((TransactionStatus)unit.Status == TransactionStatus.RECEIVED && (unitUpdateInfo.Department == "Production"))
            {

                unit.Status = UNIT_STATUS.RELEASED;


                t.Status = TransactionStatus.RELEASED;
                unit.Transactions.Add(t);

                return;

            }


            if ((unit.Status == UNIT_STATUS.RECEIVED
                || unit.Status == (UNIT_STATUS.TEST_COMPLETE_DELAY)
                || (unit.Status == UNIT_STATUS.TEST_COMPLETE_EARLY)
                || (unit.Status == UNIT_STATUS.TEST_COMPLETE_ONTIME))

                && (unitUpdateInfo.Department == "Production"))
            {

                unit.Status = UNIT_STATUS.FINISHED;


                t.Status = TransactionStatus.FINISHED;
                unit.Transactions.Add(t);

                return;

            }





        }
    }
}
