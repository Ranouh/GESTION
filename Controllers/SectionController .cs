using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GESTION.Dto.Section;
using GESTION.Services;

namespace GESTION.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectionController : ControllerBase
    {
        private readonly SectionService _sectionService;

        public SectionController(SectionService sectionService)
        {
            _sectionService = sectionService;
        }

        // GET: api/Section
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SectionDto>>> GetSections()
        {
            var sections = await _sectionService.GetAllSectionsAsync();
            return Ok(sections);
        }

        // GET: api/Section/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SectionDto>> GetSection(int id)
        {
            var section = await _sectionService.GetSectionByIdAsync(id);
            if (section == null)
                return NotFound();

            return Ok(section);
        }

        // POST: api/Section
        [HttpPost]
        public async Task<ActionResult<SectionDto>> CreateSection(CreateSectionRequestDto dto)
        {
            var createdSection = await _sectionService.CreateSectionAsync(dto);
            return CreatedAtAction(nameof(GetSection), new { id = createdSection.IdSection }, createdSection);
        }

        // PUT: api/Section/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SectionDto>> UpdateSection(int id, UpdateSectionRequestDto dto)
        {
            var updatedSection = await _sectionService.UpdateSectionAsync(id, dto);
            if (updatedSection == null)
                return NotFound();

            return Ok(updatedSection);
        }

        // DELETE: api/Section/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSection(int id)
        {
            var success = await _sectionService.DeleteSectionAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
