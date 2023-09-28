using OES.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.Core.Dto
{
    public class StudentDto
    {
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string room { get; set; }
    }
}
