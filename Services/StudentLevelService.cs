using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GESTION.model;
using GESTION.Data;
using GESTION.Dto.StudentLevel;
using GESTION.Mappers;

namespace GESTION.Services
{
    public class StudentLevelService
    {
        private readonly DataContext _context;

        public StudentLevelService(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Récupère tous les niveaux d'étudiants.
        /// </summary>
        /// <returns>Une liste de DTO StudentLevelDto.</returns>
        public async Task<IEnumerable<StudentLevelDto>> GetAllStudentLevelsAsync()
        {
            var studentLevels = await _context.StudentLevels
                .Include(sl => sl.Student)
                .Include(sl => sl.Level)
                .Include(sl => sl.Period)
                .ToListAsync();

            return studentLevels.Select(sl => sl.ToStudentLevelDto());
        }

        /// <summary>
        /// Récupère un niveau d'étudiant par son ID.
        /// </summary>
        /// <param name="id">ID du niveau d'étudiant.</param>
        /// <returns>Un DTO StudentLevelDto ou null si non trouvé.</returns>
        public async Task<StudentLevelDto?> GetStudentLevelByIdAsync(int id)
        {
            var studentLevel = await _context.StudentLevels
                .Include(sl => sl.Student)
                .Include(sl => sl.Level)
                .Include(sl => sl.Period)
                .FirstOrDefaultAsync(sl => sl.IdStudentLevel == id);

            return studentLevel?.ToStudentLevelDto();
        }

        /// <summary>
        /// Crée un nouveau niveau d'étudiant.
        /// </summary>
        /// <param name="createStudentLevelDto">DTO de création de niveau d'étudiant.</param>
        /// <returns>Le DTO StudentLevelDto créé.</returns>
        public async Task<StudentLevelDto> CreateStudentLevelAsync(CreateStudentLevelRequestDto createStudentLevelDto)
        {
            if (createStudentLevelDto == null)
            {
                throw new ArgumentNullException(nameof(createStudentLevelDto), "CreateStudentLevelRequestDto is null");
            }

            var studentLevel = createStudentLevelDto.ToStudentLevelFromCreateDto();
            await _context.StudentLevels.AddAsync(studentLevel);
            await _context.SaveChangesAsync();

            return studentLevel.ToStudentLevelDto();
        }

        /// <summary>
        /// Met à jour un niveau d'étudiant existant.
        /// </summary>
        /// <param name="id">ID du niveau d'étudiant à mettre à jour.</param>
        /// <param name="updateStudentLevelDto">DTO contenant les nouvelles valeurs.</param>
        /// <returns>Le DTO StudentLevelDto mis à jour ou null si non trouvé.</returns>
        public async Task<StudentLevelDto?> UpdateStudentLevelAsync(int id, UpdateStudentLevelRequestDto updateStudentLevelDto)
        {
            if (updateStudentLevelDto == null)
            {
                throw new ArgumentNullException(nameof(updateStudentLevelDto), "UpdateStudentLevelRequestDto is null");
            }

            var studentLevel = await _context.StudentLevels.FirstOrDefaultAsync(sl => sl.IdStudentLevel == id);
            if (studentLevel == null)
            {
                return null;
            }

            studentLevel.StudentId = updateStudentLevelDto.StudentId;
            studentLevel.LevelId = updateStudentLevelDto.LevelId;
            studentLevel.PeriodId = updateStudentLevelDto.PeriodId;

            await _context.SaveChangesAsync();
            return studentLevel.ToStudentLevelDto();
        }

        /// <summary>
        /// Supprime un niveau d'étudiant par son ID.
        /// </summary>
        /// <param name="id">ID du niveau d'étudiant à supprimer.</param>
        /// <returns>True si supprimé avec succès, false sinon.</returns>
        public async Task<bool> DeleteStudentLevelAsync(int id)
        {
            var studentLevel = await _context.StudentLevels.FirstOrDefaultAsync(sl => sl.IdStudentLevel == id);
            if (studentLevel == null)
            {
                return false;
            }

            _context.StudentLevels.Remove(studentLevel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
