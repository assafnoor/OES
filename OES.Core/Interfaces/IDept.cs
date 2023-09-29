using OES.Core.Dto;
using OES.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.Core.Interfaces
{
    public interface IDept:IBase<Department>
    {
        List<Department> GetAllDeptWitheDetails();
        List<Department> GetByIdDeptWitheDetails(int id);
        bool isEnrolled(DeptDto dto, Department department, Course course);
        List<Course> GetAllCorsetWitheDetails();
        Course ByIdCorsetWitheDetails(int id);
    }
}
