namespace OES.Core.Models
{
    public class Course:BaseModel
    {
        public List<Course_Department> course_departments { get; set; }
        public List<Lecturer> lecturers { get; set; }
        public List<C_Exam> c_Exams { get; set; }
        public List<Question> questions { get; set; }
    }

}
