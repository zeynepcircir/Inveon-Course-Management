using CourseManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseManagement.Repository.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Biography)
                .HasMaxLength(2000);

            builder.Property(x => x.ProfilePictureUrl)
                .HasMaxLength(500);

            builder.Property(x => x.Website)
                .HasMaxLength(500);

            builder.HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<Instructor>(x => x.UserId);

            builder.HasMany(x => x.Courses)
                .WithOne(x => x.Instructor)
                .HasForeignKey(x => x.InstructorId);
        }
    }
}
