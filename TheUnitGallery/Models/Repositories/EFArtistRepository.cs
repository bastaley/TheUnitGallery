using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheUnitGallery.Models.Interfaces;

namespace TheUnitGallery.Models
{
    public class EFArtistRepository : IArtistRepository
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public IQueryable<Artist> Artists
        { get { return _context.Artists; } }
    }
}