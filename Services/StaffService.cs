using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using GESTION.model;
using GESTION.Data;
using GESTION.Dto.Staff;
using GESTION.Mappers;

namespace GESTION.Services
{
    public class StaffService
    {
        private readonly DataContext _context;

        public StaffService(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupère tous les staffs.
        /// </summary>
        /// <returns>Une liste de DTO StaffDto.</returns>
        public async Task<IEnumerable<StaffDto>> GetAllStaffsAsync()
        {
            var staffs = await _context.Staffs
                .Include(s => s.Venue)
                .Include(s => s.Nationality)
                .Include(s => s.Privilege)
                .Include(s => s.Subject)
                .Include(s => s.ProfLevels)
                .ToListAsync();

            return staffs.Select(s => s.ToStaffDto());
        }

        /// <summary>
        /// Récupère un staff par son ID.
        /// </summary>
        /// <param name="id">ID du staff.</param>
        /// <returns>Un DTO StaffDto ou null si non trouvé.</returns>
        public async Task<StaffDto?> GetStaffByIdAsync(int id)
        {
            var staff = await _context.Staffs
                .Include(s => s.Venue)
                .Include(s => s.Nationality)
                .Include(s => s.Privilege)
                .Include(s => s.Subject)
                .Include(s => s.ProfLevels)
                .FirstOrDefaultAsync(s => s.IdStaff == id);

            return staff?.ToStaffDto();
        }

        /// <summary>
        /// Crée un nouveau staff.
        /// </summary>
        /// <param name="createStaffDto">DTO de création de staff.</param>
        /// <returns>Le DTO StaffDto créé.</returns>
        public async Task<StaffDto> CreateStaffAsync(CreateStaffRequestDto createStaffDto)
        {
            if (createStaffDto == null)
            {
                throw new ArgumentNullException(nameof(createStaffDto), "CreateStaffRequestDto is null");
            }

            var staff = createStaffDto.ToStaffFromCreateDto();
            await _context.Staffs.AddAsync(staff);
            await _context.SaveChangesAsync();

            return staff.ToStaffDto();
        }

        /// <summary>
        /// Met à jour un staff existant.
        /// </summary>
        /// <param name="id">ID du staff à mettre à jour.</param>
        /// <param name="updateStaffDto">DTO contenant les nouvelles valeurs.</param>
        /// <returns>Le DTO StaffDto mis à jour ou null si non trouvé.</returns>
        public async Task<StaffDto?> UpdateStaffAsync(int id, UpdateStaffRequestDto updateStaffDto)
        {
            if (updateStaffDto == null)
            {
                throw new ArgumentNullException(nameof(updateStaffDto), "UpdateStaffRequestDto is null");
            }

            var staff = await _context.Staffs.FirstOrDefaultAsync(s => s.IdStaff == id);
            if (staff == null)
            {
                return null;
            }

            staff.StaffMatricule = updateStaffDto.StaffMatricule;
            staff.StaffName = updateStaffDto.StaffName;
            staff.StaffFirstName = updateStaffDto.StaffFirstName;
            staff.StaffGender = updateStaffDto.StaffGender;
            staff.StaffPhone = updateStaffDto.StaffPhone;
            staff.StaffEmail = updateStaffDto.StaffEmail;
            staff.StaffHome = updateStaffDto.StaffHome;
            staff.StaffMartialStatus = updateStaffDto.StaffMartialStatus;
            staff.StaffBirth = updateStaffDto.StaffBirth;
            staff.VenueId = updateStaffDto.VenueId;
            staff.NationalityId = updateStaffDto.NationalityId;
            staff.PrivilegeId = updateStaffDto.PrivilegeId;
            staff.SubjectId = updateStaffDto.SubjectId;

            await _context.SaveChangesAsync();
            return staff.ToStaffDto();
        }

        /// <summary>
        /// Supprime un staff par son ID.
        /// </summary>
        /// <param name="id">ID du staff à supprimer.</param>
        /// <returns>True si supprimé avec succès, false sinon.</returns>
        public async Task<bool> DeleteStaffAsync(int id)
        {
            var staff = await _context.Staffs.FirstOrDefaultAsync(s => s.IdStaff == id);
            if (staff == null)
            {
                return false;
            }

            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}