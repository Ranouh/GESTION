using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GESTION.Dto.SectionScale;
using GESTION.Services;

namespace GESTION.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectionScaleController : ControllerBase
    {
        private readonly SectionScaleService _sectionScaleService;

        public SectionScaleController(SectionScaleService sectionScaleService)
        {
            _sectionScaleService = sectionScaleService;
        }

        // GET: api/SectionScale
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SectionScaleDto>>> GetSectionScales()
        {
            var sectionScales = await _sectionScaleService.GetAllSectionScalesAsync();
            return Ok(sectionScales);
        }

        // GET: api/SectionScale/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SectionScaleDto>> GetSectionScale(int id)
        {
            var sectionScale = await _sectionScaleService.GetSectionScaleByIdAsync(id);
            if (sectionScale == null)
                return NotFound();

            return Ok(sectionScale);
        }

        // POST: api/SectionScale
        [HttpPost]
        public async Task<ActionResult<SectionScaleDto>> CreateSectionScale(CreateSectionScaleRequestDto dto)
        {
            var created = await _sectionScaleService.CreateSectionScaleAsync(dto);
            return CreatedAtAction(nameof(GetSectionScale), new { id = created.IdSectionScale }, created);
        }

        // PUT: api/SectionScale/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SectionScaleDto>> UpdateSectionScale(int id, UpdateSectionScaleRequestDto dto)
        {
            var updated = await _sectionScaleService.UpdateSectionScaleAsync(id, dto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE: api/SectionScale/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSectionScale(int id)
        {
            var success = await _sectionScaleService.DeleteSectionScaleAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
