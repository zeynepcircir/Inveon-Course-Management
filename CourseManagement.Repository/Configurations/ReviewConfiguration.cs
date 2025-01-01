using CourseManagement.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Repository.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Comment)
                .HasMaxLength(1000);

            builder.Property(x => x.Rating)
                .IsRequired();

            builder.HasOne(x => x.Course)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.CourseId);

            builder.HasOne(x => x.Student)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.StudentId);
        }
    }
}
