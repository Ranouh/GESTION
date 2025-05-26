using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GESTION.Dto.ExamStudent;
using GESTION.Services;

namespace GESTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamStudentController : ControllerBase
    {
        private readonly ExamStudentService _examStudentService;

        public ExamStudentController(ExamStudentService examStudentService)
        {
            _examStudentService = examStudentService;
        }

        // GET: api/ExamStudent
        [HttpGet]
        public async Task<IActionResult> GetExamStudents()
        {
            var examStudents = await _examStudentService.GetAllExamStudentsAsync();
            return Ok(examStudents);
        }

        // GET: api/ExamStudent/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamStudent([FromRoute] int id)
        {
            var examStudent = await _examStudentService.GetExamStudentByIdAsync(id);
            if (examStudent == null)
                return NotFound();

            return Ok(examStudent);
        }

        // POST: api/ExamStudent
        [HttpPost]
        public async Task<IActionResult> CreateExamStudent([FromBody] CreateExamStudentRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdExamStudent = await _examStudentService.CreateExamStudentAsync(dto);
            return CreatedAtAction(nameof(GetExamStudent), new { id = createdExamStudent.IdExamStudent }, createdExamStudent);
        }

        // PUT: api/ExamStudent/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExamStudent([FromRoute] int id, [FromBody] UpdateExamStudentRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedExamStudent = await _examStudentService.UpdateExamStudentAsync(id, dto);
            if (updatedExamStudent == null)
                return NotFound();

            return Ok(updatedExamStudent);
        }

        // DELETE: api/ExamStudent/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamStudent([FromRoute] int id)
        {
            var success = await _examStudentService.DeleteExamStudentAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
