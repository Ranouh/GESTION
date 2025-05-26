using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GESTION.Dto.Staff;
namespace GESTION.Dto.Privilege
{
    public class PrivilegeDto
    {
        public int IdPrivilege{get;set;}

        public string? PrivilegeName {get;set;}

        public  List<StaffDto> Staffs {get;set;}
    }
}