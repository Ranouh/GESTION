using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GESTION.Dto.Nationality;
using GESTION.Services;

namespace GESTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalityController : ControllerBase
    {
        private readonly NationalityService _nationalityService;

        public NationalityController(NationalityService nationalityService)
        {
            _nationalityService = nationalityService;
        }

        // GET: api/Nationality
        [HttpGet]
        public async Task<IActionResult> GetNationalities()
        {
            var nationalities = await _nationalityService.GetAllNationalitiesAsync();
            return Ok(nationalities);
        }

        // GET: api/Nationality/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNationality([FromRoute] int id)
        {
            var nationality = await _nationalityService.GetNationalityByIdAsync(id);
            if (nationality == null)
                return NotFound();

            return Ok(nationality);
        }

        // POST: api/Nationality
        [HttpPost]
        public async Task<IActionResult> CreateNationality([FromBody] CreateNationalityRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdNationality = await _nationalityService.CreateNationalityAsync(dto);
            return CreatedAtAction(nameof(GetNationality), new { id = createdNationality.IdNationality }, createdNationality);
        }

        // PUT: api/Nationality/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNationality([FromRoute] int id, [FromBody] CreateNationalityRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedNationality = await _nationalityService.UpdateNationalityAsync(id, dto);
            if (updatedNationality == null)
                return NotFound();

            return Ok(updatedNationality);
        }

        // DELETE: api/Nationality/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNationality([FromRoute] int id)
        {
            var success = await _nationalityService.DeleteNationalityAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
