using CourseManagement.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Repository.Configurations
{
    public class CourseChapterConfiguration : IEntityTypeConfiguration<CourseChapter>
    {
        public void Configure(EntityTypeBuilder<CourseChapter> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Duration)
                .IsRequired();

            builder.Property(x => x.OrderIndex)
                .IsRequired();

            builder.Property(x => x.ImageUrl)
                .HasMaxLength(500);

            builder.HasOne(x => x.Course)
                .WithMany(x => x.Chapters)
                .HasForeignKey(x => x.CourseId);
        }
    }
}
