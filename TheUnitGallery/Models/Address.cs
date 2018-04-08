using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheUnitGallery.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string County { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        public string Country { get; set; }

        public string getAddressHTML()
        {
            var address = "<address>";

            if (!string.IsNullOrWhiteSpace(AddressLine1))
                address += AddressLine1 + "<br />";

            if (!string.IsNullOrWhiteSpace(AddressLine2))
                address += AddressLine2 + "<br />";

            if (!string.IsNullOrWhiteSpace(AddressLine3))
                address += AddressLine3 + "<br />";

            if (!string.IsNullOrWhiteSpace(City))
                address += City + "<br />";

            if (!string.IsNullOrWhiteSpace(County))
                address += County + "<br />";

            if (!string.IsNullOrWhiteSpace(PostCode))
                address += PostCode + "<br />";

            if (!string.IsNullOrWhiteSpace(Country))
                address += Country;

            address += "</address>";

            return address;
        }
    }
}