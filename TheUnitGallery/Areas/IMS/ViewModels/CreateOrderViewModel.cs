using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheUnitGallery.Models;

namespace TheUnitGallery.Areas.IMS.ViewModels
{
    public class CreateOrderViewModel
    {
        public Customer Customer { get; set; }
        public Order Order { get; set; }
    }
}