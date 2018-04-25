using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUnitGallery.Models.Interfaces
{
    public interface IPageRepository
    {
        IQueryable<Page> Pages { get;  }
        //Page Save(Page page);
        //void Delete(Page page);
    }
}
