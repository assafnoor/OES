using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OES.Core;
using OES.Core.Interfaces;
using OES.EF.Repositories;

namespace OES.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IDept dept { get;private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            dept=new Dept(_context);
        }
        public int complet()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
