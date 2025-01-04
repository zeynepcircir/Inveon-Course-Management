using CourseManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseManagement.Repository.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProfilePictureUrl)
                .HasMaxLength(500);

            builder.HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<Student>(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.EnrolledCourses)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);

            builder.HasMany(x => x.Reviews)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);
        }

    }
}
