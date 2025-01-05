namespace CourseManagement.Core.DTOs
{
    public class PaymentCreateDTO
    {
        public string CVV { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
    }
}
