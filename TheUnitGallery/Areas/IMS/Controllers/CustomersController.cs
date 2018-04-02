using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUnitGallery.Models;
using TheUnitGallery.Areas.IMS.ViewModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

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
            var customer = _context.Customers
                .Include(c => c.BillingAddress)
                .Include(c => c.ShippingAddress)
                .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer
            };

            return View("CustomerForm", viewModel);
        }

        // GET: IMS/Customers/Addresses
        public ActionResult Addresses(int id)
        {
            var customer = _context.Customers
                .Include(c => c.BillingAddress)
                .Include(c => c.ShippingAddress)
                .Include(c => c.SavedAddresses)
                .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new AddressSelectionViewModel
            {
                CustomerId = id,
                BillingAddress = customer.BillingAddress,
                ShippingAddress = customer.ShippingAddress,
                SavedAddresses = customer.SavedAddresses
            };

            return View("AddressSelection", viewModel);
        }

        // GET: IMS/Customers/SetBillingAddress
        public ActionResult SetBillingAddress(int customerId, int addressId)
        {
            var customerInDb = _context.Customers.Single(c => c.Id == customerId);

            customerInDb.BillingAddressId = addressId;

            _context.SaveChanges();

            return RedirectToAction("Edit", new { id = customerId });
        }

        // GET: IMS/Customers/SetShippingAddress
        public ActionResult SetShippingAddress(int customerId, int addressId)
        {
            var customerInDb = _context.Customers.Single(c => c.Id == customerId);

            customerInDb.ShippingAddressId = addressId;

            _context.SaveChanges();

            return RedirectToAction("Edit", new { id = customerId });
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

            if (customer.Id == 0)
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

            LogInteraction(customer.Id, "Users Profile Was Updated");

            return RedirectToAction("Index");
        }

        //Log Interaction
        public void LogInteraction(int customerId, string description)
        {
            var interaction = new Interaction
            {
                CustomerId = customerId,
                StaffId = User.Identity.GetUserId(),
                Description = description,
                Date = DateTime.Now
            };

            _context.Interactions.Add(interaction);
            _context.SaveChanges();
        }

    }
}