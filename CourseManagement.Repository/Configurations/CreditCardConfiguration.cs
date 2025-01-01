using CourseManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseManagement.Repository.Configurations
{
    internal class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CVV)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(x => x.CardNumber)
                .IsRequired()
                .HasMaxLength(16);

            builder.Property(x => x.ExpiryDate)
                .IsRequired()
                .HasMaxLength(5);
        }

    }
}
