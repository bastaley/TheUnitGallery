using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheUnitGallery.Models;

namespace TheUnitGallery.Areas.IMS.ViewModels
{
    public class AddressFormViewModel
    {
        public Address Address { get; set; }
        public int CustomerId { get; set; }

        public string Title
        {
            get
            {
                if (Address != null && Address.Id != 0)
                    return "Update Address";

                return "Add New Address";
            }
        }
}
}