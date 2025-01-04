using CourseManagement.Core.DTOs;
using CourseManagement.Core.Entities;

namespace CourseManagement.Core.Services
{
    public interface IInstructorService : IService<Instructor>
    {
        Task<List<PaymentResultDTO>> GetEarningsAsync(int instructorId);
        Task<List<ReviewDTO>> GetReviewsAsync(int instructorId);
    }
}
