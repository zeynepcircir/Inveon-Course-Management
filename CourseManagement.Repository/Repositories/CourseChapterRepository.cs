using CourseManagement.Core.Entities;
using CourseManagement.Core.Repositories;
using CourseManagement.Repository.Contexts;

namespace CourseManagement.Repository.Repositories
{
    public class CourseChapterRepository : GenericRepository<CourseChapter>, ICourseChapterRepository
    {
        public CourseChapterRepository(CourseManagementDbContext context) : base(context)
        {
        }
    }
}
