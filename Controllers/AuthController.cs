using LearningManagmentSystem.Core.Data;
using LearningManagmentSystem.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(Login login)
        {
            var re=_authService.Login(login);
            if (re == null) return Unauthorized("Invalid username or pass");
            return Ok(re);
        }

    }
}
