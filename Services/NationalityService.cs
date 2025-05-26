using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using GESTION.model;
using GESTION.Data;
using GESTION.Dto.Nationality;
using GESTION.Mappers;

namespace GESTION.Services
{
    public class NationalityService
    {
        private readonly DataContext _context;

        public NationalityService(DataContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<NationalityDto>> GetAllNationalitiesAsync()
        {
            var nationalities = await _context.Nationalities
                .Include(n => n.Students)
                .ToListAsync();

            return nationalities.Select(n => n.ToNationalityDto());
        }

        public async Task<NationalityDto?> GetNationalityByIdAsync(int id)
        {
            var nationality = await _context.Nationalities
                .Include(n => n.Students)
                .FirstOrDefaultAsync(n => n.IdNationality == id);

            return nationality?.ToNationalityDto();
        }
        public async Task<NationalityDto> CreateNationalityAsync(CreateNationalityRequestDto dto)
        {
            var nationality = dto.ToNationalityFromCreateDto();
            await _context.Nationalities.AddAsync(nationality);
            await _context.SaveChangesAsync();
            return nationality.ToNationalityDto();
        }

        public async Task<NationalityDto?> UpdateNationalityAsync(int id, CreateNationalityRequestDto dto)
        {
            var nationality = await _context.Nationalities.FirstOrDefaultAsync(n => n.IdNationality == id);
            if (nationality == null)
            {
                return null;
            }

            nationality.NationalityName = dto.NationalityName;

            await _context.SaveChangesAsync();
            return nationality.ToNationalityDto();
        }

        public async Task<bool> DeleteNationalityAsync(int id)
        {
            var nationality = await _context.Nationalities.FirstOrDefaultAsync(n => n.IdNationality == id);
            if (nationality == null)
            {
                return false;
            }

            _context.Nationalities.Remove(nationality);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
