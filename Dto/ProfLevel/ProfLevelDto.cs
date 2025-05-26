using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GESTION.Dto.ProfLevel
{
    public class ProfLevelDto
    {
        public int IdProfLevel {get;set;}

        public int StaffId{get;set;}
        public string? StaffName {get;set;}

        public int LevelId {get;set;}
        public string? LevelName {get;set;}

        public int PeriodId {get;set;}
        public string? PeriodName{get;set;}
    }
}