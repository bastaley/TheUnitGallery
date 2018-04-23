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
    public class BlockstripsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CMS/Blockstrips
        public ActionResult Index()
        {
            var blockstrips = db.Blockstrips.Include(b => b.LeftContent).Include(b => b.MiddleContent).Include(b => b.RightContent);
            return View(blockstrips.ToList());
        }

        // GET: CMS/Blockstrips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blockstrips blockstrips = db.Blockstrips.Find(id);
            if (blockstrips == null)
            {
                return HttpNotFound();
            }
            return View(blockstrips);
        }

        // GET: CMS/Blockstrips/Create
        public ActionResult Create()
        {
            ViewBag.LeftContentId = new SelectList(db.Blocks, "Id", "Name");
            ViewBag.MiddleContentId = new SelectList(db.Blocks, "Id", "Name");
            ViewBag.RightContentId = new SelectList(db.Blocks, "Id", "Name");
            return View();
        }

        // POST: CMS/Blockstrips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Identifier,LeftContentId,MiddleContentId,RightContentId")] Blockstrips blockstrips)
        {
            if (ModelState.IsValid)
            {
                db.Blockstrips.Add(blockstrips);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LeftContentId = new SelectList(db.Blocks, "Id", "Name", blockstrips.LeftContentId);
            ViewBag.MiddleContentId = new SelectList(db.Blocks, "Id", "Name", blockstrips.MiddleContentId);
            ViewBag.RightContentId = new SelectList(db.Blocks, "Id", "Name", blockstrips.RightContentId);
            return View(blockstrips);
        }

        // GET: CMS/Blockstrips/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blockstrips blockstrips = db.Blockstrips.Find(id);
            if (blockstrips == null)
            {
                return HttpNotFound();
            }
            ViewBag.LeftContentId = new SelectList(db.Blocks, "Id", "Name", blockstrips.LeftContentId);
            ViewBag.MiddleContentId = new SelectList(db.Blocks, "Id", "Name", blockstrips.MiddleContentId);
            ViewBag.RightContentId = new SelectList(db.Blocks, "Id", "Name", blockstrips.RightContentId);
            return View(blockstrips);
        }

        // POST: CMS/Blockstrips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Identifier,LeftContentId,MiddleContentId,RightContentId")] Blockstrips blockstrips)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blockstrips).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LeftContentId = new SelectList(db.Blocks, "Id", "Name", blockstrips.LeftContentId);
            ViewBag.MiddleContentId = new SelectList(db.Blocks, "Id", "Name", blockstrips.MiddleContentId);
            ViewBag.RightContentId = new SelectList(db.Blocks, "Id", "Name", blockstrips.RightContentId);
            return View(blockstrips);
        }

        // GET: CMS/Blockstrips/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blockstrips blockstrips = db.Blockstrips.Find(id);
            if (blockstrips == null)
            {
                return HttpNotFound();
            }
            return View(blockstrips);
        }

        // POST: CMS/Blockstrips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blockstrips blockstrips = db.Blockstrips.Find(id);
            db.Blockstrips.Remove(blockstrips);
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
