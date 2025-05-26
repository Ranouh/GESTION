using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using GESTION.model;
using GESTION.Data;
using GESTION.Dto.Privilege;
using GESTION.Mappers;

namespace GESTION.Services
{
public class PrivilegeService
    {
        private readonly DataContext _context;

        public PrivilegeService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PrivilegeDto>> GetAllPrivilegesAsync()
        {
            var privileges = await _context.Privileges
                .Include(p => p.Staffs)
                .ToListAsync();

            return privileges.Select(p => p.ToPrivilegeDto());
        }

        public async Task<PrivilegeDto?> GetPrivilegeByIdAsync(int id)
        {
            var privilege = await _context.Privileges
                .Include(p => p.Staffs)
                .FirstOrDefaultAsync(p => p.IdPrivilege == id);

            return privilege?.ToPrivilegeDto();
        }

        public async Task<PrivilegeDto> CreatePrivilegeAsync(CreatePrivilegeRequestDto dto)
        {
            var privilege = dto.ToPrivilegeFromCreateDto();

            await _context.Privileges.AddAsync(privilege);
            await _context.SaveChangesAsync();

            return privilege.ToPrivilegeDto();
        }

        public async Task<bool> DeletePrivilegeAsync(int id)
        {
            var privilege = await _context.Privileges.FirstOrDefaultAsync(p => p.IdPrivilege == id);

            if (privilege == null)
            {
                return false;
            }

            _context.Privileges.Remove(privilege);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}