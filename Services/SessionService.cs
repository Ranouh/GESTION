using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GESTION.model;
using GESTION.Data;
using GESTION.Dto.Session;
using GESTION.Mappers;
namespace GESTION.Services
{
    public class SessionService
    {
        private readonly DataContext _context;

        public SessionService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SessionDto>> GetAllSessionsAsync()
        {
            var sessions = await _context.Sessions
                .Include(s => s.Exams)
                .ToListAsync();

            return sessions.Select(s => s.ToSessionDto());
        }

        public async Task<SessionDto?> GetSessionByIdAsync(int id)
        {
            var session = await _context.Sessions
                .Include(s => s.Exams)
                .FirstOrDefaultAsync(s => s.IdSession == id);

            return session?.ToSessionDto();
        }

        public async Task<SessionDto> CreateSessionAsync(CreateSessionRequestDto dto)
        {
            var session = dto.ToSessionFromCreateDto();
            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();
            return session.ToSessionDto();
        }

        public async Task<SessionDto?> UpdateSessionAsync(int id, CreateSessionRequestDto dto)
        {
            var session = await _context.Sessions.FirstOrDefaultAsync(s => s.IdSession == id);
            if (session == null)
                return null;

            session.SessionName = dto.SessionName;

            await _context.SaveChangesAsync();
            return session.ToSessionDto();
        }

        public async Task<bool> DeleteSessionAsync(int id)
        {
            var session = await _context.Sessions.FirstOrDefaultAsync(s => s.IdSession == id);
            if (session == null)
                return false;

            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
