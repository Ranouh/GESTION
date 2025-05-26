using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GESTION.Dto.Session;
using GESTION.Services;

namespace GESTION.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly SessionService _sessionService;

        public SessionController(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        // GET: api/Session
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessionDto>>> GetSessions()
        {
            var sessions = await _sessionService.GetAllSessionsAsync();
            return Ok(sessions);
        }

        // GET: api/Session/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SessionDto>> GetSession(int id)
        {
            var session = await _sessionService.GetSessionByIdAsync(id);
            if (session == null)
                return NotFound();

            return Ok(session);
        }

        // POST: api/Session
        [HttpPost]
        public async Task<ActionResult<SessionDto>> CreateSession(CreateSessionRequestDto dto)
        {
            var created = await _sessionService.CreateSessionAsync(dto);
            return CreatedAtAction(nameof(GetSession), new { id = created.IdSession }, created);
        }

        // PUT: api/Session/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SessionDto>> UpdateSession(int id, CreateSessionRequestDto dto)
        {
            var updated = await _sessionService.UpdateSessionAsync(id, dto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE: api/Session/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(int id)
        {
            var success = await _sessionService.DeleteSessionAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
