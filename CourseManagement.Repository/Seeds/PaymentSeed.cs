using CourseManagement.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Repository.Seeds
{
    public class PaymentSeed : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasData(
                new Payment
                {
                    Id = 1,
                    CourseId = 1,
                    StudentId = 1,
                    CreditCardId = 1,
                    PaymentTime = new DateTime(2025, 1, 2),
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new Payment
                {
                    Id = 2,
                    CourseId = 2,
                    StudentId = 1,
                    CreditCardId = 2,
                    PaymentTime = new DateTime(2025, 1, 3),
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new Payment
                {
                    Id = 3,
                    CourseId = 3,
                    StudentId = 1,
                    CreditCardId = 3,
                    PaymentTime = new DateTime(2025, 1, 5),
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new Payment
                {
                    Id = 4,
                    CourseId = 4,
                    StudentId = 1,
                    CreditCardId = 1,
                    PaymentTime = new DateTime(2025, 1, 7),
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new Payment
                {
                    Id = 5,
                    CourseId = 5,
                    StudentId = 1,
                    CreditCardId = 2,
                    PaymentTime = new DateTime(2025, 1, 10),
                    CreatedDate = new DateTime(2025, 1, 1)
                }
            );
        }
    }
}
