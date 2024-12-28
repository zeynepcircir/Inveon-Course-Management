using CourseManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.DTOs
{
    public class CreatePaymentRequestDTO
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string? CouponCode { get; set; }
        public string Currency { get; set; }
        public string? PaymentToken { get; set; } 
    }
}

