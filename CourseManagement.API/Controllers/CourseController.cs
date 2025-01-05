using Azure;
using CourseManagement.Core.Constants;
using CourseManagement.Core.DTOs;
using CourseManagement.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            ResponseDTO<CourseListDTO> response = await _courseService.GetByIdAsync<CourseListDTO>(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("enrolledCourses")]
        public async Task<IActionResult> GetEnrolledCoursesAsync()
        {
            ResponseDTO<List<CourseListDTO>> response = 
                await _courseService.GetEnrolledCourses(User.FindFirst("uid")?.Value);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("instructorCourses")]
        public async Task<IActionResult> GetGivenCoursesAsync()
        {
            ResponseDTO<List<CourseListDTO>> response =
                await _courseService.GetInstructorCourses(User.FindFirst("uid")?.Value);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] CourseCreateDTO createDto)
        {
            var response = await _courseService.AddCourseAsync(createDto, User.FindFirst("uid")?.Value);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{courseId}/chapters")]
        public async Task<IActionResult> GetCourseChapters(int courseId)
        {
            var response = await _courseService.GetCourseChapters(courseId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{courseId}/studentChapters")]
        public async Task<IActionResult> GetStudentCourseChapters(int courseId)
        {
            var response = await _courseService.GetStudentCourseChapters(courseId, User.FindFirst("uid")?.Value);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("{courseId}/chapters")]
        public async Task<IActionResult> AddChapterToCourse(int courseId, [FromBody] CourseChapterCreateDTO createDto)
        {
            var response = await _courseService.AddChapterToCourseAsync(courseId, createDto, User.FindFirst("uid")?.Value);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseCreateDTO dto)
        {
            var response = await _courseService.UpdateCourseAsync(id, dto, User.FindFirst("uid")?.Value);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var response = await _courseService.DeleteCourseAsync(id, User.FindFirst("uid")?.Value);
            return StatusCode(response.StatusCode, response);
        }
    }
}
