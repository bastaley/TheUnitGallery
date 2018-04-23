using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheUnitGallery.Models
{
    public class Blockstrips
    {
        public int Id { get; set; }

        public string Identifier { get; set; }

        public int? LeftContentId { get; set; }
        public virtual Block LeftContent { get; set; }

        public int? MiddleContentId { get; set; }
        public virtual Block MiddleContent { get; set; }

        public int? RightContentId { get; set; }
        public virtual Block RightContent { get; set; }
    }
}