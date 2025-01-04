using CourseManagement.Core.Entities;
using CourseManagement.Core.Repositories;
using CourseManagement.Repository.Contexts;

namespace CourseManagement.Repository.Repositories
{
    public class StudentCourseRepository : GenericRepository<StudentCourse>, IStudentCourseRepository
    {
        public StudentCourseRepository(CourseManagementDbContext context) : base(context)
        {
        }
    }
}
