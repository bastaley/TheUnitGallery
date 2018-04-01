using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheUnitGallery.Models;

namespace TheUnitGallery.Dtos
{
    public class ArtworkDto
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
        public string Year { get; set; }


        public double CostPrice { get; set; }
        public double SalesPrice { get; set; }

        [Required]
        public ArtworkStatus ArtworkStatus { get; set; }
    }
}