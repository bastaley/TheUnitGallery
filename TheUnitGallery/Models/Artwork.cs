using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheUnitGallery.Models
{
    public class Artwork
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        [Required]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        [Required]
        public int MediumId { get; set; }
        public Medium Medium { get; set; }

        public string Subject { get; set; }

        [StringLength(4, ErrorMessage = "Year must be 4 digits long"),MinLength(4, ErrorMessage = "Year must be 4 digits long")]
        public string Year { get; set; }


        public double CostPrice { get; set; }
        public double SalesPrice { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public ArtworkStatus ArtworkStatus { get; set; }

        public string IamgeLocation { get; set; }
    }
}