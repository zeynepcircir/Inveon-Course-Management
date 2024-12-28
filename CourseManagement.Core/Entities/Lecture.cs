using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.Entities
{
    public class Lecture : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public int Duration { get; set; }
        public bool IsFree { get; set; }
        public int OrderIndex { get; set; }
        public int CourseContentId { get; set; }
        public CourseContent CourseContent { get; set; }
        public ICollection<Resource>? Resources { get; set; }
    }
}
