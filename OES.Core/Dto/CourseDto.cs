﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.Core.Dto
{
    public class CourseDto
    {
        [MaxLength(100)]
        public string name { get; set; }
      
    }
}
