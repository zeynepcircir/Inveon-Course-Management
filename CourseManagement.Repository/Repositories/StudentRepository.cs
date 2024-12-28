using CourseManagement.Core.Entities;
using CourseManagement.Core.Repositories;
using CourseManagement.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Repository.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly CourseManagementDbContext _context;

        public StudentRepository(CourseManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students
                .Include(x => x.EnrolledCourses)
                    .ThenInclude(x => x.Course)
                .ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students
                .Include(x => x.EnrolledCourses)
                    .ThenInclude(x => x.Course)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Student>> GetStudentsWithCoursesAsync()
        {
            return await _context.Students
                .Include(x => x.EnrolledCourses)
                    .ThenInclude(x => x.Course)
                .ToListAsync();
        }

        public async Task<Student> GetStudentByIdWithDetailsAsync(int id)
        {
            return await _context.Students
                .Include(x => x.EnrolledCourses)
                    .ThenInclude(x => x.Course)
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public Task<List<Student>> GetStudentsWithEnrolledCoursesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetEnrolledCoursesAsync(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
