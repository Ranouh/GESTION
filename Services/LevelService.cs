using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GESTION.model;
using GESTION.Data;
using GESTION.Dto.Level;
using GESTION.Mappers;

namespace GESTION.Services
{
    public class LevelService
    {
        private readonly DataContext _context;

        public LevelService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LevelDto>> GetAllLevelsAsync()
        {
            var levels = await _context.Levels
                .Include(l => l.SectionScales)
                .Include(l => l.Exams)
                .Include(l => l.ProfLevels)
                .Include(l => l.StudentLevels)
                .ToListAsync();

            return levels.Select(level => level.ToLevelDto());
        }

        public async Task<LevelDto?> GetLevelByIdAsync(int id)
        {
            var level = await _context.Levels
                .Include(l => l.SectionScales)
                .Include(l => l.Exams)
                .Include(l => l.ProfLevels)
                .Include(l => l.StudentLevels)
                .FirstOrDefaultAsync(l => l.IdLevel == id);

            return level?.ToLevelDto();
        }
        public async Task<LevelDto> CreateLevelAsync(CreateLevelRequestDto dto)
        {
            var level = dto.ToLevelFromCreateDto();
            await _context.Levels.AddAsync(level);
            await _context.SaveChangesAsync();
            return level.ToLevelDto();
        }
        public async Task<LevelDto?> UpdateLevelAsync(int id, CreateLevelRequestDto dto)
        {
            var level = await _context.Levels.FirstOrDefaultAsync(l => l.IdLevel == id);
            if (level == null)
            {
                return null;
            }

            level.LevelName = dto.LevelName;
            await _context.SaveChangesAsync();
            return level.ToLevelDto();
        }

        public async Task<bool> DeleteLevelAsync(int id)
        {
            var level = await _context.Levels.FirstOrDefaultAsync(l => l.IdLevel == id);
            if (level == null)
            {
                return false;
            }

            _context.Levels.Remove(level);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
