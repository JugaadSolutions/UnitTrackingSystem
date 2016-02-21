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
    public class ProductModelsController : Controller
    {
        private UTSContext db = new UTSContext();

        // GET: ProductModels
        public async Task<ActionResult> Index()
        {
            var productModels = db.ProductModels.Include(p => p.Family);
            return View(await productModels.ToListAsync());
        }

        // GET: ProductModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModel productModel = await db.ProductModels.FindAsync(id);
            if (productModel == null)
            {
                return HttpNotFound();
            }
            return View(productModel);
        }

        // GET: ProductModels/Create
        public ActionResult Create()
        {
            ViewBag.FamilyID = new SelectList(db.Familys, "FamilyID", "Name");
            return View();
        }

        // POST: ProductModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductModelID,Name,Rating,CycleTime,FamilyID")] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                db.ProductModels.Add(productModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FamilyID = new SelectList(db.Familys, "FamilyID", "Name", productModel.FamilyID);
            return View(productModel);
        }

        // GET: ProductModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModel productModel = await db.ProductModels.FindAsync(id);
            if (productModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FamilyID = new SelectList(db.Familys, "FamilyID", "Name", productModel.FamilyID);
            return View(productModel);
        }

        // POST: ProductModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductModelID,Name,Rating,CycleTime,FamilyID")] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FamilyID = new SelectList(db.Familys, "FamilyID", "Name", productModel.FamilyID);
            return View(productModel);
        }

        // GET: ProductModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModel productModel = await db.ProductModels.FindAsync(id);
            if (productModel == null)
            {
                return HttpNotFound();
            }
            return View(productModel);
        }

        // POST: ProductModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProductModel productModel = await db.ProductModels.FindAsync(id);
            db.ProductModels.Remove(productModel);
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
