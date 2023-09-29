using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.Core.Dto
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public List<string> students { get; set; }
        public List<LecturerDto> lecturers { get; set; }
    }
}
