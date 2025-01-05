using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.Entities
{
    public class StudentChapter : BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseChapterId { get; set; }
        public CourseChapter CourseChapter { get; set; }
        public DateTime CompletionDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
