using OES.Core.Interfaces;
using OES.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.EF.Repositories
{
    public class Dept : Base<Department>, IDept
    {
        public Dept(ApplicationDbContext context) : base(context)
        {
        }
    }
}
