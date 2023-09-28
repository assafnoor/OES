using OES.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.Core.Dto
{
    public class QuestionDetailsDto
    {
       
        public int Mark { get; set; }
        public string ques { get; set; }
        public string ans1 { get; set; }
        public string ans2 { get; set; }
        public string ans3 { get; set; }
        public string ans4 { get; set; }
        public string correctAns { get; set; }
        public string lecturer { get; set; }
        public string course { get; set; }
    }
}
