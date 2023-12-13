using AutoMapper;
using CourseManager.Entities;
using CourseManager.Models;
using CourseManager;

namespace CourseManager.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>();
        }
    }
}
