using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GESTION.model;
using GESTION.Data;
using GESTION.Dto.Section;
using GESTION.Mappers;

namespace GESTION.Services
{
    public class SectionService
    {
        private readonly DataContext _context;

        public SectionService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SectionDto>> GetAllSectionsAsync()
        {
            var sections = await _context.Sections
                .Include(s => s.NoteSections)
                .Include(s=>s.SectionScales)
                .ToListAsync();

            return sections.Select(s => s.ToSectionDto());
        }

        public async Task<SectionDto?> GetSectionByIdAsync(int id)
        {
            var section = await _context.Sections
                .Include(s => s.NoteSections)
                .Include(s=>s.SectionScales)
                .FirstOrDefaultAsync(s => s.IdSection == id);

            return section?.ToSectionDto();
        }

        public async Task<SectionDto> CreateSectionAsync(CreateSectionRequestDto dto)
        {
            var section = dto.ToSectionFromCreateDto();
            await _context.Sections.AddAsync(section);
            await _context.SaveChangesAsync();
            return section.ToSectionDto();
        }

        public async Task<SectionDto?> UpdateSectionAsync(int id, UpdateSectionRequestDto dto)
        {
            var section = await _context.Sections.FirstOrDefaultAsync(s => s.IdSection == id);
            if (section == null)
            {
                return null;
            }

            section.SectionName = dto.SectionName;

            await _context.SaveChangesAsync();
            return section.ToSectionDto();
        }

        public async Task<bool> DeleteSectionAsync(int id)
        {
            var section = await _context.Sections.FirstOrDefaultAsync(s => s.IdSection == id);
            if (section == null)
            {
                return false;
            }

            _context.Sections.Remove(section);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
