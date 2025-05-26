using System;
using System.Collections.Generic;
using System.Linq;
using GESTION.model;
using GESTION.Dto.StudentLevel;
using GESTION.Dto.Student;
using GESTION.Dto.ExamStudent;
namespace GESTION.Mappers
{
    public static class StudentLevelMappers
    {
        public static StudentLevelDto ToStudentLevelDto(this StudentLevel studentLevel)
        {
            if (studentLevel == null)
            {
                throw new ArgumentNullException(nameof(studentLevel), "studentLevel is null");
            }

            return new StudentLevelDto
            {
                IdStudentLevel = studentLevel.IdStudentLevel,
                StudentId = studentLevel.StudentId,
                StudentName = studentLevel.Student?.StudentName,
                LevelId = studentLevel.LevelId,
                LevelName = studentLevel.Level?.LevelName,
                PeriodId = studentLevel.PeriodId,
                PeriodName = studentLevel.Period?.PeriodName
            };
        }

        public static StudentLevel ToStudentLevelFromCreateDto(this CreateStudentLevelRequestDto studentLevelDto)
        {
            if (studentLevelDto == null)
            {
                throw new ArgumentNullException(nameof(studentLevelDto), "studentLevelDto is null");
            }

            return new StudentLevel
            {
                StudentId = studentLevelDto.StudentId,
                LevelId = studentLevelDto.LevelId,
                PeriodId = studentLevelDto.PeriodId
            };
        }
    }
}
