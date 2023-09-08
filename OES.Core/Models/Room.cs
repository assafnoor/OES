using System.ComponentModel.DataAnnotations;

namespace OES.Core.Models
{
    public class Room:BaseModel
    {
        
        public List<Lecturer_Room> lecturers_rooms { get; set; }
        public int DepartmentId { get; set; }
        public Department department { get; set; }
        public List<Student> students { get; set; }
    }
}
