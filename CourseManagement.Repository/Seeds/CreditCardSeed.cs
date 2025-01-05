using CourseManagement.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Repository.Seeds
{
    public class CreditCardSeed : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasData(
                new CreditCard
                {
                    Id = 1,
                    CVV = "123",
                    CardNumber = "4111111111111111",
                    ExpiryDate = "12/25",
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new CreditCard
                {
                    Id = 2,
                    CVV = "456",
                    CardNumber = "5500000000000004",
                    ExpiryDate = "11/24",
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new CreditCard
                {
                    Id = 3,
                    CVV = "789",
                    CardNumber = "340000000000009",
                    ExpiryDate = "10/26",
                    CreatedDate = new DateTime(2025, 1, 1)
                }
            );
        }
    }
}
