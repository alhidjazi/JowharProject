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
    public class PartnerManager : IPartnerService
    {
        IPartnerDal _partnerDal;

        public PartnerManager(IPartnerDal partnerDal)
        {
            _partnerDal = partnerDal;
        }

        public Partner GetByID(int id)
        {
            return _partnerDal.Get(x => x.PartnerID == id);
        }

        public List<Partner> GetList()
        {
            return _partnerDal.List();
        }

        public void PartnerAdd(Partner partner)
        {
            _partnerDal.Insert(partner);
        }

        public void PartnerDelete(Partner partner)
        {
            _partnerDal.Delete(partner);
        }

        public void PartnerUpdate(Partner partner)
        {
            _partnerDal.Update(partner);
        }
    }
}
