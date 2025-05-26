using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GESTION.Dto.StudentLevel
{
    public class UpdateStudentLevelRequestDto
    {
        public int StudentId { get; set; }
        public int LevelId { get; set; }
        public int PeriodId { get; set; }
    }
}