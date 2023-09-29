namespace OES.Core.Models
{
    public class Student:BaseModel
    {
        public List<S_Exam> s_exams { get; set; }
        public int RoomId { get; set; }
        public Room room { get; set; }
    }
}
