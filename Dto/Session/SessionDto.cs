using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GESTION.Dto.Exam;
namespace GESTION.Dto.Session
{
    public class SessionDto
    {
        public int IdSession{get;set;}
        public string? SessionName{get;set;}

        public  List<ExamDto> Exams{get;set;}
    }
}