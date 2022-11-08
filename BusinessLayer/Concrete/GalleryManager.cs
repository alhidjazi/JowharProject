using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GalleryManager:IGalleryService
    {
        IGalleryDal _galleryDal;

        public GalleryManager(IGalleryDal galleryDal)
        {
            _galleryDal = galleryDal;
        }

        public void GalleryAdd(Gallery gallery)
        {
            _galleryDal.Insert(gallery);
        }

        public void GalleryDelete(Gallery gallery)
        {
            _galleryDal.Delete(gallery);
        }

        public void GalleryUpdate(Gallery gallery)
        {
            _galleryDal.Update(gallery);
        }

        public Gallery GetByID(int id)
        {
            return _galleryDal.Get(x => x.ImageID == id);
        }

        public List<Gallery> GetList()
        {
            return _galleryDal.List();
        }
    }
}
