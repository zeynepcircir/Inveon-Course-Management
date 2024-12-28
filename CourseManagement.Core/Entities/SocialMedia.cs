using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.Entities
{
    public class SocialMedia : BaseEntity
    {
        public string Platform { get; set; }
        public string Url { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}
