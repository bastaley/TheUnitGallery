using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUnitGallery.Models;

namespace TheUnitGallery.Areas.IMS.Controllers
{
    [Authorize(Roles = "Staff,Admin")]
    public class DashboardController : Controller
    {
        private ApplicationDbContext _context;

        public DashboardController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: IMS/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}