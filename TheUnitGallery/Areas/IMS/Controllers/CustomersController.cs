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
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: IMS/Customers
        public ActionResult Index()
        {
            return View();
        }

        // GET: IMS/Customers/New
        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer()
            };

            return View("CustomerForm", viewModel);
        }

        // GET: IMS/Customers/Edit
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer
            };

            return View("CustomerForm", viewModel);
        }

        //POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer
                };

                return View("CustomerForm", viewModel);
            }

            if(customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.FirstName = customer.FirstName;
                customerInDb.LastName  = customer.LastName;
                customerInDb.PhoneNumber = customer.PhoneNumber;
                customerInDb.MobileNumber = customer.MobileNumber;
                customerInDb.Email = customer.Email;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}