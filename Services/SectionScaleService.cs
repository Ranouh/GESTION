using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GESTION.model;
using GESTION.Data;
using GESTION.Dto.SectionScale;
using GESTION.Mappers;

namespace GESTION.Services
{
    public class SectionScaleService
    {
        private readonly DataContext _context;

        public SectionScaleService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SectionScaleDto>> GetAllSectionScalesAsync()
        {
            var sectionScales = await _context.SectionScales
                .Include(ss => ss.Section)
                .Include(ss => ss.Level)
                .Include(ss => ss.Subject)
                .ToListAsync();

            return sectionScales.Select(ss => ss.ToSectionScaleDto());
        }

        public async Task<SectionScaleDto?> GetSectionScaleByIdAsync(int id)
        {
            var sectionScale = await _context.SectionScales
                .Include(ss => ss.Section)
                .Include(ss => ss.Level)
                .Include(ss => ss.Subject)
                .FirstOrDefaultAsync(ss => ss.IdSectionScale == id);

            return sectionScale?.ToSectionScaleDto();
        }

        public async Task<SectionScaleDto> CreateSectionScaleAsync(CreateSectionScaleRequestDto dto)
        {
            var sectionScale = dto.ToSectionScaleFromCreateDto();
            await _context.SectionScales.AddAsync(sectionScale);
            await _context.SaveChangesAsync();

            return sectionScale.ToSectionScaleDto();
        }

        public async Task<SectionScaleDto?> UpdateSectionScaleAsync(int id, UpdateSectionScaleRequestDto dto)
        {
            var sectionScale = await _context.SectionScales.FirstOrDefaultAsync(ss => ss.IdSectionScale == id);
            if (sectionScale == null)
            {
                return null;
            }

            sectionScale.scale = dto.scale;
            sectionScale.SectionId = dto.SectionId;
            sectionScale.LevelId = dto.LevelId;
            sectionScale.SubjectId = dto.SubjectId;

            await _context.SaveChangesAsync();
            return sectionScale.ToSectionScaleDto();
        }

        public async Task<bool> DeleteSectionScaleAsync(int id)
        {
            var sectionScale = await _context.SectionScales.FirstOrDefaultAsync(ss => ss.IdSectionScale == id);
            if (sectionScale == null)
            {
                return false;
            }

            _context.SectionScales.Remove(sectionScale);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
