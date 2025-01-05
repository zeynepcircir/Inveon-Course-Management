namespace CourseManagement.Core.Entities
{
    public class Student : BaseEntity
    {
        public string? UserId { get; set; }
        public int? ShoppingCartId { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public ApplicationUser? User { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
        public ICollection<StudentCourse>? EnrolledCourses { get; set; }
        public ICollection<StudentChapter>? StudentChapters { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
