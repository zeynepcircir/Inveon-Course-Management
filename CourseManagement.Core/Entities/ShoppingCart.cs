namespace CourseManagement.Core.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public ICollection<ShoppingCartCourse> ShoppingCartCourses { get; set; }
    }
}
