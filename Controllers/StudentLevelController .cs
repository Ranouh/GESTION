using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GESTION.Dto.StudentLevel;
using GESTION.Services;

namespace GESTION.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentLevelController : ControllerBase
    {
        private readonly StudentLevelService _studentLevelService;

        public StudentLevelController(StudentLevelService studentLevelService)
        {
            _studentLevelService = studentLevelService;
        }

        // GET: api/StudentLevel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentLevelDto>>> GetStudentLevels()
        {
            var studentLevels = await _studentLevelService.GetAllStudentLevelsAsync();
            return Ok(studentLevels);
        }

        // GET: api/StudentLevel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentLevelDto>> GetStudentLevel(int id)
        {
            var studentLevel = await _studentLevelService.GetStudentLevelByIdAsync(id);
            if (studentLevel == null)
                return NotFound();

            return Ok(studentLevel);
        }

        // POST: api/StudentLevel
        [HttpPost]
        public async Task<ActionResult<StudentLevelDto>> CreateStudentLevel(CreateStudentLevelRequestDto dto)
        {
            var createdStudentLevel = await _studentLevelService.CreateStudentLevelAsync(dto);
            return CreatedAtAction(nameof(GetStudentLevel), new { id = createdStudentLevel.IdStudentLevel }, createdStudentLevel);
        }

        // PUT: api/StudentLevel/5
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentLevelDto>> UpdateStudentLevel(int id, UpdateStudentLevelRequestDto dto)
        {
            var updatedStudentLevel = await _studentLevelService.UpdateStudentLevelAsync(id, dto);
            if (updatedStudentLevel == null)
                return NotFound();

            return Ok(updatedStudentLevel);
        }

        // DELETE: api/StudentLevel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentLevel(int id)
        {
            var success = await _studentLevelService.DeleteStudentLevelAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
