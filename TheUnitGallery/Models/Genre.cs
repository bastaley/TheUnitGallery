using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheUnitGallery.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required] 
        public bool VisibleFrontEnd { get; set; }

        public Genre()
        {
            VisibleFrontEnd = false;
        }
    }
}