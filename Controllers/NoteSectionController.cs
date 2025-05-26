using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GESTION.Dto.NoteSection;
using GESTION.Services;

namespace GESTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteSectionController : ControllerBase
    {
        private readonly NoteSectionService _noteSectionService;

        public NoteSectionController(NoteSectionService noteSectionService)
        {
            _noteSectionService = noteSectionService;
        }

        // GET: api/NoteSection
        [HttpGet]
        public async Task<IActionResult> GetNoteSections()
        {
            var noteSections = await _noteSectionService.GetAllNoteSectionsAsync();
            return Ok(noteSections);
        }

        // GET: api/NoteSection/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteSection([FromRoute] int id)
        {
            var noteSection = await _noteSectionService.GetNoteSectionByIdAsync(id);
            if (noteSection == null)
                return NotFound();

            return Ok(noteSection);
        }

        // POST: api/NoteSection
        [HttpPost]
        public async Task<IActionResult> CreateNoteSection([FromBody] CreateNoteSectionRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdNoteSection = await _noteSectionService.CreateNoteSectionAsync(dto);
            return CreatedAtAction(nameof(GetNoteSection), new { id = createdNoteSection.IdNoteSection }, createdNoteSection);
        }

        // PUT: api/NoteSection/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNoteSection([FromRoute] int id, [FromBody] CreateNoteSectionRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedNoteSection = await _noteSectionService.UpdateNoteSectionAsync(id, dto);
            if (updatedNoteSection == null)
                return NotFound();

            return Ok(updatedNoteSection);
        }

        // DELETE: api/NoteSection/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoteSection([FromRoute] int id)
        {
            var success = await _noteSectionService.DeleteNoteSectionAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
