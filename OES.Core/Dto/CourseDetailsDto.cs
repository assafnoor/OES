using OES.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.Core.Dto
{
    public class CourseDetailsDto
    {
        public string name { get; set; }
        public List<string> departments { get; set; }
        public List<string> lecturers { get; set; }
     
        public List<string> questions { get; set; }
    }
}
