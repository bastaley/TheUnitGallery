using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheUnitGallery.ViewModels
{
    public class UploadImageViewModel
    {
        public int ArtworkId { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public String Path { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }
    }
}