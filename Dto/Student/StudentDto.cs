using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GESTION.Dto.StudentLevel;
using GESTION.Dto.ExamStudent;
namespace GESTION.Dto.Student
{
    public class StudentDto
    {
        public int IdStudent { get; set; }
        public string? StudentMatricule { get; set; }
        public string? StudentName { get; set; }
        public string? StudentFirstName { get; set; }
        public DateTime StudentBirth { get; set; }
        public string? StudentGender { get; set; }
        public string? StudentHomeAddress { get; set; }
        public string? StudentPhoneNumber { get; set; }
        public string? StudentEmailAddress { get; set; }

        public int NationalityId { get; set; }
        public string? NationalityName { get; set; }

        public int VenueId { get; set; }
        public string? VenueName { get; set; }
        //navigation property
        public  List<StudentLevelDto> StudentLevels { get; set; }
        public  List<ExamStudentDto> ExamStudents{get;set;}
    }
}