using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Web.Hosting;

namespace TheUnitGallery
{
    public class ImageHelper
    {
        public string SaveImage(HttpPostedFileBase image)
        {
            if (image != null)
            {
                var folder = HostingEnvironment.MapPath("~/Uploads/Artwork/");
                var fileName = image.FileName;
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var savePath = folder + fileName;
                var displayUrl = "/Uploads/Artwork/" + fileName;

                image.SaveAs(folder + Path.GetFileName(fileName));

                return displayUrl;
            }

            return "Failed";
        }
    }
}