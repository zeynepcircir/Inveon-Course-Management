using CourseManagement.Core.Entities;
using CourseManagement.Core.Repositories;
using CourseManagement.Repository.Contexts;

namespace CourseManagement.Repository.Repositories
{
    public class ShoppingCartCourseRepository : GenericRepository<ShoppingCartCourse>, IShoppingCartCourseRepository
    {
        public ShoppingCartCourseRepository(CourseManagementDbContext context) : base(context)
        {
        }
    }
}
