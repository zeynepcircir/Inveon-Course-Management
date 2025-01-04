using CourseManagement.Core.Entities;

namespace CourseManagement.Core.DTOs
{
    public class CourseListDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? CompletionPercentage { get; set; }
        public ICollection<CourseChapter>? Chapters { get; set; }
    }
}
