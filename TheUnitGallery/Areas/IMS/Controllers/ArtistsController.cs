using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUnitGallery.Models;
using TheUnitGallery.Areas.IMS.ViewModels;

namespace TheUnitGallery.Areas.IMS.Controllers
{
    [Authorize(Roles = "Staff,Admin")]
    public class ArtistsController : Controller
    {
        private ApplicationDbContext _context;

        public ArtistsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: IMS/Artists
        public ActionResult Index()
        {
            return View();
        }

        // GET: IMS/Artists/New
        public ActionResult New()
        {
            var viewModel = new ArtistFormViewModel
            {
                Artist = new Artist()
            };

            return View("ArtistForm", viewModel);
        }

        // GET: IMS/Artists/Edit
        public ActionResult Edit(int id)
        {
            var artist = _context.Artists.SingleOrDefault(c => c.Id == id);

            if (artist == null)
                return HttpNotFound();

            var viewModel = new ArtistFormViewModel
            {
                Artist = artist
            };

            return View("ArtistForm", viewModel);
        }

        //POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Artist artist)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ArtistFormViewModel
                {
                    Artist = artist
                };

                return View("CustomerForm", viewModel);
            }

            if (artist.Id == 0)
                _context.Artists.Add(artist);
            else
            {
                var artistInDb = _context.Artists.Single(c => c.Id == artist.Id);

                artistInDb.FirstName = artist.FirstName;
                artistInDb.LastName = artist.LastName;
                artistInDb.Alias = artist.Alias;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}