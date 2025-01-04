using CourseManagement.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Repository.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Programming",
                    Description = "Books and courses about programming languages and development practices.",
                    IconUrl = "programming-icon.png",
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new Category
                {
                    Id = 2,
                    Name = "Design",
                    Description = "Resources on graphic design, UI/UX, and digital art.",
                    IconUrl = "design-icon.png",
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new Category
                {
                    Id = 3,
                    Name = "Marketing",
                    Description = "Courses and books on digital marketing, SEO, and branding strategies.",
                    IconUrl = "marketing-icon.png",
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new Category
                {
                    Id = 4,
                    Name = "Business",
                    Description = "Content related to entrepreneurship, management, and business strategies.",
                    IconUrl = "business-icon.png",
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new Category
                {
                    Id = 5,
                    Name = "Science",
                    Description = "Educational resources about various scientific disciplines and discoveries.",
                    IconUrl = "science-icon.png",
                    CreatedDate = new DateTime(2025, 1, 1)
                }
            );
        }
    }
}
