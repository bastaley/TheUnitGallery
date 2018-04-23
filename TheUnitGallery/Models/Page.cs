using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheUnitGallery.Models
{
    public class Page
    {
        [Key]
        public string Identifier { get; set; }
        public string Title { get; set; }

        public int ContentId { get; set; }
        public Block Content { get; set; }

        public List<Artwork> FeaturedArtwork { get; set; }
        public Block[] Adverts { get; set; }

        public Page()
        {
            FeaturedArtwork = new List<Artwork>();
            Adverts = new Block[3];
            
        }
    }
}