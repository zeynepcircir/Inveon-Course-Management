namespace CourseManagement.Core.DTOs
{
    public class StudentChapterDTO
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public int OrderIndex { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CompletionDate { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
