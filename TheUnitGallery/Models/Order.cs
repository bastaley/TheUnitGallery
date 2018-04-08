using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheUnitGallery.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        public List<Artwork> OrderItems { get; set; }

        public double TotalPrice {
            get
            {
                var total = 0.00;
                foreach (var artwork in OrderItems)
                    total += artwork.SalesPrice;

                    return total;
            }
        }

        [AllowHtml]
        public string ShippingAddress { get; set; }

        [AllowHtml]
        public string BillingAddress { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public Order()
        {
            OrderItems = new List<Artwork>();
            OrderStatus = OrderStatus.Open;
        }

        public void payInvoice(double payment)
        {
            if(payment >= TotalPrice)
            {
                OrderStatus = OrderStatus.Paid;
            }
        }
    }
}