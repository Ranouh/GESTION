using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GESTION.Dto.Exam;
using GESTION.Dto.StudentLevel;
using GESTION.Dto.ProfLevel;
namespace GESTION.Dto.Period
{
    public class PeriodDto
    {
        public int IdPeriod { get; set; }
        public int? Year { get; set; }
        public string? PeriodName {get;set;}

        public  List<ExamDto> Exams { get; set; }
        public  List<StudentLevelDto> StudentLevels { get; set; }
        public  List<ProfLevelDto> ProfLevels {get;set;}
    }
}