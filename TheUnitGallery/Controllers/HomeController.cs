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
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {

            var viewModel = new HomepageViewModel
            {
                Homepage = _context.Pages
                .Include(p => p.Content)
                .Single(p => p.Identifier == "homepage"),

                Genres = _context.Genres
                .Where(g => g.VisibleFrontEnd == true)
                .OrderBy(g => g.Name)
                .ToList(),

                Mediums = _context.Mediums
                .Where(g => g.VisibleFrontEnd == true)
                .OrderBy(g => g.Name)
                .ToList(),

                Artists = _context.Artists
                .OrderBy(g => g.FirstName)
                .ToList()
            };

            return View(viewModel);
        }
    }
}