using CourseManagement.Core.Constants;
using CourseManagement.Core.Entities;
using CourseManagement.Core.Repositories;
using CourseManagement.Core.UnitOfWorks;
using Microsoft.AspNetCore.Identity;

namespace CourseManagement.Repository.Seeds
{
    public class ApplicationUserSeed
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IStudentRepository _studentRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationUserSeed(UserManager<ApplicationUser> userManager,
                                   RoleManager<IdentityRole> roleManager,
                                   IStudentRepository studentRepository,
                                   IInstructorRepository instructorRepository, 
                                   IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _studentRepository = studentRepository;
            _instructorRepository = instructorRepository;
            _unitOfWork = unitOfWork;
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

            var existingStudentUser = await _userManager.FindByEmailAsync("student@example.com");
            if (existingStudentUser == null)
            {
                var studentUser = new ApplicationUser
                {
                    UserName = "student_user",
                    Email = "student@example.com",
                    FirstName = "StudentFirstName",
                    LastName = "StudentLastName",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                var result = await _userManager.CreateAsync(studentUser, "Student123!");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(studentUser, AuthConstant.Roles.Student.ToString());

                    var student = new Student
                    {
                        UserId = studentUser.Id,
                        ProfilePictureUrl = "student-profile.jpg",
                        User = studentUser
                    };

                    await _studentRepository.AddAsync(student);
                    await _unitOfWork.CommitAsync();
                }
            }

            var existingInstructorUser = await _userManager.FindByEmailAsync("instructor@example.com");
            if (existingInstructorUser == null)
            {
                var instructorUser = new ApplicationUser
                {
                    UserName = "instructor_user",
                    Email = "instructor@example.com",
                    FirstName = "InstructorFirstName",
                    LastName = "InstructorLastName",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                var result = await _userManager.CreateAsync(instructorUser, "Instructor123!");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(instructorUser, AuthConstant.Roles.Instructor.ToString());

                    var instructor = new Instructor
                    {
                        UserId = instructorUser.Id,
                        Biography = "This is an instructor biography.",
                        ProfilePictureUrl = "instructor-profile.jpg",
                        Website = "https://instructorwebsite.com",
                        User = instructorUser
                    };

                    await _instructorRepository.AddAsync(instructor);
                    await _unitOfWork.CommitAsync();
                }
            }
        }
    }
}
