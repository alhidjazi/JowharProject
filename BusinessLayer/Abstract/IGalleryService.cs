using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGalleryService
    {
        List<Gallery> GetList();
        void GalleryAdd(Gallery gallery);
        Gallery GetByID(int id);
        void GalleryDelete(Gallery gallery);
        void GalleryUpdate(Gallery gallery);
    }
}
