using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPartnerService
    {
        List<Partner> GetList();
        void PartnerAdd(Partner partner);
        Partner GetByID(int id);
        void PartnerDelete(Partner partner);
        void PartnerUpdate(Partner partner);
    }
}
