using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheUnitGallery.Models
{
    public class Block
    {
        [Key]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Content{ get; set; }
    }
}