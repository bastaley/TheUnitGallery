using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheUnitGallery.Models
{
    public class Block
    {
        public int Id { get; set; }
  
        [MaxLength(50)]
        public string Name { get; set; }

        [AllowHtml]
        public string Content{ get; set; }
    }
}