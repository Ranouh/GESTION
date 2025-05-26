using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GESTION.Dto.Exam;
using GESTION.Services;

namespace GESTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly ExamService _examService;

        public ExamController(ExamService examService)
        {
            _examService = examService;
        }

        // GET: api/Exam
        [HttpGet]
        public async Task<IActionResult> GetExams()
        {
            var exams = await _examService.GetAllExamsAsync();
            return Ok(exams);
        }

        // GET: api/Exam/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExam([FromRoute] int id)
        {
            var exam = await _examService.GetExamByIdAsync(id);
            if (exam == null)
                return NotFound();

            return Ok(exam);
        }

        // POST: api/Exam
        [HttpPost]
        public async Task<IActionResult> CreateExam([FromBody] CreateExamRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdExam = await _examService.CreateExamAsync(dto);
            return CreatedAtAction(nameof(GetExam), new { id = createdExam.IdExam }, createdExam);
        }

        // PUT: api/Exam/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExam([FromRoute] int id, [FromBody] UpdateExamRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedExam = await _examService.UpdateExamAsync(id, dto);
            if (updatedExam == null)
                return NotFound();

            return Ok(updatedExam);
        }

        // DELETE: api/Exam/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam([FromRoute] int id)
        {
            var success = await _examService.DeleteExamAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
