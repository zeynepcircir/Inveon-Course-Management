using CourseManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<List<Student>> GetStudentsWithEnrolledCoursesAsync();
        Task<Student> GetStudentByIdWithDetailsAsync(int id);
        Task<List<Course>> GetEnrolledCoursesAsync(int studentId);
        Task<List<Student>> GetAllAsync();
    }
}
