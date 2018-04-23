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
    public class PagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CMS/Pages
        public ActionResult Index()
        {
            return View(db.Pages.Include(p => p.Content).ToList());
        }

        // GET: CMS/Pages/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: CMS/Pages/Create
        public ActionResult Create()
        {
            ViewBag.ContentId = new SelectList(db.Blocks, "Id", "Name");
            return View();
        }

        // POST: CMS/Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Identifier,Title,ContentId")] Page page)
        {
            if (ModelState.IsValid)
            {
                db.Pages.Add(page);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContentId = new SelectList(db.Blocks, "Id", "Name", page.ContentId);

            return View(page);
        }

        // GET: CMS/Pages/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Include(p => p.Content).SingleOrDefault(p => p.Identifier == id);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContentId = new SelectList(db.Blocks, "Id", "Name", page.ContentId);
            return View(page);
        }

        // POST: CMS/Pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Identifier,Title,ContentId")] Page page)
        {
            if (ModelState.IsValid)
            {
                db.Entry(page).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContentId = new SelectList(db.Blocks, "Id", "Name", page.ContentId);

            return View(page);
        }

        // GET: CMS/Pages/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: CMS/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Page page = db.Pages.Find(id);
            db.Pages.Remove(page);
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
