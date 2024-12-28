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
        Task<List<InstructorDTO>> GetAllAsync();
        Task<InstructorDTO> GetByIdAsync(int id);
        Task<InstructorDTO> CreateAsync(InstructorDTO dto);
        Task<List<PaymentResultDTO>> GetEarningsAsync(int instructorId);
        Task<List<ReviewDTO>> GetReviewsAsync(int instructorId);
    }
}
