using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.DTOs
{
    public class LectureWithProgressDTO
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public int Duration { get; set; } 
        public bool IsFree { get; set; }
        public List<ResourceDTO> Resources { get; set; }


        public bool IsCompleted { get; set; }
        public DateTime? CompletionDate { get; set; }
        public double WatchedPercentage { get; set; }
        public TimeSpan WatchTime { get; set; }
        public DateTime? LastWatchDate { get; set; }
    }
}
