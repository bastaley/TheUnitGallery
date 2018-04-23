using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheUnitGallery.Models;

namespace TheUnitGallery.Areas.CMS.Controllers
{
    public class BlocksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CMS/Blocks
        public ActionResult Index()
        {
            return View(db.Blocks.ToList());
        }

        // GET: CMS/Blocks/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Block block = db.Blocks.Find(id);
            if (block == null)
            {
                return HttpNotFound();
            }
            return View(block);
        }

        // GET: CMS/Blocks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMS/Blocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Content")] Block block)
        {
            if (ModelState.IsValid)
            {
                db.Blocks.Add(block);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(block);
        }

        // GET: CMS/Blocks/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Block block = db.Blocks.Find(id);
            if (block == null)
            {
                return HttpNotFound();
            }
            return View(block);
        }

        // POST: CMS/Blocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Content")] Block block)
        {
            if (ModelState.IsValid)
            {
                db.Entry(block).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(block);
        }

        // GET: CMS/Blocks/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Block block = db.Blocks.Find(id);
            if (block == null)
            {
                return HttpNotFound();
            }
            return View(block);
        }

        // POST: CMS/Blocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Block block = db.Blocks.Find(id);
            db.Blocks.Remove(block);
            db.SaveChanges();
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
