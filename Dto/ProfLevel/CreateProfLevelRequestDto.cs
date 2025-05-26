using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GESTION.Dto.ProfLevel
{
    public class CreateProfLevelRequestDto
    {
        public int StaffId{get;set;}
        public int LevelId {get;set;}
        public int PeriodId {get;set;}
    }
}