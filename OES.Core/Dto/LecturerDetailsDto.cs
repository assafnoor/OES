using OES.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.Core.Dto
{
    public class LecturerDetailsDto
    {
        public string name { get; set; }
        public string courseName { get; set; }
        public List<string> questions { get; set; }
        public List<string> rooms { get; set; }
    }
}
