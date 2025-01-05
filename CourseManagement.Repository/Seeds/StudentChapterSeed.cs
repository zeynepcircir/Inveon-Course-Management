using CourseManagement.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Repository.Seeds
{
    public class StudentChapterSeed : IEntityTypeConfiguration<StudentChapter>
    {
        public void Configure(EntityTypeBuilder<StudentChapter> builder)
        {
            builder.HasData(
                new StudentChapter
                {
                    Id = 1,
                    StudentId = 1,
                    CourseChapterId = 1,
                    CompletionDate = new DateTime(2025, 1, 2),
                    IsCompleted = true,
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new StudentChapter
                {
                    Id = 2,
                    StudentId = 1,
                    CourseChapterId = 2,
                    CompletionDate = new DateTime(2025, 1, 3),
                    IsCompleted = true,
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new StudentChapter
                {
                    Id = 3,
                    StudentId = 1,
                    CourseChapterId = 3,
                    CompletionDate = new DateTime(2025, 1, 5),
                    IsCompleted = true,
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new StudentChapter
                {
                    Id = 4,
                    StudentId = 1,
                    CourseChapterId = 5,
                    CompletionDate = new DateTime(2025, 1, 7),
                    IsCompleted = true,
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new StudentChapter
                {
                    Id = 5,
                    StudentId = 1,
                    CourseChapterId = 7,
                    CompletionDate = new DateTime(2025, 1, 10),
                    IsCompleted = true,
                    CreatedDate = new DateTime(2025, 1, 1)
                }
            );
        }
    }
}
