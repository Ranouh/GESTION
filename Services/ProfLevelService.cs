using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GESTION.model;
using GESTION.Data;
using GESTION.Dto.ProfLevel;
using GESTION.Mappers;

namespace GESTION.Services
{
    public class ProfLevelService
    {
        private readonly DataContext _context;

        public ProfLevelService(DataContext context)
        {
            _context = context;
        }

        // Obtenir tous les ProfLevels
        public async Task<IEnumerable<ProfLevelDto>> GetAllProfLevelsAsync()
        {
            var profLevels = await _context.ProfLevels
                .Include(pl => pl.Staff)
                .Include(pl => pl.Level) // Correction ici
                .Include(pl => pl.Period)
                .ToListAsync();

            return profLevels.Select(pl => pl.ToProfLevelDto());
        }

        // Obtenir un ProfLevel par ID
        public async Task<ProfLevelDto?> GetProfLevelByIdAsync(int id)
        {
            var profLevel = await _context.ProfLevels
                .Include(pl => pl.Staff)
                .Include(pl => pl.Level) // Correction ici
                .Include(pl => pl.Period)
                .FirstOrDefaultAsync(pl => pl.IdProfLevel == id);

            return profLevel?.ToProfLevelDto();
        }

        // Créer un ProfLevel
        public async Task<ProfLevelDto> CreateProfLevelAsync(CreateProfLevelRequestDto dto)
        {
            var profLevel = dto.ToProfLevelFromCreateDto();
            await _context.ProfLevels.AddAsync(profLevel);
            await _context.SaveChangesAsync();

            return profLevel.ToProfLevelDto();
        }

        // Mettre à jour un ProfLevel
        public async Task<ProfLevelDto?> UpdateProfLevelAsync(int id, CreateProfLevelRequestDto dto)
        {
            var profLevel = await _context.ProfLevels.FirstOrDefaultAsync(pl => pl.IdProfLevel == id);
            if (profLevel == null)
            {
                return null;
            }

            // Mettre à jour les champs
            profLevel.StaffId = dto.StaffId;
            profLevel.LevelId = dto.LevelId; // Vérifiez que cette propriété correspond bien au modèle
            profLevel.PeriodId = dto.PeriodId;

            await _context.SaveChangesAsync();

            return profLevel.ToProfLevelDto();
        }

        // Supprimer un ProfLevel
        public async Task<bool> DeleteProfLevelAsync(int id)
        {
            var profLevel = await _context.ProfLevels.FirstOrDefaultAsync(pl => pl.IdProfLevel == id);
            if (profLevel == null)
            {
                return false;
            }

            _context.ProfLevels.Remove(profLevel);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
