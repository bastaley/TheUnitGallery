using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheUnitGallery.Models;

namespace TheUnitGallery.ViewModels
{
    public class HomepageViewModel
    {

        public Homepage Homepage { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Medium> Mediums { get; set; }
        public List<Artist> Artists { get; set; }

        public HomepageViewModel()
        {
            Genres = new List<Genre>();
            Mediums = new List<Medium>();
            Artists = new List<Artist>();
        }
    }
}