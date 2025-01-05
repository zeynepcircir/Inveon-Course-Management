using CourseManagement.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Repository.Seeds
{
    public class CourseChapterSeed : IEntityTypeConfiguration<CourseChapter>
    {
        public void Configure(EntityTypeBuilder<CourseChapter> builder)
        {
            builder.HasData(
                new CourseChapter
                {
                    Id = 1,
                    Title = "Introduction to Programming Basics",
                    Duration = 60,
                    OrderIndex = 1,
                    ImageUrl = "chapter1-programming.jpg",
                    CourseId = 1,
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new CourseChapter
                {
                    Id = 2,
                    Title = "Control Structures in Programming",
                    Duration = 90,
                    OrderIndex = 2,
                    ImageUrl = "chapter2-programming.jpg",
                    CourseId = 1,
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new CourseChapter
                {
                    Id = 3,
                    Title = "Functions and Modular Programming",
                    Duration = 75,
                    OrderIndex = 3,
                    ImageUrl = "chapter3-programming.jpg",
                    CourseId = 1,
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new CourseChapter
                {
                    Id = 4,
                    Title = "Object-Oriented Programming Basics",
                    Duration = 120,
                    OrderIndex = 4,
                    ImageUrl = "chapter4-programming.jpg",
                    CourseId = 1,
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new CourseChapter
                {
                    Id = 5,
                    Title = "Introduction to Digital Marketing",
                    Duration = 45,
                    OrderIndex = 1,
                    ImageUrl = "chapter1-marketing.jpg",
                    CourseId = 3,
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new CourseChapter
                {
                    Id = 6,
                    Title = "SEO Strategies",
                    Duration = 60,
                    OrderIndex = 2,
                    ImageUrl = "chapter2-marketing.jpg",
                    CourseId = 3,
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new CourseChapter
                {
                    Id = 7,
                    Title = "Basics of Entrepreneurship",
                    Duration = 50,
                    OrderIndex = 1,
                    ImageUrl = "chapter1-business.jpg",
                    CourseId = 4,
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new CourseChapter
                {
                    Id = 8,
                    Title = "Advanced Business Strategies",
                    Duration = 70,
                    OrderIndex = 2,
                    ImageUrl = "chapter2-business.jpg",
                    CourseId = 4,
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new CourseChapter
                {
                    Id = 9,
                    Title = "Introduction to Scientific Methods",
                    Duration = 65,
                    OrderIndex = 1,
                    ImageUrl = "chapter1-science.jpg",
                    CourseId = 5,
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new CourseChapter
                {
                    Id = 10,
                    Title = "Advanced Research Techniques",
                    Duration = 80,
                    OrderIndex = 2,
                    ImageUrl = "chapter2-science.jpg",
                    CourseId = 5,
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new CourseChapter
                {
                    Id = 11,
                    Title = "Getting Started with Graphic Design",
                    Duration = 75,
                    OrderIndex = 1,
                    ImageUrl = "chapter1-design.jpg",
                    CourseId = 2,
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new CourseChapter
                {
                    Id = 12,
                    Title = "Advanced Graphic Design Techniques",
                    Duration = 90,
                    OrderIndex = 2,
                    ImageUrl = "chapter2-design.jpg",
                    CourseId = 2,
                    CreatedDate = new DateTime(2025, 1, 1)
                }
            );
        }
    }
}
