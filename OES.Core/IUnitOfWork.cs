using OES.Core.Interfaces;
using OES.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IDept dept { get; }
        IBase<Department> Department { get; }
        int complet();
    }
}
