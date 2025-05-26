using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GESTION.Dto.StudentLevel
{
    public class StudentLevelDto
    {
        public int IdStudentLevel { get; set; }

        public int StudentId { get; set; }
        public  string?  StudentName { get; set; }

        public int LevelId { get; set; }
        public  string? LevelName { get; set; }

        public int PeriodId { get; set; }
        public  string? PeriodName { get; set; }

    }
}