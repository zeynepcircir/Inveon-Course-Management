using CourseManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.DTOs
{
    public class PaymentResultDTO
    {
        public bool Success { get; set; }
        public string TransactionId { get; set; }
        public PaymentStatus Status { get; set; }
        public string Message { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal OriginalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public string Currency { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
