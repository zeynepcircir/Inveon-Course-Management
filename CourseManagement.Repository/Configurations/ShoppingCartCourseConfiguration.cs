using CourseManagement.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Repository.Configurations
{
    public class ShoppingCartCourseConfiguration : IEntityTypeConfiguration<ShoppingCartCourse>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartCourse> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.HasKey(scc => new { scc.ShoppingCartId, scc.CourseId });

            builder.HasOne(scc => scc.ShoppingCart)
                .WithMany(sc => sc.ShoppingCartCourses)
                .HasForeignKey(scc => scc.ShoppingCartId);

            builder.HasOne(scc => scc.Course)
                .WithMany()
                .HasForeignKey(scc => scc.CourseId);
        }
    }
}
