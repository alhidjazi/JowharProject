using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        [StringLength(50)]
        public string AboutName { get; set; }
        [StringLength(500)]
        public string Image { get; set; }
        public string Description { get; set; }
        
    }
}
