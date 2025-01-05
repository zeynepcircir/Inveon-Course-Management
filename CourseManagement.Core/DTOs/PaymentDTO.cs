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
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int CreditCardId { get; set; }
        public DateTime? PaymentTime { get; set; }
    }
}
