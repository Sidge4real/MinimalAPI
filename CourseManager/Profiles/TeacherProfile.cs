using AutoMapper;
using CourseManager.Entities;
using CourseManager.Models;
using CourseManager;

namespace CourseManager.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherDto>();
        }
    }
}
