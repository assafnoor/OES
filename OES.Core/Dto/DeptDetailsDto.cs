using OES.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.Core.Dto
{
    public class DeptDetailsDto
    {
        public int Id { get; set; }
        public string name { get; set; }  
        public List<string> rooms { get; set; }
        public List<string> courses{ get; set; }
    }
}
