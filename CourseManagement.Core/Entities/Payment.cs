namespace CourseManagement.Core.Entities
{
    public class Payment : BaseEntity
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int CreditCardId { get; set; }
        public DateTime? PaymentTime { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
