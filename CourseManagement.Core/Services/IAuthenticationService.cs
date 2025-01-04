using CourseManagement.Core.DTOs;

namespace CourseManagement.Core.Services
{
    public interface IAuthenticationService
    {
        Task<ResponseDTO<RegisterResponseDTO>> RegisterAsync(RegisterDTO model);
        Task<ResponseDTO<LoginResponseDTO>> LoginAsync(LoginDTO model);
    }
}
