using CourseManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseManagement.Repository.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.ImageUrl)
                .HasMaxLength(500);

            builder.Property(x => x.Level)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(x => x.Language)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.AverageRating)
                .HasDefaultValue(0);

            builder.HasOne(x => x.Instructor)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.InstructorId);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.CategoryId);

            builder.Navigation(c => c.Category).AutoInclude();

            builder.HasMany(x => x.Chapters)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseId);

            builder.HasMany(x => x.Reviews)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseId);

            builder.HasMany(x => x.StudentCourses)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseId);
        }
    }
}