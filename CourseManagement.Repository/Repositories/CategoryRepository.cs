using CourseManagement.Core.Entities;
using CourseManagement.Core.Repositories;
using CourseManagement.Repository.Contexts;

namespace CourseManagement.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CourseManagementDbContext context) : base(context)
        {
        }
    }
}
