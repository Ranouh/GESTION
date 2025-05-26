using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GESTION.Dto.ExamStudent;
namespace GESTION.Dto.Exam
{
    public class ExamDto
    {
        public int IdExam { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string Uripath{get;set;}
        public string UripathAN{get;set;}

        public int PeriodId { get; set; }
        public string PeriodName { get; set; }

        public int SessionId { get; set; }
        public string SessionName {get;set;}

        public int LevelId { get; set; }
        public string  LevelName { get; set; }

        public  List<ExamStudentDto> ExamStudents {get;set;}
    }
}