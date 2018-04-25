using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheUnitGallery.Models.Interfaces;

namespace TheUnitGallery.Models
{
    public class EFGenreRepository : IGenreRepository
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public IQueryable<Genre> Genres
        { get { return _context.Genres; } }
    }
}