using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TheUnitGallery.Areas.IMS.ViewModels;
using TheUnitGallery.Models;
using TheUnitGalery.ViewModels;

namespace TheUnitGallery.Areas.IMS.Controllers
{
    public class StaffController : Controller
    {
        private ApplicationDbContext _context;
        private ApplicationUserManager _userManager;


        public StaffController()
        {
            _context = new ApplicationDbContext();
        }

        public StaffController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        // GET: IMS/Staff
        public ActionResult Index()
        {
            var staff = (from user in _context.Users
                         select new
                         {
                             UserId = user.Id,
                             Username = user.UserName,
                             Email = user.Email,
                             RoleNames = (from userRole in user.Roles
                                          join role in _context.Roles on userRole.RoleId
                                          equals role.Id
                                          select role.Name).ToList()
                         }).ToList().Select(p => new UsersInRolesViewModel()

                         {
                             UserId = p.UserId,
                             Username = p.Username,
                             Email = p.Email,
                             Role = string.Join(",", p.RoleNames)
                         });

            staff = staff.Where(u => u.Role == "Staff" || u.Role == "Admin");
            return View(staff.ToList());
        }

        public ActionResult Remove(String id)
        {
            var viewModel = new RemoveStaffViewModel()
            {
                StaffMember = _context.Users.Find(id)
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Remove(RemoveStaffViewModel viewModel, String id)
        {
            var result = RemoveStaff(id, viewModel.Confirmation);

            if (result)
                return RedirectToAction("Index");

            viewModel.StaffMember = _context.Users.Find(id);

            ViewBag.Message = "Sorry the Username you entered did NOT match the staff member you were tyring to delete.";
            return View(viewModel);
        }



        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Staff");
                    return RedirectToAction("Index", "Staff", new { area = "IMS" });
                }
                AddErrors(result);
            }
            return View(model);
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool RemoveStaff(String id, string confirmation)
        {
            var user = _context.Users.Find(id);

            if (user.UserName.ToLower() == confirmation.ToLower())
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}