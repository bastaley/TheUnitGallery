using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheUnitGallery.Areas.IMS.ViewModels;
using TheUnitGallery.Models;

namespace TheUnitGallery.Areas.IMS.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: IMS/Orders
        public ActionResult Index()
        {
            var orders = _context.Orders.Include(o => o.Customer).Include(o => o.OrderItems);

            return View(orders.ToList());
        }

        // GET: IMS/Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .Include("OrderItems.Artist")
                .SingleOrDefault(o => o.Id == id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: IMS/Orders/Create
        public ActionResult Create(int id)
        {
            var customer = _context.Customers
                .Include(c => c.ShippingAddress)
                .Include(c => c.BillingAddress)
                .SingleOrDefault(c => c.Id == id);

            var order = new Order
            {
                CustomerId = id,
                ShippingAddress = customer.ShippingAddress.getAddressHTML(),
                BillingAddress = customer.BillingAddress.getAddressHTML(),
                Date = DateTime.Now,
                OrderStatus = OrderStatus.Open,
            };

            var viewModel = new CreateOrderViewModel
            {
                Customer = customer,
                Order = order,
            };

            return View("NewOrderForm", viewModel);
        }

        // GET: IMS/Orders/Create
        public ActionResult Edit(int id)
        {
            var order = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .Include("OrderItems.Artist")
                .SingleOrDefault(c => c.Id == id);

            var viewModel = new CreateOrderViewModel
            {
                Customer = order.Customer,
                Order = order,
            };

            return View("EditOrderForm", viewModel);
        }

        public ActionResult Save(CreateOrderViewModel viewModel)
        {
            _context.Orders.Add(viewModel.Order);
            _context.SaveChanges();

            if(viewModel.Order.OrderItems.Count == 0)
                return RedirectToAction("Edit", new { id = viewModel.Order.Id });

            return RedirectToAction("Index", "Orders");

        }





        // GET: IMS/Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = _context.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: IMS/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
