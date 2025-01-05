using CourseManagement.Core.DTOs;
using CourseManagement.Core.Entities;

namespace CourseManagement.Core.Services
{
    public interface ICourseService : IService<Course>
    {
        Task<ResponseDTO<CourseListDTO>> AddCourseAsync(CourseCreateDTO createDto, string? userId);
        Task<ResponseDTO<CourseListDTO>> DeleteCourseAsync(int courseId, string? userId);
        Task<ResponseDTO<CourseListDTO>> UpdateCourseAsync(int courseId, CourseCreateDTO dto, string? userId);
        Task<ResponseDTO<CourseChapterDTO>> AddChapterToCourseAsync(int courseId, CourseChapterCreateDTO createDto, string? userId);
        Task<ResponseDTO<List<CourseListDTO>>> GetEnrolledCourses(string? userId);
        Task<ResponseDTO<List<CourseListDTO>>> GetInstructorCourses(string? userId);
        Task<ResponseDTO<List<CourseChapterDTO>>> GetCourseChapters(int courseId);
        Task<ResponseDTO<List<StudentChapterDTO>>> GetStudentCourseChapters(int courseId, string? userId);
    }
}
