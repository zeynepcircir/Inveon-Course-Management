using CourseManagement.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Repository.Configurations
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.HasOne(sc => sc.Student)
                .WithOne(s => s.ShoppingCart)
                .HasForeignKey<ShoppingCart>(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
