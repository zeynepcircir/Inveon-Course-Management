using CourseManagement.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Repository.Configurations
{
    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsCompleted)
                .IsRequired();

            builder.Property(x => x.CompletionDate)
                .IsRequired(false);

            builder.Property(x => x.LastAccessDate)
                .IsRequired();

            builder.HasOne(x => x.Student)
                .WithMany(x => x.EnrolledCourses)
                .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.Course)
                .WithMany(x => x.StudentCourses)
                .HasForeignKey(x => x.CourseId);
        }
    }
}
