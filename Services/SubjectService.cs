using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GESTION.model;
using GESTION.Data;
using GESTION.Dto.Subject;
using GESTION.Mappers;
namespace GESTION.Services
{
    public class SubjectService
    {
        private readonly DataContext _context;

        public SubjectService(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupère tous les sujets.
        /// </summary>
        /// <returns>Liste de SubjectDto.</returns>
        public async Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync()
        {
            var subjects = await _context.Subjects
                .Include(s => s.SectionScales)
                .ToListAsync();

            return subjects.Select(subject => subject.ToSubjectDto());
        }

        /// <summary>
        /// Récupère un sujet par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant du sujet.</param>
        /// <returns>Un SubjectDto ou null si introuvable.</returns>
        public async Task<SubjectDto?> GetSubjectByIdAsync(int id)
        {
            var subject = await _context.Subjects
                .Include(s => s.SectionScales)
                .FirstOrDefaultAsync(s => s.IdSubject == id);

            return subject?.ToSubjectDto();
        }

        /// <summary>
        /// Crée un nouveau sujet.
        /// </summary>
        /// <param name="dto">Données de création du sujet.</param>
        /// <returns>Le SubjectDto du sujet créé.</returns>
        public async Task<SubjectDto> CreateSubjectAsync(CreateSubjectRequestDto dto)
        {
            var subject = dto.ToSubjectFromCreateDto();
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
            return subject.ToSubjectDto();
        }

        /// <summary>
        /// Met à jour les informations d'un sujet existant.
        /// </summary>
        /// <param name="id">Identifiant du sujet.</param>
        /// <param name="dto">Données de mise à jour.</param>
        /// <returns>Le SubjectDto mis à jour ou null si introuvable.</returns>
        public async Task<SubjectDto?> UpdateSubjectAsync(int id, CreateSubjectRequestDto dto)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.IdSubject == id);
            if (subject == null)
            {
                return null;
            }

            subject.SubjectName = dto.SubjectName;

            await _context.SaveChangesAsync();
            return subject.ToSubjectDto();
        }

        /// <summary>
        /// Supprime un sujet par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant du sujet.</param>
        /// <returns>True si supprimé, sinon false.</returns>
        public async Task<bool> DeleteSubjectAsync(int id)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.IdSubject == id);
            if (subject == null)
            {
                return false;
            }

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}