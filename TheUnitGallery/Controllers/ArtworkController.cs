using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUnitGallery.Models;

namespace TheUnitGallery.Controllers
{
    public class ArtworkController : Controller
    {
        private ApplicationDbContext _context;

        public ArtworkController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Artwork
        public ActionResult Detail(int id)
        {
            var artwork = _context.Artworks
                .Include(a => a.Genre)
                .Include(a => a.Medium)
                .Include(a => a.Artist)
                .SingleOrDefault(a => a.Id == id);

            if (artwork == null)
                return RedirectToAction("Index", "Home", new { area = "" });

            return Content(artwork.Title);
        }
    }
}