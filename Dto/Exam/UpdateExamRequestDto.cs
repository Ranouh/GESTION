using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GESTION.Dto.Exam
{
    public class UpdateExamRequestDto
    {
        public string? Name { get; set; }
        public DateTime DateCreated { get; set; }
        public int PeriodId { get; set; }
        public int SessionId { get; set; }
        public int LevelId { get; set; }
        public string? Uripath{get;set;}
        public string? UripathAN{get;set;}
    }
}