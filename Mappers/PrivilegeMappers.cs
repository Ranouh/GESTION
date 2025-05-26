using System;
using System.Collections.Generic;
using System.Linq;
using GESTION.model;
using GESTION.Dto.Staff;
using GESTION.Dto.Privilege;
namespace GESTION.Mappers
{
    public static class PrivilegeMappers
    {
        public static PrivilegeDto ToPrivilegeDto(this Privilege privilege)
        {
            if (privilege == null)
            {
                throw new ArgumentNullException(nameof(privilege), "privilege is null");
            }

            return new PrivilegeDto
            {
                IdPrivilege = privilege.IdPrivilege,
                PrivilegeName = privilege.PrivilegeName,
                Staffs = privilege.Staffs?.Select(s=>s.ToStaffDto()).ToList()?? new List<StaffDto>()
            };
        }

        public static Privilege ToPrivilegeFromCreateDto(this CreatePrivilegeRequestDto privilegeDto)
        {
            if (privilegeDto == null)
            {
                throw new ArgumentNullException(nameof(privilegeDto), "privilegeDto is null");
            }

            return new Privilege
            {
                PrivilegeName = privilegeDto.PrivilegeName
            };
        }
    }
}
