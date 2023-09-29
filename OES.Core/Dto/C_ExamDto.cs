using OES.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.Core.Dto
{
   
    public class C_ExamDto
    {
        public string name { get; set; }
        public int no_Question { get; set; }
        public int Time { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string Token { get; set; }
        public string course { get; set; }
        public string lecturer { get; set; }
   
    }
}
