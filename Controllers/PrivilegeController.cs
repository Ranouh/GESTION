using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GESTION.Dto.Privilege;
using GESTION.Services;

namespace GESTION.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrivilegeController : ControllerBase
    {
        private readonly PrivilegeService _privilegeService;

        public PrivilegeController(PrivilegeService privilegeService)
        {
            _privilegeService = privilegeService;
        }

        // GET: api/Privilege
        [HttpGet]
        public async Task<IActionResult> GetPrivileges()
        {
            var privileges = await _privilegeService.GetAllPrivilegesAsync();
            return Ok(privileges);
        }

        // GET: api/Privilege/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrivilege(int id)
        {
            var privilege = await _privilegeService.GetPrivilegeByIdAsync(id);
            if (privilege == null)
                return NotFound();

            return Ok(privilege);
        }

        // POST: api/Privilege
        [HttpPost]
        public async Task<IActionResult> CreatePrivilege([FromBody] CreatePrivilegeRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdPrivilege = await _privilegeService.CreatePrivilegeAsync(dto);
            return CreatedAtAction(nameof(GetPrivilege), new { id = createdPrivilege.IdPrivilege }, createdPrivilege);
        }

        // DELETE: api/Privilege/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrivilege(int id)
        {
            var deleted = await _privilegeService.DeletePrivilegeAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
