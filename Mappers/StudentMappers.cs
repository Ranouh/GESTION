using System;
using System.Collections.Generic;
using System.Linq;
using GESTION.model;
using GESTION.Dto.StudentLevel;
using GESTION.Dto.ExamStudent;
using GESTION.Dto.Student;

namespace GESTION.Mappers
{
    public static class StudentMappers
    {

        public static StudentDto ToStudentDto(this Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student is null");
            }

            return new StudentDto
            {
                IdStudent = student.IdStudent,
                StudentMatricule = student.StudentMatricule,
                StudentName = student.StudentName,
                StudentFirstName = student.StudentFirstName,
                StudentBirth = student.StudentBirth,
                StudentGender = student.StudentGender,
                StudentHomeAddress = student.StudentHomeAddress,
                StudentPhoneNumber = student.StudentPhoneNumber,
                StudentEmailAddress = student.StudentEmailAddress,

                NationalityId = student.NationalityId,
                NationalityName = student.Nationality?.NationalityName,
                VenueId = student.VenueId,
                VenueName = student.Venue?.VenueName,
                ExamStudents = student.ExamStudents?.Select(e => e.ToExamStudentDto()).ToList() ?? new List<ExamStudentDto>(),
                StudentLevels = student.StudentLevels?.Select(s => s.ToStudentLevelDto()).ToList() ?? new List<StudentLevelDto>()
            };
        }

        /// <summary>
        /// Mappe un DTO CreateStudentRequestDto vers une entité Student.
        /// </summary>
        /// <param name="studentDto">DTO de création d'étudiant.</param>
        /// <returns>Une entité Student.</returns>
        public static Student ToStudentFromCreateDto(this CreateStudentRequestDto studentDto)
        {
            if (studentDto == null)
            {
                throw new ArgumentNullException(nameof(studentDto), "CreateStudentRequestDto is null");
            }

            return new Student
            {
                StudentMatricule = studentDto.StudentMatricule,
                StudentName = studentDto.StudentName,
                StudentFirstName = studentDto.StudentFirstName,
                StudentBirth = studentDto.StudentBirth,
                StudentGender = studentDto.StudentGender,
                StudentHomeAddress = studentDto.StudentHomeAddress,
                StudentPhoneNumber = studentDto.StudentPhoneNumber,
                StudentEmailAddress = studentDto.StudentEmailAddress,
                
                NationalityId = studentDto.NationalityId,
                VenueId = studentDto.VenueId
            };
        }
    }
}
