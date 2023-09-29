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
        IRom rom { get; }
        IBase<Room> room { get; }
        IBase<Department> Department { get; }
        IBase<Student> students { get; }
        IBase<Lecturer> Lecturers { get; }
        IBase<Course> Courses { get; }
        IBase<Question> Questions { get; }
        IBase<Course_Department> Course_Department { get; }
        IBase<Lecturer_Room> Lecturer_Room { get; }
        int complet();
        
    }
}
