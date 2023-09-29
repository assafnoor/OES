using AutoMapper;
using OES.Core.Dto;
using OES.Core.Models;

namespace OES.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DeptDetailsDto>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.rooms, opt => opt.MapFrom(src => src.rooms.Select(b => b.Name).ToList()))
              .ForMember(dest => dest.courses, opt => opt.MapFrom(src => src.course_departments.Select(cd => cd.courses.Name).ToList()));





            CreateMap<Room, RoomDetailsDto>()
              .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.department.Name))
              .ForMember(dest => dest.students, opt => opt.MapFrom(src => src.students.Select(s => s.Name).ToList()))
             .ForMember(dest => dest.lecturers, opt => opt.MapFrom(src => src.lecturers_rooms.Select(lr=>lr.lecturer.Name).ToList()));


            //CreateMap<Room, Test>()
            //  .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.department.Name))
            //  .ForMember(dest => dest.students, opt => opt.MapFrom(src => src.students.Select(s => s.Name)))
            //  .ForMember(dest => dest.lecturers, opt => opt.MapFrom(src => src.lecturers_rooms.Select(lr => lr.lecturer.Name).ToList()));
            // // .ForMember(dest => dest.lecturers.Select(l=>l.), opt => opt.MapFrom(src => src.lecturers_rooms.Select(lr=>lr.lecturer.Name).ToList()));



            CreateMap<Student, StudentDetailsDto>()
              .ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.room.Name)); 

            CreateMap<Course, CourseDetailsDto>();


            //CreateMap<Lecturer, LecturerDetailsDto>()
            //    .ForMember(dest => dest.courseName, opt => opt.MapFrom(src => src.course.Name));
            CreateMap<Lecturer, LecturerDetailsDto>()
                        .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
                        .ForMember(dest => dest.courseName, opt => opt.MapFrom(src => src.course.Name))
                        .ForMember(dest => dest.rooms, opt => opt.MapFrom(src => src.lecturers_rooms.Select(lr => lr.room.Name).ToList()))
                        .ForMember(dest => dest.questions, opt => opt.MapFrom(src => src.questions.Select(q=>q.ques).ToList()));

            //CreateMap<QuestionDto, Question>()
            //           .ForMember(dest => dest.Mark, opt => opt.MapFrom(src => src.Mark))
            //           .ForMember(dest => dest.ques, opt => opt.MapFrom(src => src.ques))
            //           .ForMember(dest => dest.ans1, opt => opt.MapFrom(src => src.ans1))
            //           .ForMember(dest => dest.ans2, opt => opt.MapFrom(src => src.ans2))
            //           .ForMember(dest => dest.ans3, opt => opt.MapFrom(src => src.ans3))
            //           .ForMember(dest => dest.ans4, opt => opt.MapFrom(src => src.ans4))
            //           .ForMember(dest => dest.Crerate,opt=>opt.MapFrom(_=>DateTime.Now))
            //           .ForMember(dest => dest.Crerate,opt=>opt.MapFrom(_=>DateTime.Now))
            //           .ForMember(dest => dest.correctAns, opt => opt.MapFrom(src => src.correctAns));


            CreateMap<Question, QuestionDetailsDto>()
                        .ForMember(dest => dest.Mark, opt => opt.MapFrom(src => src.Mark))
                        .ForMember(dest => dest.ques, opt => opt.MapFrom(src => src.ques))
                        .ForMember(dest => dest.ans1, opt => opt.MapFrom(src => src.ans1))
                        .ForMember(dest => dest.ans2, opt => opt.MapFrom(src => src.ans2))
                        .ForMember(dest => dest.ans3, opt => opt.MapFrom(src => src.ans3))
                        .ForMember(dest => dest.ans4, opt => opt.MapFrom(src => src.ans4))
                        .ForMember(dest => dest.correctAns, opt => opt.MapFrom(src => src.correctAns))
                        .ForMember(dest => dest.lecturer, opt => opt.MapFrom(src => src.lecturer.Name))
                        .ForMember(dest => dest.course, opt => opt.MapFrom(src => src.course.Name));


        }
    }
}