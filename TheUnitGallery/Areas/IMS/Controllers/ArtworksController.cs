using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUnitGallery.Areas.IMS.ViewModels;
using TheUnitGallery.Models;

namespace TheUnitGallery.Areas.IMS.Controllers
{
    public class ArtworksController : Controller
    {
        private ApplicationDbContext _context { get; set; }
        
        public ArtworksController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: IMS/Artwork
        public ActionResult Index()
        {
            return View();
        }

        // GET: IMS/Artwork/New
        public ActionResult New()
        {
            var viewModel = new ArtworkFormViewModel
            {
                Artwork = new Artwork()
            };

            return View("ArtworkForm", viewModel);
        }

        // GET: IMS/Artwork/Edit/1
        public ActionResult Edit(int id)
        {
            var artworkInDb = _context.Artworks.SingleOrDefault(a => a.Id == id);

            if (artworkInDb == null)
                return HttpNotFound();

            var viewModel = new ArtworkFormViewModel
            {
                Artwork = artworkInDb,
            };

            return View("ArtworkForm", viewModel);
        }

        //GET ims/artworks/save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Artwork artwork)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ArtworkFormViewModel
                {
                    Artwork = artwork
                };

                return View("ArtworkForm", viewModel);
            }

            if (artwork.Id == 0)
                _context.Artworks.Add(artwork);
            else
            {
                var artworkInDb = _context.Artworks.Single(c => c.Id == artwork.Id);

                artworkInDb.Title = artwork.Title;
                artworkInDb.Subject = artwork.Subject;
                artworkInDb.CostPrice = artwork.CostPrice;
                artworkInDb.SalesPrice = artwork.SalesPrice;
                artworkInDb.Year = artwork.Year;
                artworkInDb.ArtworkStatus = artwork.ArtworkStatus;

                artworkInDb.ArtistId = artwork.ArtistId;
                artworkInDb.GenreId = artwork.GenreId;
                artworkInDb.MediumId = artwork.MediumId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}