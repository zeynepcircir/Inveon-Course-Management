using CourseManagement.Core.Entities;
using CourseManagement.Core.Repositories;
using CourseManagement.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Repository.Repositories
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(CourseManagementDbContext context) : base(context)
        {
        }

        public async Task<List<Instructor>> GetInstructorsWithCoursesAsync()
        {
            return await _context.Instructors
                .Include(x => x.Courses)
                .ToListAsync();
        }

        public async Task<Instructor> GetInstructorByIdWithDetailsAsync(int id)
        {
            return await _context.Instructors
                .Include(x => x.Courses)
                .Include(x => x.SocialMedias)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Course>> GetInstructorCoursesAsync(int instructorId)
        {
            return await _context.Courses
                .Where(x => x.InstructorId == instructorId)
                .Include(x => x.Category)
                .ToListAsync();
        }

    }
}
