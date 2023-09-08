namespace OES.Core.Models
{
    public class Lecturer_Room
    {
        public int LecturerId { get; set; }
        public Lecturer lecturer { get; set; }
        public int RoomId { get; set; }
        public Room room { get; set; }
    }
}
