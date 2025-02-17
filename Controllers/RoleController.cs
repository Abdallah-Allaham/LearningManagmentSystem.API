using LearningManagmentSystem.Core.Data;
using LearningManagmentSystem.Core.Service;
using LearningManagmentSystem.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetAllRole()
        {
            var role = _roleService.GetAllRole();
            return Ok(role);
        }

        [HttpPost]
        public IActionResult CreateNewRole(Role role)
        {
            _roleService.CreateNewRole(role);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateRole(Role role)
        {
            _roleService.UpdateRole(role);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteRole(int id)
        {
            _roleService.DeleteRole(id);
            return NoContent();
        }

        [Route("GetRoleById")]
        [HttpGet]
        public IActionResult GetRoleById(int id)
        {
            var role = _roleService.GetRoleById(id);
            return Ok(role);
        }
    }
}
