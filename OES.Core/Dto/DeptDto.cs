using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.Core.Dto
{
    public class DeptDto
    {
        [StringLength(100)]
        public string name { get; set; }
        public string RoomName { get; set; }
        public string CourseName { get; set; }
    }
}
