using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheUnitGallery.Models;

namespace TheUnitGallery.ViewModels
{
    public class CategoryViewModel
    {
        public string Title { get; set; }
        public List<Artwork> Artworks { get; set; }
    }
}