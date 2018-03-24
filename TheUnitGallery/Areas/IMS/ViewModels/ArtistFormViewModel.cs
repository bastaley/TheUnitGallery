using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheUnitGallery.Models;

namespace TheUnitGallery.Areas.IMS.ViewModels
{
    public class ArtistFormViewModel
    {
        public Artist Artist { get; set; }
        public string Title
        {
            get
            {
                if (Artist != null && Artist.Id != 0)
                    return "Update " + Artist.FirstName + " " + Artist.LastName;

                return "Add New Artist";
            }
        }
    }
}