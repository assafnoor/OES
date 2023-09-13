using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OES.Core;
using OES.Core.Interfaces;
using OES.EF.Repositories;
using OES.Core.Models;

namespace OES.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IDept dept { get;private set; }
        public IBase<Department> Department { get;private set; }
        public IBase<Room> room { get;private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            dept=new Dept(_context);
            Department=new Base<Department>(_context);
            room=new Base<Room>(_context);
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
