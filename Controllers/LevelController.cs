using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GESTION.Dto.Level;
using GESTION.Services;

namespace GESTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly LevelService _levelService;

        public LevelController(LevelService levelService)
        {
            _levelService = levelService;
        }

        // GET: api/Level
        [HttpGet]
        public async Task<IActionResult> GetLevels()
        {
            var levels = await _levelService.GetAllLevelsAsync();
            return Ok(levels);
        }

        // GET: api/Level/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLevel([FromRoute] int id)
        {
            var level = await _levelService.GetLevelByIdAsync(id);
            if (level == null)
                return NotFound();

            return Ok(level);
        }

        // POST: api/Level
        [HttpPost]
        public async Task<IActionResult> CreateLevel([FromBody] CreateLevelRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdLevel = await _levelService.CreateLevelAsync(dto);
            return CreatedAtAction(nameof(GetLevel), new { id = createdLevel.IdLevel }, createdLevel);
        }

        // PUT: api/Level/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLevel([FromRoute] int id, [FromBody] CreateLevelRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedLevel = await _levelService.UpdateLevelAsync(id, dto);
            if (updatedLevel == null)
                return NotFound();

            return Ok(updatedLevel);
        }

        // DELETE: api/Level/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLevel([FromRoute] int id)
        {
            var success = await _levelService.DeleteLevelAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
