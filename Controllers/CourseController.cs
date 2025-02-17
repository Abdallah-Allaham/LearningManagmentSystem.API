using LearningManagmentSystem.Core.Data;
using LearningManagmentSystem.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        //injrct Service
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        //1
        [HttpGet]//by default
        public IActionResult GetAllCourses()
        {
            var courses = _courseService.GetAllCourses();
            return Ok(courses);//return status  code like 200 or 404
        }

        //2
        [HttpPost]
        public IActionResult CreateNewCourse(Course course)
        {
            _courseService.CreateNewCourse(course);
            return Ok();
        }

        //3
        [HttpPut]
        public IActionResult UpdateCourse(Course course)
        {
            _courseService.UpdateCourse(course);
            return NoContent();//retrurn 404 which means successfully but no contant to return it
        }

        //4
        [HttpDelete]
        public IActionResult DeleteCourse(int id)
        {
            _courseService.DeleteCourse(id);
            return Ok();
        }

        // you can use put get or delete just one time
        // if you need to put more you must give name  Route 

        //5
        [Route("GetCourseById")]
        [HttpGet]
        public IActionResult GetCourseById(int id)
        {
            var course=_courseService.GetCourseById(id);
            return Ok(course);
        }

        [Route("upload-image")]
        [HttpPost]
        public string UploadImage()
        {
            var image = Request.Form.Files[0];//to access to the file or image that was uploaded by user throw form (HttpPost)
            // Request : represent the request of the client and contain all the info from user
            //Form : user use Form
            // Files : represent the files that the user was uploaded 

            // generate a unique file name
            var imageName=Guid.NewGuid().ToString() + "_" + image.FileName;
            var fullPath = Path.Combine("Images", imageName);

            using(var stream=new FileStream(fullPath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return imageName;
        }

        //[HttpPost]
        //[Route("another-image")]
        //public string anotherImage()
        //{

        //    var image=Request.Form.Files[0];

        //    string imageName=Guid.NewGuid().ToString() + "_" + image.FileName;
        //    string fullPath = Path.Combine("Images", imageName);

        //    using(var stream = new FileStream(fullPath, FileMode.Create))
        //    {
        //        image.CopyTo(stream);
        //    }

        //    return imageName;
        //}


        // you can use post or get 
        // if you need to use Post you need to pass parameter to body or params
        // if you need to use Get you need to pass parameter in Route in postman like
        // (http://localhost:portNumber/url?name=java)

        [HttpGet]
        [Route("SearchCourseByName")]
        public IActionResult SearchCourseByNameUsingGet(string name)
        {
            var coursesDTO = _courseService.SearchCourseByName(name);
            return Ok(coursesDTO);
        }

        [HttpPost]
        [Route("SearchCourseByName")]
        public IActionResult SearchCourseByNameUsingPost(string name)
        {
            var coursesDTO = _courseService.SearchCourseByName(name);
            return Ok(coursesDTO);
        }

    }
}
