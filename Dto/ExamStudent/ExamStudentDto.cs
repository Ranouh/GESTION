using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GESTION.Dto.NoteSection;
namespace GESTION.Dto.ExamStudent
{
    public class ExamStudentDto
    {
        public int IdExamStudent {get;set;}

        public int ExamId{get;set;}
        public string ExamName {get;set;}

        public int StudentId {get;set;}
        public string StudentName {get;set;}

        public List<NoteSectionDto> NoteSections{get;set;}
    }
}