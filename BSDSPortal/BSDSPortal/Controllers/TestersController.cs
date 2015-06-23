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
    public class TestersController : Controller
    {
        private BSDSContext db = new BSDSContext();

        // GET: Testers
        public async Task<ActionResult> Index()
        {
            var testers = db.Testers.Include(t => t.Sector);
            return View(await testers.ToListAsync());
        }

        // GET: Testers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tester tester = await db.Testers.FindAsync(id);
            if (tester == null)
            {
                return HttpNotFound();
            }
            return View(tester);
        }

        // GET: Testers/Create
        public ActionResult Create()
        {
            ViewBag.SectorID = new SelectList(db.Sectors, "SectorID", "Name");
            return View();
        }

        // POST: Testers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TesterID,Name,SectorID")] Tester tester)
        {
            if (ModelState.IsValid)
            {
                db.Testers.Add(tester);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SectorID = new SelectList(db.Sectors, "SectorID", "Name", tester.SectorID);
            return View(tester);
        }

        // GET: Testers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tester tester = await db.Testers.FindAsync(id);
            if (tester == null)
            {
                return HttpNotFound();
            }
            ViewBag.SectorID = new SelectList(db.Sectors, "SectorID", "Name", tester.SectorID);
            return View(tester);
        }

        // POST: Testers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TesterID,Name,SectorID")] Tester tester)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tester).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SectorID = new SelectList(db.Sectors, "SectorID", "Name", tester.SectorID);
            return View(tester);
        }

        // GET: Testers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tester tester = await db.Testers.FindAsync(id);
            if (tester == null)
            {
                return HttpNotFound();
            }
            return View(tester);
        }

        // POST: Testers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tester tester = await db.Testers.FindAsync(id);
            db.Testers.Remove(tester);
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
