using Microsoft.EntityFrameworkCore;
using OES.Core.Dto;
using OES.Core.Interfaces;
using OES.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.EF.Repositories
{
    public class Rom : Base<Room>, IRom
    {
        public Rom(ApplicationDbContext context) : base(context)
        {
        }

        public List<Room> GetAllRoomWitheDetails()
        {
          return  _context.Rooms.Include(s=>s.students).Include(d=>d.department).Include(lr=>lr.lecturers_rooms).ThenInclude(l=>l.lecturer).ToList();
        }

       

        public Room GetByIdRoomWitheDetails(int id)
        {
            return _context.Rooms.Where(x => x.Id == id).Include(s => s.students).Include(d => d.department).Include(lr => lr.lecturers_rooms).ThenInclude(l => l.lecturer).SingleOrDefault();
        }
        public bool isEnrolled(Room dto, Lecturer lecturer)
        {

            bool isEnrolled = _context.Lecturers_Rooms
                  .Any(sc => sc.LecturerId == lecturer.Id && sc.room.Id == dto.Id);
            return isEnrolled;
        }
        public List<Lecturer> GetAllLectWitheDetails()
        {
            return _context.Lecturers.Include(s => s.course).Include(d => d.questions).Include(lr => lr.lecturers_rooms).ThenInclude(l => l.room).ToList();
        }



        public Lecturer GetByIdLecturerWitheDetails(int id)
        {
            return _context.Lecturers.Where(l=>l.Id==id).Include(s => s.course).Include(d => d.questions).Include(lr => lr.lecturers_rooms).ThenInclude(l => l.room).FirstOrDefault();
        }

        public List<Question> customQuery(List<string> data)
        {
            return   _context.Questions.Where(item => data.Contains(item.ques)).ToList();
        }
    }
}
