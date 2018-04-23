using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheUnitGallery.Models;

namespace TheUnitGallery.Areas.CMS.ViewModels
{
    public class ArtworkFormViewModel
    {
        public Artwork Artwork { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Medium> Mediums { get; set; }
        public IEnumerable<Artist> Artists { get; set; }

        public string Title
        {
            get
            {
                if (Artwork != null && Artwork.Id != 0)
                    return "Update " + Artwork.Title;

                return "Add New Artwork";
            }
        }
    }
}