using LearningManagmentSystem.Core.Data;
using LearningManagmentSystem.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagmentSystem.API.Controllers
{
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
        public IActionResult GetAllCategory()
        {
            var category= _categoryService.GetAllCategory();
            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateNewCategory(Category category)
        {
            _categoryService.CreateNewCategory(category);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.UpdateCategory(category);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
            return Ok();
        }

        [Route("GetCategoryById")]
        [HttpGet]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            return Ok(category);
        }
    }
}
