using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheUnitGallery.Models;

namespace TheUnitGallery.Areas.IMS.ViewModels
{
    public class AddressSelectionViewModel
    {
        public int CustomerId { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public List<Address> SavedAddresses { get; set; }
    }
}