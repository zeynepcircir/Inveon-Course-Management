using Azure;
using CourseManagement.Core.DTOs;
using CourseManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterDTO model)
        {
            var response = await _authenticationService.RegisterAsync(model);
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDTO model)
        {
            var response = await _authenticationService.LoginAsync(model);
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
