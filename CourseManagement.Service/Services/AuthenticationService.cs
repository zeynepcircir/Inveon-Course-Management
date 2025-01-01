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

        public async Task<ResponseDTO<RegisterResponseDTO>> RegisterAsync(RegisterDTO model)
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

                    var successData = new RegisterResponseDTO($"User Registered {user.UserName}", null);
                    return ResponseDTO<RegisterResponseDTO>.Success(successData, 201); // 201 Created
                }
                else
                {
                    List<string> errors = result.Errors.Select(e => e.Description).ToList();
                    var errorDto = new ErrorDTO(errors, true);
                    return ResponseDTO<RegisterResponseDTO>.Fail(errorDto, 400); // 400 Bad Request
                }
            }
            else
            {
                string errorMessage = existingEmail != null
                    ? $"Email {model.Email} is already registered."
                    : $"Username {model.UserName} is already registered.";

                var errorDto = new ErrorDTO(errorMessage, true);
                return ResponseDTO<RegisterResponseDTO>.Fail(errorDto, 409); // 409 Conflict
            }
        }

        public async Task<ResponseDTO<LoginResponseDTO>> LoginAsync(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                var errorDto = new ErrorDTO($"No accounts registered with {model.Email}.", true);
                return ResponseDTO<LoginResponseDTO>.Fail(errorDto, 404); // 404 Not Found
            }

            if (await _userManager.CheckPasswordAsync(user, model.Password))
            {
                JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user);

                var authenticationModel = new LoginResponseDTO
                {
                    IsAuthenticated = true,
                    UserName = user.UserName,
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    Email = user.Email,
                    Roles = (await _userManager.GetRolesAsync(user)).ToList()
                };

                return ResponseDTO<LoginResponseDTO>.Success(authenticationModel, 200); // 200 OK
            }
            else
            {
                var errorDto = new ErrorDTO($"Incorrect credentials for user {model.Email}.", true);
                return ResponseDTO<LoginResponseDTO>.Fail(errorDto, 401); // 401 Unauthorized
            }
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
