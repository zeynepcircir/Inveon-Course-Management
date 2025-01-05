using CourseManagement.Core.DTOs;
using CourseManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagement.API.Controllers
{
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("makePayment")]
        public async Task<IActionResult> MakePayment([FromBody] PaymentCreateDTO createDTO)
        {
            var response = await _paymentService.MakePayment(createDTO, User.FindFirst("uid")?.Value);
            return StatusCode(response.StatusCode, response);
        }
    }
}
