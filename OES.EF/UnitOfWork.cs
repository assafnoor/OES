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

        public IBase<Student> students { get; private set; }

        public IBase<Lecturer> Lecturers { get; private set; }

        public IBase<Course> Courses  { get; private set; }

        public IBase<Question> Questions { get; private set; }

        public IBase<Course_Department> Course_Department { get; private set; }

        public IRom  rom { get; private set; }

        public IBase<Lecturer_Room> Lecturer_Room { get; private set; }

        public IBase<C_Exam> c_e { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            dept=new Dept(_context);
            Department=new Base<Department>(_context);
            room=new Base<Room>(_context);
            students=new Base<Student>(_context);
            Lecturers = new Base<Lecturer>(_context);
            Courses=new Base<Course>(_context);
            Questions = new Base<Question>(_context);
            Course_Department=new Base<Course_Department>(_context);
            rom = new Rom(_context);
            Lecturer_Room=new Base<Lecturer_Room>(_context);
            c_e=new Base<C_Exam>(_context);
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
