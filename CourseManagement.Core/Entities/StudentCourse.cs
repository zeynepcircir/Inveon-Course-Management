namespace CourseManagement.Core.Entities
{
    public class StudentCourse : BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime LastAccessDate { get; set; }
    }
}
