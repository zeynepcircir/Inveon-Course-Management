using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string TrailerUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int InstructorId { get; set; }
        public int CategoryId { get; set; }
        public double AverageRating { get; set; }
        public int TotalStudents { get; set; }
        public string Level { get; set; } 
        public string Language { get; set; }
        public List<string> Requirements { get; set; }
        public List<string> WhatYouWillLearn { get; set; }
    }
}
