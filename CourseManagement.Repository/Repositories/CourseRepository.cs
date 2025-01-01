using CourseManagement.Core.Entities;
using CourseManagement.Core.Repositories;
using CourseManagement.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Repository.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly CourseManagementDbContext _context;

        public CourseRepository(CourseManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetCoursesWithInstructorAsync()
        {
            return await _context.Courses
                .Include(x => x.Instructor)
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<Course> GetCourseByIdWithDetailsAsync(int id)
        {
            return await _context.Courses
                .Include(x => x.Instructor)
                .Include(x => x.Category)
                .Include(x => x.Chapters)
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
