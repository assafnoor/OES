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
              .ForMember(dest => dest.rooms, opt => opt.MapFrom(src => src.rooms.Select(b => b.Name).ToList()))
              .ForMember(dest => dest.courses, opt => opt.MapFrom(src => src.course_departments.Select(cd => cd.courses.Name).ToList()));

        }
    }
}