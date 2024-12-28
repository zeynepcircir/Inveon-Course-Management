using CourseManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.Services
{
    public interface ICourseService
    {
        Task<List<CourseDTO>> GetAllAsync();
        Task<CourseDTO> GetByIdAsync(int id);
        Task<CourseDTO> CreateAsync(CourseDTO dto);
        Task<CourseProgressDTO> GetCourseProgressAsync(int courseId, int studentId);
        Task<PaymentResultDTO> ProcessPaymentAsync(CreatePaymentRequestDTO paymentRequest);
        Task<CourseDTO> AddCouponAsync(int courseId, CouponDTO coupon);
    }
}
