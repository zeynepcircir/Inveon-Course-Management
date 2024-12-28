using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.DTOs
{
    public class InstructorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Biography { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Website { get; set; }
        public List<SocialMediaDTO> SocialMediaLinks { get; set; }
        public int TotalStudents { get; set; }
        public int CourseCount { get; set; }
        public double AverageRating { get; set; }
    }
}
