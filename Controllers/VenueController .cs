using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GESTION.Dto.Venue;
using GESTION.Services;
namespace GESTION.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VenueController : ControllerBase
    {
        private readonly VenueService _venueService;

        public VenueController(VenueService venueService)
        {
            _venueService = venueService;
        }

        // GET: api/Venue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VenueDto>>> GetVenues()
        {
            var venues = await _venueService.GetAllVenuesAsync();
            return Ok(venues);
        }

        // GET: api/Venue/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VenueDto>> GetVenue(int id)
        {
            var venue = await _venueService.GetVenueByIdAsync(id);
            if (venue == null)
                return NotFound();

            return Ok(venue);
        }

        // POST: api/Venue
        [HttpPost]
        public async Task<ActionResult<VenueDto>> CreateVenue(CreateVenueRequestDto dto)
        {
            var createdVenue = await _venueService.CreateVenueAsync(dto);
            return CreatedAtAction(nameof(GetVenue), new { id = createdVenue.IdVenue }, createdVenue);
        }

        // PUT: api/Venue/5
        [HttpPut("{id}")]
        public async Task<ActionResult<VenueDto>> UpdateVenue(int id, CreateVenueRequestDto dto)
        {
            var updatedVenue = await _venueService.UpdateVenueAsync(id, dto);
            if (updatedVenue == null)
                return NotFound();

            return Ok(updatedVenue);
        }

        // DELETE: api/Venue/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenue(int id)
        {
            var success = await _venueService.DeleteVenueAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
