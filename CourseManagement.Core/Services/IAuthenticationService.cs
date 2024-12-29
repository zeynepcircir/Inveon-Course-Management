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
        Task<RegisterResponseDTO> RegisterAsync(RegisterDTO model);
        Task<LoginResponseDTO> LoginAsync(LoginDTO model);
    }
}
