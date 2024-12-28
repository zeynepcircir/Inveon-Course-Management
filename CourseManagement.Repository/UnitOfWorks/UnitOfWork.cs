using CourseManagement.Core.Repositories;
using CourseManagement.Core.UnitOfWorks;
using CourseManagement.Repository.Contexts;
using CourseManagement.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CourseManagementDbContext _context;

        public UnitOfWork(CourseManagementDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
