using CourseManagement.Core.Enums;

namespace CourseManagement.Core.DTOs
{
    public class CourseCreateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public CourseLevel Level { get; set; }
        public string Language { get; set; }
        public int CategoryId { get; set; }
    }
}
