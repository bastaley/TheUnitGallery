using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheUnitGallery.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number (Landline)")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public Address BillingAddress { get; set; }
        public int? BillingAddressId { get; set; }

        public Address ShippingAddress { get; set; }
        public int? ShippingAddressId { get; set; }

        public virtual List<Address> SavedAddresses { get; set; }
    }
}