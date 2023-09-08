namespace OES.Core.Models
{
    public class Course_Department
    {
        public int CourseId { get; set; }
        public Course courses { get; set; }
        public int DepartmentId { get; set; }
        public Department departments { get; set; }
    }
}
