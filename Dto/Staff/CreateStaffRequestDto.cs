using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GESTION.Dto.Staff
{
    public class CreateStaffRequestDto
    {
        public string? StaffMatricule {get;set;}
        public string? StaffName {get;set;}
        public string? StaffFirstName{get;set;}
        public string? StaffGender{get;set;}
        public string? StaffPhone{get;set;}
        public string? StaffEmail{get;set;}
        public string? StaffHome{get;set;}
        public string? StaffMartialStatus{get;set;}
        public DateTime StaffBirth{get;set;}

        public int VenueId {get;set;}

        public int NationalityId{get;set;}

        public int PrivilegeId{get;set;}

        public int SubjectId {get;set;}
       


    }
}