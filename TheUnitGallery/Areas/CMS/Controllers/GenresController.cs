using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheUnitGallery.Areas.CMS.Controllers
{
    public class GenresController : Controller
    {
        // GET: CMS/Genres
        public ActionResult Index()
        {
            return View();
        }
    }
}