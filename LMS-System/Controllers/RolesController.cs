using LMS_System.Models;
using LMS_System.Repositories.IRepositories;
using LMS_System.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LMS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RolesController(IRoleRepository roleRepository)
        {

            _roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetAllRole() => await _roleRepository.GetAllRole();

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTO>> GetRoleById(Guid id)
        {
            var role = await _roleRepository.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpGet("name")]
        public async Task<ActionResult<RoleDTO>> GetRoleByName(string name)
        {
            var role = await _roleRepository.GetRoleByName(name);
            return (role == null) ? NotFound() : role;
        }

        [HttpPost]
        public async Task<ActionResult<Role>> AddRole(RoleDTO role)
        {
            var roleName = await _roleRepository.GetRoleByName(role.RoleName);
            if (roleName != null)
            {
                return BadRequest("Role already exists");
            }
            await _roleRepository.AddRole(role);
            return Ok(role);
        }

        [HttpPut("role-name")]
        public async Task<IActionResult> UpdateRole(string oldRole,[FromBody] RoleDTO role)
        {
            var checkRole = await _roleRepository.GetRoleByName(oldRole);
            if (checkRole == null)
            {
                return NotFound("Role not found");
            }
            var checkExists = await _roleRepository.GetRoleByName(role.RoleName);
            if (checkExists != null)
            {
                return BadRequest("Role existed!");
            }
            await _roleRepository.UpdateRole(oldRole, role);
            return Ok($"Update {oldRole} to {role.RoleName} success");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            var deleteRole = await _roleRepository.GetRoleById(id);
            if(deleteRole == null)
            {
                return NotFound("Role not found");
            }
            await _roleRepository.DeleteRole(id);
            return Ok("Role deleted!");
        }
    }
}
