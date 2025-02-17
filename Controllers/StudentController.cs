using LearningManagmentSystem.Core.Data;
using LearningManagmentSystem.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAllStudent()
        {
            var student = _studentService.GetAllStudent();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateNewStudent(Student student)
        {
            _studentService.CreateNewStudent(student);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateStudent(Student student)
        {
            _studentService.UpdateStudent(student);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
            return NoContent();
        }

        [Route("GetStudentById")]
        [HttpGet]
        public IActionResult GetStudentById(int id)
        {
            var student= _studentService.GetStudentById(id);
            return Ok(student);
        }
    }
}
