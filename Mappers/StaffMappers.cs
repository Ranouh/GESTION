using System;
using System.Collections.Generic;
using System.Linq;
using GESTION.model;
using GESTION.Dto.ProfLevel;
using GESTION.Dto.Staff;
namespace GESTION.Mappers
{
    public static class StaffMappers
    {
        public static StaffDto ToStaffDto(this Staff staff)
        {
            if (staff == null)
            {
                throw new ArgumentNullException(nameof(staff), "Staff is null");
            }

            return new StaffDto
            {
                IdStaff = staff.IdStaff,
                StaffMatricule = staff.StaffMatricule,
                StaffName = staff.StaffName,
                StaffFirstName = staff.StaffFirstName,
                StaffGender = staff.StaffGender,
                StaffPhone = staff.StaffPhone,
                StaffEmail = staff.StaffEmail,
                StaffHome = staff.StaffHome,
                StaffMartialStatus = staff.StaffMartialStatus,
                StaffBirth = staff.StaffBirth,

                VenueId = staff.VenueId,
                VenueName = staff.Venue?.VenueName,
                NationalityId = staff.NationalityId,
                NationalityName = staff.Nationality?.NationalityName,
                PrivilegeId = staff.PrivilegeId,
                PrivilegeName = staff.Privilege?.PrivilegeName,
                SubjectId = staff.SubjectId,
                SubjectName = staff.Subject?.SubjectName,

                ProfLevels = staff.ProfLevels?.Select(pl=>pl.ToProfLevelDto()).ToList()?? new List<ProfLevelDto>()
            };
        }

        public static Staff ToStaffFromCreateDto(this CreateStaffRequestDto staffDto)
        {
            if (staffDto == null)
            {
                throw new ArgumentNullException(nameof(staffDto), "staffDto is null");
            }

            return new Staff
            {
                StaffMatricule = staffDto.StaffMatricule,
                StaffName = staffDto.StaffName,
                StaffFirstName = staffDto.StaffFirstName,
                StaffGender = staffDto.StaffGender,
                StaffPhone = staffDto.StaffPhone,
                StaffEmail = staffDto.StaffEmail,
                StaffHome = staffDto.StaffHome,
                StaffMartialStatus = staffDto.StaffMartialStatus,
                StaffBirth = staffDto.StaffBirth,

                VenueId = staffDto.VenueId,
                NationalityId = staffDto.NationalityId,
                PrivilegeId = staffDto.PrivilegeId,
                SubjectId = staffDto.SubjectId,
            };
        }
    }
}
