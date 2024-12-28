namespace CourseManagement.Core.DTOs
{
    public class CouponDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal DiscountAmount { get; set; }
        public bool IsPercentage { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public int? MaxUsageCount { get; set; }
        public int CurrentUsageCount { get; set; }
        public bool IsActive { get; set; }
        public List<int>? ApplicableCourseIds { get; set; }
        public decimal? MinimumPurchaseAmount { get; set; }
    }
}
