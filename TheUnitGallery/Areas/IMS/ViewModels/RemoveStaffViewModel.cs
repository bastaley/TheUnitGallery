using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheUnitGallery.Models;

namespace TheUnitGallery.Areas.IMS.ViewModels
{
    public class RemoveStaffViewModel
    {
        [Display(Name = "Confirm Staff Members Username")]
        public ApplicationUser StaffMember { get; set; }
        public String Confirmation { get; set; }
    }
}