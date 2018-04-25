using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUnitGallery.Models;
using TheUnitGallery.ViewModels;
using System.Data.Entity;

namespace TheUnitGallery.Controllers
{
    public class GenresController : Controller
    {
        private ApplicationDbContext _context;

        public GenresController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Genres/Lacdscape
        public ActionResult Index(string genreName)
        {
            if(string.IsNullOrWhiteSpace(genreName))
            {
                return HttpNotFound();
            }

            var artworks = _context.Artworks
                .Include(a => a.Artist)
                .Include(a => a.Medium)
                .Include(a => a.Genre)
                .Where(a => a.Genre.Name == genreName)
                .Where(a => a.ArtworkStatus == ArtworkStatus.ForSale)
                .ToList();

            if(artworks != null)
            {
                var viewModel = new CategoryViewModel
                {
                    Title = genreName,
                    Artworks = artworks
                };

                return View(viewModel);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}