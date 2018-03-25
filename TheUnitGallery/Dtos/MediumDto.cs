using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheUnitGallery.Dtos
{
    public class MediumDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool VisibleFrontEnd { get; set; }

        public MediumDto()
        {
            VisibleFrontEnd = false;
        }
    }
}