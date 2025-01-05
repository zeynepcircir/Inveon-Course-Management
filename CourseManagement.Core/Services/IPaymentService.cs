using CourseManagement.Core.DTOs;
using CourseManagement.Core.Entities;

namespace CourseManagement.Core.Services
{
    public interface IPaymentService : IService<Payment>
    {
        Task<ResponseDTO<PaymentDTO>> MakePayment(PaymentCreateDTO createDTO, string? userId);
    }
}
