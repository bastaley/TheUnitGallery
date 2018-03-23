using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheUnitGallery.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        // GET: 
        [AllowAnonymous]
        public ActionResult _LoginPartial(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView();
        }
    }
}