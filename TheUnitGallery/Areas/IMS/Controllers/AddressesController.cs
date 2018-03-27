using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUnitGallery.Models;
using TheUnitGallery.Areas.IMS.ViewModels;

namespace TheUnitGallery.Areas.IMS.Controllers
{
    public class AddressesController : Controller
    {
        private ApplicationDbContext _context;

        public AddressesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: IMS/Address/New
        public ActionResult New(int? customerId)
        {
            var viewModel = new AddressFormViewModel
            {
                Address = new Address(),
            };

            if (customerId != null)
                viewModel.CustomerId = (int)customerId;

                return View("AddressForm", viewModel);
        }

        public ActionResult Edit(int customerId, int id)
        {
            var addressInDb = _context.Address.SingleOrDefault(a => a.Id == id);

            var viewModel = new AddressFormViewModel
            {
                CustomerId = customerId,
                Address = addressInDb,
            };

            return View("AddressForm", viewModel);
        }

        public ActionResult Delete(int id, int customerId)
        {
            var addressInDb = _context.Address.SingleOrDefault(a => a.Id == id);
            _context.Address.Remove(addressInDb);

            _context.SaveChanges();
            return RedirectToAction("Addresses", "Customers", new { id = customerId });
        }

        // GET: IMS/Address/Save
        public ActionResult Save(AddressFormViewModel viewModel)
        {
            if (viewModel.Address.Id != 0)
            {
                var addressInDb = _context.Address.Single(a => a.Id == viewModel.Address.Id);

                addressInDb.Name = viewModel.Address.Name;
                addressInDb.AddressLine1 = viewModel.Address.AddressLine1;
                addressInDb.AddressLine2 = viewModel.Address.AddressLine2;
                addressInDb.AddressLine3 = viewModel.Address.AddressLine3;
                addressInDb.City = viewModel.Address.City;
                addressInDb.County = viewModel.Address.County;
                addressInDb.PostCode = viewModel.Address.PostCode;
                addressInDb.Country = viewModel.Address.Country;
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == viewModel.CustomerId);
                customerInDb.SavedAddresses.Add(viewModel.Address);
            }

             _context.SaveChanges();

             return RedirectToAction("Addresses", "Customers", new {id = viewModel.CustomerId });
        }
    }
}