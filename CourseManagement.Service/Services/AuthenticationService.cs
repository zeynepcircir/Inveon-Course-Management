using CourseManagement.Core.Constants;
using CourseManagement.Core.DTOs;
using CourseManagement.Core.Entities;
using CourseManagement.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CourseManagement.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JWTOptionsDTO _jwt;

        public AuthenticationService(UserManager<ApplicationUser> userManager,
                                    IOptions<JWTOptionsDTO> jwt)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
        }

        public async Task<RegisterResponseDTO> RegisterAsync(RegisterDTO model)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,

            };

            ApplicationUser? existingEmail = await _userManager.FindByEmailAsync(model.Email);
            ApplicationUser? existingUsername = await _userManager.FindByNameAsync(model.UserName);
            if (existingEmail == null && existingUsername == null)
            {
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, AuthConstant.Roles.Student.ToString());
                    return new RegisterResponseDTO($"User Registered {user.UserName}", null);
                }
                else
                {
                    List<string> errors = new List<string>();
                    foreach (IdentityError error in result.Errors)
                    {
                        errors.Add(error.Description);
                    }
                    return new RegisterResponseDTO("An error occured.", errors);
                }
                
            }
            else
            {
                return new RegisterResponseDTO($"User {user.UserName} is already registered.", null);
            }
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginDTO model)
        {
            LoginResponseDTO authenticationModel;
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new LoginResponseDTO {
                    IsAuthenticated = false, Message = $"No Accounts Registered with {model.Email}." 
                };
            }

            if (await _userManager.CheckPasswordAsync(user, model.Password))
            {
                JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user);

                authenticationModel = new LoginResponseDTO
                {
                    IsAuthenticated = true,
                    Message = jwtSecurityToken.ToString(),
                    UserName = user.UserName,
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    Email = user.Email,
                };
                IList<string> rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                authenticationModel.Roles = rolesList.ToList();
                return authenticationModel;
            }
            else
            {
                authenticationModel = new LoginResponseDTO()
                {
                    IsAuthenticated = false,
                    Message = $"Incorrect Credentials for user {user.Email}."
                };
            }
            return authenticationModel;
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            IList<Claim> userClaims = await _userManager.GetClaimsAsync(user);
            IList<string> roles = await _userManager.GetRolesAsync(user);
            List<Claim> roleClaims = new List<Claim>();
            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }
            IEnumerable<Claim> claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            SigningCredentials signingCredentials = new SigningCredentials(
                symmetricSecurityKey, SecurityAlgorithms.HmacSha256
            );
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials
            );
            return jwtSecurityToken;
        }

    }
}
