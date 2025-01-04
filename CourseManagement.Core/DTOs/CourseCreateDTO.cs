using CourseManagement.Core.Entities;
using CourseManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.DTOs
{
    public class CourseCreateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public CourseLevel Level { get; set; }
        public int CategoryId { get; set; }
        public int InstructorId { get; set; }
    }
}
