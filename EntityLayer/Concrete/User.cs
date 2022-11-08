using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string UserSurName { get; set; }
        [StringLength(2000)]
        public string UserImage { get; set; }
        [StringLength(1000)]
        public string UserAbout { get; set; }
        [StringLength(200)]
        public string UserMail { get; set; }
        [StringLength(50)]
        public string UserPassword { get; set; }

        [StringLength(100)]
        public string UserTitle { get; set; }
        public bool UserStatus { get; set; }
        //public ICollection<Heading> Headings { get; set; }
        //public ICollection<Content> Contents { get; set; }
    }
}
