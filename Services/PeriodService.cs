using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GESTION.model;
using GESTION.Data;
using GESTION.Dto.Period;
using GESTION.Mappers;

namespace GESTION.Services
{
    public class PeriodService
    {
        private readonly DataContext _context;

        public PeriodService(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupère toutes les périodes.
        /// </summary>
        public async Task<IEnumerable<PeriodDto>> GetAllPeriodsAsync()
        {
            var periods = await _context.Periods
                .Include(p => p.ProfLevels)
                .Include(p => p.Exams)
                .Include(p => p.StudentLevels)
                .ToListAsync();

            return periods.Select(p => p.ToPeriodDto());
        }

        /// <summary>
        /// Récupère une période par son ID.
        /// </summary>
        public async Task<PeriodDto?> GetPeriodByIdAsync(int id)
        {
            var period = await _context.Periods
                .Include(p => p.ProfLevels)
                .Include(p => p.Exams)
                .Include(p => p.StudentLevels)
                .FirstOrDefaultAsync(p => p.IdPeriod == id);

            return period?.ToPeriodDto();
        }

        /// <summary>
        /// Crée une nouvelle période.
        /// </summary>
        public async Task<PeriodDto> CreatePeriodAsync(CreatePeriodRequestDto dto)
        {
            var period = dto.ToPeriodFromCreateDto();
            await _context.Periods.AddAsync(period);
            await _context.SaveChangesAsync();
            return period.ToPeriodDto();
        }

        /// <summary>
        /// Met à jour une période existante.
        /// </summary>
        public async Task<PeriodDto?> UpdatePeriodAsync(int id, CreatePeriodRequestDto dto)
        {
            var period = await _context.Periods.FirstOrDefaultAsync(p => p.IdPeriod == id);
            if (period == null)
            {
                return null;
            }

            period.Year = dto.Year;
            period.PeriodName = dto.PeriodName;

            await _context.SaveChangesAsync();
            return period.ToPeriodDto();
        }

        /// <summary>
        /// Supprime une période par son ID.
        /// </summary>
        public async Task<bool> DeletePeriodAsync(int id)
        {
            var period = await _context.Periods.FirstOrDefaultAsync(p => p.IdPeriod == id);
            if (period == null)
            {
                return false;
            }

            _context.Periods.Remove(period);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
