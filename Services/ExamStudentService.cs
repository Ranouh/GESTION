using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GESTION.model;
using GESTION.Data;
using GESTION.Dto.ExamStudent;
using GESTION.Mappers;

namespace GESTION.Services
{
    public class ExamStudentService
    {
        private readonly DataContext _context;

        public ExamStudentService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExamStudentDto>> GetAllExamStudentsAsync()
        {
            var examStudents = await _context.ExamStudents
                .Include(es => es.Exam)
                .Include(es => es.Student)
                .Include(es => es.NoteSections)
                .ToListAsync();

            return examStudents.Select(es => es.ToExamStudentDto());
        }

        public async Task<ExamStudentDto?> GetExamStudentByIdAsync(int id)
        {
            var examStudent = await _context.ExamStudents
                .Include(es => es.Exam)
                .Include(es => es.Student)
                .Include(es => es.NoteSections)
                .FirstOrDefaultAsync(es => es.IdExamStudent == id);

            return examStudent?.ToExamStudentDto();
        }

        public async Task<ExamStudentDto> CreateExamStudentAsync(CreateExamStudentRequestDto dto)
        {
            var examStudent = dto.ToExamStudentFromCreateDto();
            await _context.ExamStudents.AddAsync(examStudent);
            await _context.SaveChangesAsync();
            return examStudent.ToExamStudentDto();
        }

        public async Task<ExamStudentDto?> UpdateExamStudentAsync(int id, UpdateExamStudentRequestDto dto)
        {
            var examStudent = await _context.ExamStudents.FirstOrDefaultAsync(es => es.IdExamStudent == id);
            if (examStudent == null)
            {
                return null;
            }

            examStudent.ExamId = dto.ExamId;
            examStudent.StudentId = dto.StudentId;
            await _context.SaveChangesAsync();

            return examStudent.ToExamStudentDto();
        }

        public async Task<bool> DeleteExamStudentAsync(int id)
        {
            var examStudent = await _context.ExamStudents.FirstOrDefaultAsync(es => es.IdExamStudent == id);
            if (examStudent == null)
            {
                return false;
            }

            _context.ExamStudents.Remove(examStudent);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
