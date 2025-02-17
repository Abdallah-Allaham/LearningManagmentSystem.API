using LearningManagmentSystem.Core.Data;
using LearningManagmentSystem.Core.Service;
using LearningManagmentSystem.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;  
        }
        [HttpGet]
        public IActionResult GEtAllLogin()
        {
            var login = _loginService.GetAllLogin();
            return Ok(login);
        }

        [HttpPost]
        public IActionResult CreateNewLogin(Login login)
        {
            _loginService.CreateNewLogin(login);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateLogin(Login login)
        {
            _loginService.UpdateLogin(login);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteLogin(int id)
        {
            _loginService.DeleteLogin(id);
            return NoContent();
        }

        [Route("GetLoginById")]
        [HttpGet]
        public IActionResult GetLoginById(int id)
        {
            var login = _loginService.GetLoginById(id);
            return Ok(login);
        }

    }
}
