using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GESTION.Dto.Period;
using GESTION.Services;

namespace GESTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodController : ControllerBase
    {
        private readonly PeriodService _periodService;

        public PeriodController(PeriodService periodService)
        {
            _periodService = periodService;
        }

        // GET: api/Period
        [HttpGet]
        public async Task<IActionResult> GetPeriods()
        {
            var periods = await _periodService.GetAllPeriodsAsync();
            return Ok(periods);
        }

        // GET: api/Period/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPeriod([FromRoute] int id)
        {
            var period = await _periodService.GetPeriodByIdAsync(id);
            if (period == null)
                return NotFound();

            return Ok(period);
        }

        // POST: api/Period
        [HttpPost]
        public async Task<IActionResult> CreatePeriod([FromBody] CreatePeriodRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdPeriod = await _periodService.CreatePeriodAsync(dto);
            return CreatedAtAction(nameof(GetPeriod), new { id = createdPeriod.IdPeriod }, createdPeriod);
        }

        // PUT: api/Period/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePeriod([FromRoute] int id, [FromBody] CreatePeriodRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedPeriod = await _periodService.UpdatePeriodAsync(id, dto);
            if (updatedPeriod == null)
                return NotFound();

            return Ok(updatedPeriod);
        }

        // DELETE: api/Period/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeriod([FromRoute] int id)
        {
            var success = await _periodService.DeletePeriodAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
