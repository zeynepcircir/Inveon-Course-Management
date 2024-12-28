using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.DTOs
{
    public class CourseProgressDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime LastAccessDate { get; set; }
        public double CompletionPercentage { get; set; }

        public List<LectureWithProgressDTO> LectureProgress { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletionDate { get; set; }
        public TimeSpan TotalWatchTime { get; set; }
    }
}
