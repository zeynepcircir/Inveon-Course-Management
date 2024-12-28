using CourseManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.DTOs
{
    public class PaymentDTO
    {

        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public decimal Amount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public PaymentStatus Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string TransactionId { get; set; }
        public DateTime PaymentDate { get; set; }

 
        public bool IsRefunded { get; set; }
        public DateTime? RefundDate { get; set; }
        public string? RefundReason { get; set; }
        public decimal? RefundAmount { get; set; }

  
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public StudentDTO StudentDetails { get; set; }
        public CourseDTO CourseDetails { get; set; }

        public string? AppliedCouponCode { get; set; }
        public decimal? DiscountAmount { get; set; }
    }
}
