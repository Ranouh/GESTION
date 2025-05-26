using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using GESTION.Mappers;
using GESTION.Data;
using GESTION.model;
using GESTION.Dto.Exam;


namespace GESTION.Services
{
    public class ExamService
    {
        private readonly DataContext _context;

        public ExamService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExamDto>> GetAllExamsAsync()
        {
            var exams = await _context.Exams
                .Include(e => e.ExamStudents)
                .Include(e => e.Level)
                .Include(e => e.Session)
                .Include(e => e.Period)
                .ToListAsync();

            return exams.Select(exam => exam.ToExamDto());
        }

        public async Task<ExamDto?> GetExamByIdAsync(int id)
        {
            var exam = await _context.Exams
                .Include(e => e.ExamStudents)
                .Include(e => e.Level)
                .Include(e => e.Session)
                .Include(e => e.Period)
                .FirstOrDefaultAsync(e => e.IdExam == id);

            return exam?.ToExamDto();
        }

        public async Task<ExamDto> CreateExamAsync(CreateExamRequestDto dto)
        {
            var exam = dto.ToExamFromCreateDto();
            await _context.Exams.AddAsync(exam);
            await _context.SaveChangesAsync();
            return exam.ToExamDto();
        }

        public async Task<ExamDto?> UpdateExamAsync(int id, UpdateExamRequestDto dto)
        {
            var exam = await _context.Exams.FirstOrDefaultAsync(e => e.IdExam == id);
            if (exam == null)
            {
                return null;
            }

            exam.Name = dto.Name;
            exam.DateCreated = dto.DateCreated;
            exam.LevelId = dto.LevelId;
            exam.SessionId = dto.SessionId;
            exam.PeriodId = dto.PeriodId;

            await _context.SaveChangesAsync();
            return exam.ToExamDto();
        }

        public async Task<bool> DeleteExamAsync(int id)
        {
            var exam = await _context.Exams.FirstOrDefaultAsync(e => e.IdExam == id);
            if (exam == null)
            {
                return false;
            }

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}