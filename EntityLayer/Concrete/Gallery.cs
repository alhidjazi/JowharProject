﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Gallery
    {
        [Key]
        public int ImageID { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
    }
}
