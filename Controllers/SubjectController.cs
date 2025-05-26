using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GESTION.Dto.Subject;
using GESTION.Services;

namespace GESTION.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly SubjectService _subjectService;

        public SubjectController(SubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        // GET: api/Subject
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetSubjects()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            return Ok(subjects);
        }

        // GET: api/Subject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDto>> GetSubject(int id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);
            if (subject == null)
                return NotFound();
            
            return Ok(subject);
        }

        // POST: api/Subject
        [HttpPost]
        public async Task<ActionResult<SubjectDto>> CreateSubject(CreateSubjectRequestDto dto)
        {
            var createdSubject = await _subjectService.CreateSubjectAsync(dto);
            return CreatedAtAction(nameof(GetSubject), new { id = createdSubject.IdSubject }, createdSubject);
        }

        // PUT: api/Subject/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SubjectDto>> UpdateSubject(int id, CreateSubjectRequestDto dto)
        {
            var updatedSubject = await _subjectService.UpdateSubjectAsync(id, dto);
            if (updatedSubject == null)
                return NotFound();
            
            return Ok(updatedSubject);
        }

        // DELETE: api/Subject/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var success = await _subjectService.DeleteSubjectAsync(id);
            if (!success)
                return NotFound();
            
            return NoContent();
        }
    }
}
