using CourseManagement.Core.Entities;
using CourseManagement.Core.Repositories;
using CourseManagement.Repository.Contexts;

namespace CourseManagement.Repository.Repositories
{
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(CourseManagementDbContext context) : base(context)
        {
        }
    }
}
