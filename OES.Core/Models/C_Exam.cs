namespace OES.Core.Models
{
    public enum Type { R,S }
    public class C_Exam :BaseModel
    {
        public int no_Question { get; set; }
        public Type? type { get; set; }
        public int  Time { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string Token { get; set; }
        public int CourseId { get; set; }
        public Course course { get; set; }
        public int LecturerId { get; set; }
        public Lecturer lecturer { get; set; }
        public List<S_Exam> s_exams { get; set; }
    }
}
