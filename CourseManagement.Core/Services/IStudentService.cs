using CourseManagement.Core.Entities;

namespace CourseManagement.Core.Services
{
    public interface IStudentService : IService<Student>
    {
        Task<List<Student>> GetStudentsWithCoursesAsync();
        Task<Student> GetStudentByIdWithDetailsAsync(int id);
    }
}
