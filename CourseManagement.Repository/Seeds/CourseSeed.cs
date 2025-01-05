using CourseManagement.Core.Entities;
using CourseManagement.Core.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Repository.Seeds
{
    public class CourseSeed : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(
                new Course
                {
                    Id = 1,
                    Title = "Introduction to Programming",
                    Description = "Learn the basics of programming with this beginner-friendly course.",
                    Price = 49.99m,
                    ImageUrl = "https://images.pexels.com/photos/546819/pexels-photo-546819.jpeg?auto=compress&cs=tinysrgb&w=600",
                    Level = CourseLevel.Beginner,
                    Language = "English",
                    AverageRating = 4.5,
                    InstructorId = 1,
                    CategoryId = 1,
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new Course
                {
                    Id = 2,
                    Title = "Advanced Graphic Design",
                    Description = "Take your design skills to the next level with this advanced course.",
                    Price = 79.99m,
                    ImageUrl = "https://images.pexels.com/photos/6704953/pexels-photo-6704953.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    Level = CourseLevel.Advanced,
                    Language = "English",
                    AverageRating = 4.8,
                    InstructorId = 1,
                    CategoryId = 2,
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new Course
                {
                    Id = 3,
                    Title = "Digital Marketing Mastery",
                    Description = "Master the art of digital marketing with this comprehensive course.",
                    Price = 99.99m,
                    ImageUrl = "https://images.pexels.com/photos/7688336/pexels-photo-7688336.jpeg?auto=compress&cs=tinysrgb&w=600",
                    Level = CourseLevel.Intermediate,
                    Language = "English",
                    AverageRating = 4.7,
                    InstructorId = 1,
                    CategoryId = 3,
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new Course
                {
                    Id = 4,
                    Title = "Entrepreneurship Essentials",
                    Description = "Learn the essentials of starting and managing your own business.",
                    Price = 59.99m,
                    ImageUrl = "https://images.pexels.com/photos/16846873/pexels-photo-16846873/free-photo-of-woman-in-green-suit-sitting-and-working-on-laptop.jpeg?auto=compress&cs=tinysrgb&w=600",
                    Level = CourseLevel.Beginner,
                    Language = "English",
                    AverageRating = 4.6,
                    InstructorId = 1,
                    CategoryId = 4,
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new Course
                {
                    Id = 5,
                    Title = "Scientific Research Techniques",
                    Description = "Explore the world of scientific research with practical techniques.",
                    Price = 69.99m,
                    ImageUrl = "https://images.pexels.com/photos/8443080/pexels-photo-8443080.jpeg?auto=compress&cs=tinysrgb&w=600",
                    Level = CourseLevel.Intermediate,
                    Language = "English",
                    AverageRating = 4.9,
                    InstructorId = 1,
                    CategoryId = 5,
                    CreatedDate = new DateTime(2025, 1, 1)
                }
            );
        }
    }
}
