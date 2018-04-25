using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheUnitGallery.Models.Interfaces;

namespace TheUnitGallery.Models
{
    public class EFPageRepository : IPageRepository
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public IQueryable<Page> Pages
        { get { return _context.Pages; } }
    }
}