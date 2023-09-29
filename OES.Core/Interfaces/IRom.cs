using OES.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.Core.Interfaces
{
    public interface IRom :IBase<Room>
    {
        List<Room> GetAllRoomWitheDetails();
        Room GetByIdRoomWitheDetails(int id);
        bool isEnrolled(Room dto, Lecturer lecturer);
        List<Lecturer> GetAllLectWitheDetails();
        Lecturer GetByIdLecturerWitheDetails(int id);
    }
}
