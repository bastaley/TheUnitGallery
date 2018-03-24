using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheUnitGallery.Models;

namespace TheUnitGallery.Areas.IMS.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer  { get; set; }
        public string Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                    return "Update " + Customer.FirstName + " " + Customer.LastName;

                return "Add New Customer";
            }
        }
    }
}