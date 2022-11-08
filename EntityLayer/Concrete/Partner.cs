using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Partner
    {
        [Key]
        public int PartnerID { get; set; }
        public string PartnerName { get; set; }
        public string PartnerDescription { get; set; }
        public bool PartnerStatus { get; set; }
        public string PartnerCountry { get; set; }
    }
}
