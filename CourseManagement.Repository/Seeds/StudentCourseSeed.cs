using CourseManagement.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Repository.Seeds
{
    public class StudentCourseSeed : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasData(
                new StudentCourse
                {
                    Id = 1,
                    StudentId = 1,
                    CourseId = 1,
                    IsCompleted = false,
                    LastAccessDate = new DateTime(2025, 1, 2),
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new StudentCourse
                {
                    Id = 2,
                    StudentId = 1,
                    CourseId = 2,
                    IsCompleted = true,
                    CompletionDate = new DateTime(2025, 1, 10),
                    LastAccessDate = new DateTime(2025, 1, 10),
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new StudentCourse
                {
                    Id = 3,
                    StudentId = 1,
                    CourseId = 3,
                    IsCompleted = false,
                    LastAccessDate = new DateTime(2025, 1, 3),
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new StudentCourse
                {
                    Id = 4,
                    StudentId = 1,
                    CourseId = 4,
                    IsCompleted = true,
                    CompletionDate = new DateTime(2025, 1, 15),
                    LastAccessDate = new DateTime(2025, 1, 15),
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new StudentCourse
                {
                    Id = 5,
                    StudentId = 1,
                    CourseId = 5,
                    IsCompleted = true,
                    CompletionDate = new DateTime(2025, 1, 20),
                    LastAccessDate = new DateTime(2025, 1, 20),
                    CreatedDate = new DateTime(2025, 1, 1)
                }
            );
        }
    }
}
