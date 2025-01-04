using CourseManagement.Core.DTOs;
using CourseManagement.Core.Entities;

namespace CourseManagement.Core.Services
{
    public interface ICourseService : IService<Course>
    {
        Task<ResponseDTO<CourseListDTO>> AddCourseAsync(CourseCreateDTO createDto);
        Task<ResponseDTO<CourseListDTO>> GetEnrolledCourses();
    }
}
