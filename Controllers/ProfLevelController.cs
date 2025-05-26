using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GESTION.Dto.ProfLevel;
using GESTION.Services;

namespace GESTION.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfLevelController : ControllerBase
    {
        private readonly ProfLevelService _profLevelService;

        public ProfLevelController(ProfLevelService profLevelService)
        {
            _profLevelService = profLevelService;
        }

        // GET: api/ProfLevel
        [HttpGet]
        public async Task<IActionResult> GetProfLevels()
        {
            var profLevels = await _profLevelService.GetAllProfLevelsAsync();
            return Ok(profLevels);
        }

        // GET: api/ProfLevel/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfLevel(int id)
        {
            var profLevel = await _profLevelService.GetProfLevelByIdAsync(id);
            if (profLevel == null)
                return NotFound();

            return Ok(profLevel);
        }

        // POST: api/ProfLevel
        [HttpPost]
        public async Task<IActionResult> CreateProfLevel([FromBody] CreateProfLevelRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdProfLevel = await _profLevelService.CreateProfLevelAsync(dto);
            return CreatedAtAction(nameof(GetProfLevel), new { id = createdProfLevel.IdProfLevel }, createdProfLevel);
        }

        // PUT: api/ProfLevel/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfLevel(int id, [FromBody] CreateProfLevelRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedProfLevel = await _profLevelService.UpdateProfLevelAsync(id, dto);
            if (updatedProfLevel == null)
                return NotFound();

            return Ok(updatedProfLevel);
        }

        // DELETE: api/ProfLevel/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfLevel(int id)
        {
            var deleted = await _profLevelService.DeleteProfLevelAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
