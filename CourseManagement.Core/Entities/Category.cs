namespace CourseManagement.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}
