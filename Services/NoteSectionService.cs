using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GESTION.model;
using GESTION.Data;
using GESTION.Dto.NoteSection;
using GESTION.Mappers;

namespace GESTION.Services
{
    public class NoteSectionService
    {
        private readonly DataContext _context;

        public NoteSectionService(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupère toutes les NoteSections.
        /// </summary>
        public async Task<IEnumerable<NoteSectionDto>> GetAllNoteSectionsAsync()
        {
            var noteSections = await _context.NoteSections
                .Include(ns => ns.Section)
                .Include(ns => ns.Comment)
                .Include(ns => ns.ExamStudent)
                .ToListAsync();

            return noteSections.Select(ns => ns.ToNoteSectionDto());
        }

        /// <summary>
        /// Récupère une NoteSection par son ID.
        /// </summary>
        public async Task<NoteSectionDto?> GetNoteSectionByIdAsync(int id)
        {
            var noteSection = await _context.NoteSections
                .Include(ns => ns.Section)
                .Include(ns => ns.Comment)
                .Include(ns => ns.ExamStudent)
                .FirstOrDefaultAsync(ns => ns.IdNoteSection == id);

            return noteSection?.ToNoteSectionDto();
        }

        /// <summary>
        /// Crée une nouvelle NoteSection.
        /// </summary>
        public async Task<NoteSectionDto> CreateNoteSectionAsync(CreateNoteSectionRequestDto dto)
        {
            var noteSection = dto.ToNoteSectionFromCreateDto();
            await _context.NoteSections.AddAsync(noteSection);
            await _context.SaveChangesAsync();
            return noteSection.ToNoteSectionDto();
        }

        /// <summary>
        /// Met à jour une NoteSection existante.
        /// </summary>
        public async Task<NoteSectionDto?> UpdateNoteSectionAsync(int id, CreateNoteSectionRequestDto dto)
        {
            var noteSection = await _context.NoteSections.FirstOrDefaultAsync(ns => ns.IdNoteSection == id);
            if (noteSection == null)
            {
                return null;
            }

            noteSection.note = dto.note;
            noteSection.SectionId = dto.SectionId;
            noteSection.ExamStudentId = dto.ExamStudentId;
            noteSection.CommentId = dto.CommentId;

            await _context.SaveChangesAsync();
            return noteSection.ToNoteSectionDto();
        }

        /// <summary>
        /// Supprime une NoteSection par son ID.
        /// </summary>
        public async Task<bool> DeleteNoteSectionAsync(int id)
        {
            var noteSection = await _context.NoteSections.FirstOrDefaultAsync(ns => ns.IdNoteSection == id);
            if (noteSection == null)
            {
                return false;
            }

            _context.NoteSections.Remove(noteSection);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
