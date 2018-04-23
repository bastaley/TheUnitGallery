using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUnitGallery.Areas.IMS.ViewModels;
using TheUnitGallery.Models;

namespace TheUnitGallery.Areas.IMS.Controllers
{
    public class FooterController : Controller
    {
        private ApplicationDbContext _context;

        public FooterController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: IMS/Footer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Footer(string footerIdentifier)
        {
            var blockStrip = _context.Blockstrips
                .Include(b => b.LeftContent)
                .Include(b => b.MiddleContent)
                .Include(b => b.RightContent)
                .SingleOrDefault(b => b.Identifier == footerIdentifier);

            return PartialView(blockStrip);
        }

        public ActionResult Adstrip(string blockStripIdentifier)
        {
            var blockStrip = _context.Blockstrips
                .Include(b => b.LeftContent)
                .Include(b => b.MiddleContent)
                .Include(b => b.RightContent)
                .SingleOrDefault(b => b.Identifier == blockStripIdentifier);

            return PartialView(blockStrip);
        }
    }
}