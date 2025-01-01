namespace CourseManagement.Core.Entities
{
    public class CreditCard : BaseEntity
    {
        public string CVV { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
    } 
}
