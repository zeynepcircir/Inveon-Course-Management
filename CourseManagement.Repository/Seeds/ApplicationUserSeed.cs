using CourseManagement.Core.Constants;
using CourseManagement.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace CourseManagement.Repository.Seeds
{
    public class ApplicationUserSeed
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public ApplicationUserSeed(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            if (!await _roleManager.RoleExistsAsync(AuthConstant.Roles.Student.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(AuthConstant.Roles.Student.ToString()));
            }

            if (!await _roleManager.RoleExistsAsync(AuthConstant.Roles.Instructor.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(AuthConstant.Roles.Instructor.ToString()));
            }

            var existingUser = await _userManager.FindByEmailAsync(AuthConstant.default_email);
            if (existingUser == null)
            {
                var defaultUser = new ApplicationUser
                {
                    UserName = AuthConstant.default_username,
                    Email = AuthConstant.default_email,
                    FirstName = AuthConstant.default_first_name,
                    LastName = AuthConstant.default_last_name,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                };

                var result = await _userManager.CreateAsync(defaultUser, AuthConstant.default_password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(defaultUser, AuthConstant.default_role.ToString());
                }
            }
        }
    }
}
