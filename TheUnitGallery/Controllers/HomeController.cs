using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUnitGallery.Models;
using TheUnitGallery.ViewModels;
using System.Data.Entity;
using TheUnitGallery.Models.Interfaces;

namespace TheUnitGallery.Controllers
{
    public class HomeController : Controller
    {
        private IPageRepository _pageRepo;
        private IGenreRepository _genreRepo;
        private IMediumRepository _mediumRepo;
        private IArtistRepository _artistRepo;

        public HomeController()
        {
            this._pageRepo = new EFPageRepository();
            this._genreRepo = new EFGenreRepository();
            this._mediumRepo = new EFMediumRepository();
            this._artistRepo = new EFArtistRepository();
        }

        public HomeController(IPageRepository pageRepo, IGenreRepository genreRepo, IMediumRepository mediumRepo, IArtistRepository artistRepo)
        {
            this._pageRepo = pageRepo;
            this._genreRepo = genreRepo;
            this._mediumRepo = mediumRepo;
            this._artistRepo = artistRepo;
        }

        public ViewResult Index()
        {
            var viewModel = new HomepageViewModel
            {
                Homepage = _pageRepo.Pages
                .Include(p => p.Content)
                .Single(p => p.Identifier == "homepage"),

                Genres = _genreRepo.Genres
                .Where(g => g.VisibleFrontEnd == true)
                .OrderBy(g => g.Name)
                .ToList(),

                Mediums = _mediumRepo.Mediums
                .Where(g => g.VisibleFrontEnd == true)
                .OrderBy(g => g.Name)
                .ToList(),

                Artists = _artistRepo.Artists
                .OrderBy(g => g.FirstName)
                .ToList()
            };

            return View(viewModel);
        }
    }
}


