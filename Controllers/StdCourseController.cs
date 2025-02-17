using LearningManagmentSystem.Core.Data;
using LearningManagmentSystem.Core.Service;
using LearningManagmentSystem.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StdCourseController : ControllerBase
    {
        private readonly IStdCourseService _stdCourseService;

        public StdCourseController(IStdCourseService stdCourseService)
        {
            _stdCourseService = stdCourseService;
        }

        [HttpGet]
        public IActionResult GetAllStdCourse()
        {
            var stdCourse = _stdCourseService.GetAllStdCourse();
            return Ok(stdCourse);
        }

        [HttpPost]
        public IActionResult CreateNewStdCourse(Stdcourse stdCourse)
        {
            _stdCourseService.CreateNewStdCourse(stdCourse);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateStdCourse(Stdcourse stdCourse)
        {
            _stdCourseService.UpdateStdCourse(stdCourse);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteStdCourse(int id)
        {
            _stdCourseService.DeleteStdCourse(id);
            return NoContent();
        }

        [Route("GetStdCourseById")]
        [HttpGet]
        public IActionResult GetStdCourseById(int id)
        {
            var stdCourse = _stdCourseService.GetStdCourseById(id);
            return Ok(stdCourse);
        }

    }
}
