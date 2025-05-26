using System;
using System.Collections.Generic;
using System.Linq;
using GESTION.model;
using GESTION.Dto.ExamStudent;
using GESTION.Dto.NoteSection;

namespace GESTION.Mappers
{
    public static class ExamStudentMappers
    {
        public static ExamStudentDto ToExamStudentDto(this ExamStudent examStudent)
        {
            if (examStudent == null)
                throw new ArgumentNullException(nameof(examStudent), "examStudent is null");

            return new ExamStudentDto
            {
                IdExamStudent = examStudent.IdExamStudent,
                ExamId = examStudent.ExamId,
                ExamName = examStudent.Exam?.Name ?? string.Empty,
                StudentId = examStudent.StudentId,
                StudentName = examStudent.Student?.StudentName ?? string.Empty,
                NoteSections = examStudent.NoteSections?.Select(ns=>ns.ToNoteSectionDto()).ToList() ?? new List <NoteSectionDto>()
            };
        }

        public static ExamStudent ToExamStudentFromCreateDto(this CreateExamStudentRequestDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "dto is null");

            return new ExamStudent
            {
                ExamId = dto.ExamId,
                StudentId = dto.StudentId
            };
        }
    }
}
