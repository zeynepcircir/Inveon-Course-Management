using CourseManagement.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Repository.Configurations
{
    public class StudentChapterConfiguration : IEntityTypeConfiguration<StudentChapter>
    {
        public void Configure(EntityTypeBuilder<StudentChapter> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.HasOne(sc => sc.Student)
                   .WithMany(s => s.StudentChapters)
                   .HasForeignKey(sc => sc.StudentId);

            builder.HasOne(sc => sc.CourseChapter)
                   .WithMany(cc => cc.StudentChapters)
                   .HasForeignKey(sc => sc.CourseChapterId);

            builder.Property(sc => sc.IsCompleted).IsRequired();
            builder.Property(sc => sc.CompletionDate).IsRequired();
        }
    }

}
