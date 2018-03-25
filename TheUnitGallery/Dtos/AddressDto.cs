using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheUnitGallery.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string AddressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string County { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        public string Country { get; set; }
    }
}