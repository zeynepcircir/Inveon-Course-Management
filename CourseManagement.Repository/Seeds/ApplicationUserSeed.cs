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
            if (!await _roleManager.RoleExistsAsync(AuthorizationConstant.Roles.Student.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(AuthorizationConstant.Roles.Student.ToString()));
            }

            if (!await _roleManager.RoleExistsAsync(AuthorizationConstant.Roles.Instructor.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(AuthorizationConstant.Roles.Instructor.ToString()));
            }

            var existingUser = await _userManager.FindByEmailAsync(AuthorizationConstant.default_email);
            if (existingUser == null)
            {
                var defaultUser = new ApplicationUser
                {
                    UserName = AuthorizationConstant.default_username,
                    Email = AuthorizationConstant.default_email,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                };

                var result = await _userManager.CreateAsync(defaultUser, AuthorizationConstant.default_password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(defaultUser, AuthorizationConstant.default_role.ToString());
                }
            }
        }
    }
}
