namespace CourseManagement.Core.Entities
{
    public class Instructor : BaseEntity
    {
        public string? UserId { get; set; }
        public string? Biography { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Website { get; set; }
        public ApplicationUser? User { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}
