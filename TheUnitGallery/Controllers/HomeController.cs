using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUnitGallery.Models;
using TheUnitGallery.ViewModels;

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
                AboutUs = _context.Blocks.Find("AboutUs")
            };

            return View(viewModel);
        }
    }
}