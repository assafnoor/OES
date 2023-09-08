namespace OES.Core.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        public string ques { get; set; }
        public string ans1 { get; set; }
        public string ans2 { get; set; }
        public string ans3 { get; set; }
        public string ans4 { get; set; }
        public string correctAns { get; set; }
        public DateTime Crerate { get; set; }
        public int LecturerId { get; set; }
        public Lecturer lecturer { get; set; }
        public int CourseId { get; set; }
        public Course course { get; set; }
    }
}
