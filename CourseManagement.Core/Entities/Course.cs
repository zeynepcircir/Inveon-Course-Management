using CourseManagement.Core.Enums;

namespace CourseManagement.Core.Entities
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public CourseLevel? Level { get; set; } 
        public string? Language { get; set; }
        public double? AverageRating { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<CourseChapter>? Chapters { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; }
    }
}
