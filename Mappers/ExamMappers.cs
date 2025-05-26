using System;
using System.Collections.Generic;
using System.Linq;
using GESTION.model;
using GESTION.Dto.Exam;
using GESTION.Dto.ExamStudent;

namespace GESTION.Mappers
{
    public static class ExamMappers
    {
        public static ExamDto ToExamDto(this Exam exam)
        {
            if (exam == null)
                throw new ArgumentNullException(nameof(exam), "exam is null");

            return new ExamDto
            {
                IdExam = exam.IdExam,
                Name = exam.Name,
                DateCreated = exam.DateCreated,
                Uripath = exam.Uripath,
                UripathAN = exam.UripathAN,
                PeriodId = exam.PeriodId,
                PeriodName = exam.Period?.PeriodName ?? string.Empty,
                SessionId = exam.SessionId,
                SessionName = exam.Session?.SessionName ?? string.Empty,
                LevelId = exam.LevelId,
                LevelName = exam.Level?.LevelName?? string.Empty,
                ExamStudents = exam.ExamStudents?.Select(es => es.ToExamStudentDto()).ToList() ?? new List<ExamStudentDto>()
            };
        }

        public static Exam ToExamFromCreateDto(this CreateExamRequestDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "dto is null");

            return new Exam
            {
                Name = dto.Name,
                DateCreated = dto.DateCreated,
                Uripath = dto.Uripath,
                UripathAN = dto.UripathAN,
                PeriodId = dto.PeriodId,
                SessionId = dto.SessionId,
                LevelId = dto.LevelId
                
            };
        }
    }
}
