using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GESTION.Dto.ExamStudent
{
    public class CreateExamStudentRequestDto
    {
        public int ExamId { get; set; }
        public int StudentId { get; set; }
    }
}