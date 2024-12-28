using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.Entities
{
    public class CourseContent : BaseEntity
    {
        public string Title { get; set; }
        public int Duration { get; set; } 
        public int OrderIndex { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<Lecture>? Lectures { get; set; }
    }
}
