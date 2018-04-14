using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheUnitGallery.Models
{
    public class Homepage
    {
        public string Title { get; set; }
        public Block About { get; set; }
        public List<Artwork> FeaturedArtwork { get; set; }
        public Block[] Adverts { get; set; }

        public Homepage()
        {
            FeaturedArtwork = new List<Artwork>();
            Adverts = new Block[3];
            
        }
    }
}