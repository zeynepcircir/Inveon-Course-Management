using Microsoft.AspNetCore.Identity;

namespace CourseManagement.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? City { get; set; }
    }
}
