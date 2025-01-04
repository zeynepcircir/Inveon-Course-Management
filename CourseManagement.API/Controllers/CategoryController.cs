using CourseManagement.Core.DTOs;
using CourseManagement.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            ResponseDTO<List<CategoryDTO>> response = await _categoryService.GetAllAsync<CategoryDTO>();
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}

