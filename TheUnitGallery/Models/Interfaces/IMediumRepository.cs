using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUnitGallery.Models.Interfaces
{
    public interface IMediumRepository
    {
        IQueryable<Medium> Mediums { get;  }
        //Page Save(Page page);
        //void Delete(Page page);
    }
}
