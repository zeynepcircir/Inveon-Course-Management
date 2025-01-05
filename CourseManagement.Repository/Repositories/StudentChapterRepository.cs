using CourseManagement.Core.Entities;
using CourseManagement.Core.Repositories;
using CourseManagement.Repository.Contexts;

namespace CourseManagement.Repository.Repositories
{
    public class StudentChapterRepository : GenericRepository<StudentChapter>, IStudentChapterRepository
    {
        public StudentChapterRepository(CourseManagementDbContext context) : base(context)
        {
        }
    }
}
