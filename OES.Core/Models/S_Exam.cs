namespace OES.Core.Models
{
    public enum Status {Y,N }
    public class S_Exam
    {
        public int Id { get; set; }
        public string ListQuestion { get; set; }
        public string ListAnswer { get; set; }
        public int totalIsCorrect { get; set; }
        public int mark { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Status status { get; set; }
        public int C_ExamId { get; set; }
        public C_Exam c_exam { get; set; }
        public int StudentId { get; set; }
        public Student student { get; set; }
    }
}
