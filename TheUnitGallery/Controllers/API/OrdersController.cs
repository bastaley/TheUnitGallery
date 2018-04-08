using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheUnitGallery.Dtos;
using TheUnitGallery.Models;
using System.Data.Entity;

namespace TheUnitGallery.Controllers.API
{
    public class OrdersController : ApiController
    {

        private ApplicationDbContext _context;

        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /api/orders
        public IHttpActionResult GetOrders()
        {
            var orderDtos = _context.Orders
                .Include(c => c.Customer)
                .Include(c => c.OrderItems)
                .ToList()
                .Select(Mapper.Map<Order, OrderDto>);
            return Ok(orderDtos);
        }

        //GET /api/orders/1
        public IHttpActionResult GetCustomerOrders(int Id)
        {
            var orderDtos = _context.Orders
                .Include(c => c.Customer)
                .Include(c => c.OrderItems)
                .Where(c => c.CustomerId == Id)
                .ToList()
                .Select(Mapper.Map<Order, OrderDto>);
            return Ok(orderDtos);
        }

        //GET /api/orders/items/1
        public IHttpActionResult GetOrdersItems(int id)
        {
            var order = _context.Orders
                .Include(c => c.OrderItems)
                .Include("OrderItems.Artist")
                .SingleOrDefault(o => o.Id == id);

            return Ok(order.OrderItems);
        }

        //GET /api/orders/invoice/1
        public IHttpActionResult InvoiceOrder(int id)
        {
            var order = _context.Orders
                .SingleOrDefault(o => o.Id == id);

            order.OrderStatus = OrderStatus.Invoiced;
            _context.SaveChanges();

            return Ok();
        }

        //GET /api/orders/pay/1
        public IHttpActionResult PayOrder(int id)
        {
            var order = _context.Orders
                .SingleOrDefault(o => o.Id == id);

            order.OrderStatus = OrderStatus.Paid;
            _context.SaveChanges();

            return Ok();
        }

        //GET /api/orders/cancel/1
        public IHttpActionResult CancelOrder(int id)
        {
            var order = _context.Orders
                .Include(o => o.OrderItems)
                .SingleOrDefault(o => o.Id == id);

            order.OrderStatus = OrderStatus.Cancelled;

            foreach(var artwork in order.OrderItems)
            {
                artwork.ArtworkStatus = ArtworkStatus.ForSale;
            }
            order.OrderItems.Clear();
            _context.SaveChanges();

            return Ok();
        }

        //POST /api/orders/add/1/1
        [HttpPost]
        public IHttpActionResult AddArtworkToOrder(int orderId, int artworkId)
        {
            var orderInDb = _context.Orders
                .Include(c => c.OrderItems)
                .SingleOrDefault(o => o.Id == orderId);

            var artworkInDb = _context.Artworks
                .Single(a => a.Id == artworkId);

            if(artworkInDb.ArtworkStatus == ArtworkStatus.ForSale)
            {
                orderInDb.OrderItems.Add(artworkInDb);
                artworkInDb.ArtworkStatus = ArtworkStatus.Reserved;
            }

            _context.SaveChanges();
            return Ok(orderInDb);
        }

        //POST /api/orders/remove/1/1
        [HttpPost]
        public IHttpActionResult RemoveArtworkFromOrder(int orderId, int artworkId)
        {
            var orderInDb = _context.Orders
                .Include(c => c.OrderItems)
                .SingleOrDefault(o => o.Id == orderId);

            var artworkInDb = _context.Artworks
                .Single(a => a.Id == artworkId);


            orderInDb.OrderItems.Remove(artworkInDb);
            artworkInDb.ArtworkStatus = ArtworkStatus.ForSale;

            _context.SaveChanges();
            return Ok(orderInDb);
        }
    }
}
