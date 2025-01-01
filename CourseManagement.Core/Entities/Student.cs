namespace CourseManagement.Core.Entities
{
    public class Student : BaseEntity
    {
        public int UserId { get; set; }
        public string ProfilePictureUrl { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<StudentCourse>? EnrolledCourses { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
