using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GESTION.Dto.Exam;
using GESTION.Dto.ProfLevel;
using GESTION.Dto.StudentLevel;
using GESTION.Dto.SectionScale;


namespace GESTION.Dto.Level
{
    public class LevelDto
    {
        public int IdLevel { get; set; }
        public string? LevelName { get; set; }

        public List<ExamDto> Exams { get; set; }
        public List<ProfLevelDto> ProfLevels {get;set;}
        public List<StudentLevelDto> StudentLevels { get; set; }
        public List<SectionScaleDto> SectionScales {get;set;}
    }
}