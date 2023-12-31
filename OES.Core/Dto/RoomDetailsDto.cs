﻿using OES.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.Core.Dto
{
    public class RoomDetailsDto
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Department { get; set; }
        public List<string> students { get; set; }
        public List<string> lecturers { get; set; }
    }
    
}
