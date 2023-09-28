using Microsoft.EntityFrameworkCore;
using OES.Core.Dto;
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

       

        public List<Department> GetAllDeptWitheDetails()
        {
            return _context.Departments.Include(r=>r.rooms).Include(dc=>dc.course_departments).ThenInclude(c=>c.courses).ToList();
        }
      

        public List<Department> GetByIdDeptWitheDetails(int id)
        {
            return _context.Departments.Where(d=>d.Id==id).Include(r => r.rooms).Include(dc => dc.course_departments).ThenInclude(c => c.courses).ToList();
        }

        public bool isEnrolled(DeptDto dto ,Department department,Course course)
        {          
           
            bool isEnrolled = _context.Courses_Departments
                  .Any(sc => sc.CourseId == course.Id && sc.DepartmentId == department.Id);
            return isEnrolled;
        }
    }
}
