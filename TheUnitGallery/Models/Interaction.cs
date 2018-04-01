using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheUnitGallery.Models
{
    public class Interaction
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public string StaffId { get; set; }
        public ApplicationUser Staff { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public Interaction()
        {
            Date = DateTime.Now;
        }

    }
}