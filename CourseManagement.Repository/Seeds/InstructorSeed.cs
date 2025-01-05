using CourseManagement.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Repository.Seeds
{
    public class InstructorSeed : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasData(
                new Instructor
                {
                    Id = 1,
                    Biography = "Experienced instructor in software development.",
                    ProfilePictureUrl = "instructor1-profile.jpg",
                    Website = "https://instructor1.com",
                    CreatedDate = new DateTime(2025, 1, 1)
                }
            );
        }
    }

}
