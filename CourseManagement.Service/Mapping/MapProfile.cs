using AutoMapper;
using CourseManagement.Core.DTOs;
using CourseManagement.Core.Entities;

namespace CourseManagement.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Course, CourseListDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ReverseMap();
            CreateMap<Course, CourseCreateDTO>().ReverseMap();
            CreateMap<Instructor, InstructorDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<CourseChapter, CourseChapterDTO>().ReverseMap();
            CreateMap<StudentChapter, StudentChapterDTO>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.CourseChapter.Id))
                .ForMember(dest => dest.CourseId,
                    opt => opt.MapFrom(src => src.CourseChapter.CourseId))
                .ForMember(dest => dest.Title, 
                    opt => opt.MapFrom(src => src.CourseChapter.Title))
                .ForMember(dest => dest.Duration, 
                    opt => opt.MapFrom(src => src.CourseChapter.Duration))
                .ForMember(dest => dest.OrderIndex, 
                    opt => opt.MapFrom(src => src.CourseChapter.OrderIndex))
                .ForMember(dest => dest.ImageUrl, 
                    opt => opt.MapFrom(src => src.CourseChapter.ImageUrl))
                .ReverseMap();
            CreateMap<StudentChapterDTO, CourseChapter>().ReverseMap();
            CreateMap<Payment, PaymentCreateDTO>().ReverseMap();
            CreateMap<Payment, PaymentDTO>().ReverseMap();
        }
    }
}
