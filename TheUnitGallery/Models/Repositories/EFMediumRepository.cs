using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheUnitGallery.Models.Interfaces;

namespace TheUnitGallery.Models
{
    public class EFMediumRepository : IMediumRepository
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public IQueryable<Medium> Mediums
        { get { return _context.Mediums; } }
    }
}