using System.ComponentModel.DataAnnotations;

namespace OES.Core.Models
{
    public class Lecturer:BaseModel
    {
       
        public List<Lecturer_Room> lecturers_rooms { get; set; }
        public int CourseId { get; set; }
        public Course course { get; set; }
        public List<C_Exam> c_Exams { get; set; }
        public List<Question> questions { get; set; }

    }
}
