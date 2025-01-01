using CourseManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Core.Services
{
    public interface IAuthenticationService
    {
        Task<ResponseDTO<RegisterResponseDTO>> RegisterAsync(RegisterDTO model);
        Task<ResponseDTO<LoginResponseDTO>> LoginAsync(LoginDTO model);
    }
}
