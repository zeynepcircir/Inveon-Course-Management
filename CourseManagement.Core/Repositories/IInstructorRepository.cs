using CourseManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.Repositories
{
    public interface IInstructorRepository : IGenericRepository<Instructor>
    {
        Task<List<Instructor>> GetInstructorsWithCoursesAsync();
        Task<Instructor> GetInstructorByIdWithDetailsAsync(int id);
        Task<List<Course>> GetInstructorCoursesAsync(int instructorId);
    }
}
