using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BSDSPortal.Models;

namespace BSDSPortal.Controllers
{
    public class BaysController : Controller
    {
        private BSDSContext db = new BSDSContext();

        // GET: Bays
        public async Task<ActionResult> Index()
        {
            var bays = db.Bays.Include(b => b.Tester);
            return View(await bays.ToListAsync());
        }

        // GET: Bays/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bay bay = await db.Bays.FindAsync(id);
            if (bay == null)
            {
                return HttpNotFound();
            }
            return View(bay);
        }

        // GET: Bays/Create
        public ActionResult Create()
        {
            ViewBag.TesterID = new SelectList(db.Testers, "TesterID", "Name");
            return View();
        }

        // POST: Bays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BayID,Name,TesterID")] Bay bay)
        {
            if (ModelState.IsValid)
            {
                db.Bays.Add(bay);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TesterID = new SelectList(db.Testers, "TesterID", "Name", bay.TesterID);
            return View(bay);
        }

        // GET: Bays/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bay bay = await db.Bays.FindAsync(id);
            if (bay == null)
            {
                return HttpNotFound();
            }
            ViewBag.TesterID = new SelectList(db.Testers, "TesterID", "Name", bay.TesterID);
            return View(bay);
        }

        // POST: Bays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BayID,Name,TesterID")] Bay bay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bay).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TesterID = new SelectList(db.Testers, "TesterID", "Name", bay.TesterID);
            return View(bay);
        }

        // GET: Bays/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bay bay = await db.Bays.FindAsync(id);
            if (bay == null)
            {
                return HttpNotFound();
            }
            return View(bay);
        }

        // POST: Bays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Bay bay = await db.Bays.FindAsync(id);
            db.Bays.Remove(bay);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
