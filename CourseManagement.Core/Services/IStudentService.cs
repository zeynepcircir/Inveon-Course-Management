using CourseManagement.Core.DTOs;
using CourseManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsWithCoursesAsync();
        Task<Student> GetStudentByIdWithDetailsAsync(int id);
    }
}
