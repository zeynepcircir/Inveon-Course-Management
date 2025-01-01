using CourseManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.Services
{
    public interface IInstructorService
    {
        Task<List<PaymentResultDTO>> GetEarningsAsync(int instructorId);
        Task<List<ReviewDTO>> GetReviewsAsync(int instructorId);
    }
}
