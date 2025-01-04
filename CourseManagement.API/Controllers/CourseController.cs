using Azure;
using CourseManagement.Core.DTOs;
using CourseManagement.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            ResponseDTO<List<CourseListDTO>> response = await _courseService.GetAllAsync<CourseListDTO>();
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
