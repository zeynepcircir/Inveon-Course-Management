namespace CourseManagement.Core.Entities
{
    public class CourseChapter : BaseEntity
    {
        public string Title { get; set; }
        public int Duration { get; set; } 
        public int OrderIndex { get; set; }
        public string ImageUrl { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
