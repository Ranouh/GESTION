using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GESTION.Dto.Staff;
using GESTION.Services;

namespace GESTION.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly StaffService _staffService;

        public StaffController(StaffService staffService)
        {
            _staffService = staffService;
        }

        // GET: api/Staff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffDto>>> GetAllStaffs()
        {
            var staffs = await _staffService.GetAllStaffsAsync();
            return Ok(staffs);
        }

        // GET: api/Staff/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffDto>> GetStaffById(int id)
        {
            var staff = await _staffService.GetStaffByIdAsync(id);
            if (staff == null)
                return NotFound();

            return Ok(staff);
        }

        // POST: api/Staff
        [HttpPost]
        public async Task<ActionResult<StaffDto>> CreateStaff(CreateStaffRequestDto dto)
        {
            var createdStaff = await _staffService.CreateStaffAsync(dto);
            return CreatedAtAction(nameof(GetStaffById), new { id = createdStaff.IdStaff }, createdStaff);
        }

        // PUT: api/Staff/5
        [HttpPut("{id}")]
        public async Task<ActionResult<StaffDto>> UpdateStaff(int id, UpdateStaffRequestDto dto)
        {
            var updatedStaff = await _staffService.UpdateStaffAsync(id, dto);
            if (updatedStaff == null)
                return NotFound();

            return Ok(updatedStaff);
        }

        // DELETE: api/Staff/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var success = await _staffService.DeleteStaffAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
