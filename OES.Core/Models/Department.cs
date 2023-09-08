using System.ComponentModel.DataAnnotations;

namespace OES.Core.Models
{
    public class Department :BaseModel
    {
        public List<Course_Department> course_departments { get; set; }
        public List<Room> rooms { get; set; }
    }
}
