using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GESTION.model;
using GESTION.Data;
using GESTION.Dto.Student;
using GESTION.Mappers;

namespace GESTION.Services
{
    public class StudentService
    {
        private readonly DataContext _context;

        public StudentService(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupère tous les étudiants.
        /// </summary>
        /// <returns>Liste de StudentDto.</returns>
        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _context.Students
                .Include(s => s.Nationality)
                .Include(s => s.Venue)
                .Include(s => s.ExamStudents)
                .Include(s => s.StudentLevels)
                .ToListAsync();

            return students.Select(student => student.ToStudentDto());
        }

        /// <summary>
        /// Récupère un étudiant par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de l'étudiant.</param>
        /// <returns>Un StudentDto ou null si introuvable.</returns>
        public async Task<StudentDto?> GetStudentByIdAsync(int id)
        {
            var student = await _context.Students
                .Include(s => s.Nationality)
                .Include(s => s.Venue)
                .Include(s => s.ExamStudents)
                .Include(s => s.StudentLevels)
                .FirstOrDefaultAsync(s => s.IdStudent == id);

            return student?.ToStudentDto();
        }

        /// <summary>
        /// Crée un nouvel étudiant.
        /// </summary>
        /// <param name="dto">Données de création de l'étudiant.</param>
        /// <returns>Le StudentDto de l'étudiant créé.</returns>
        public async Task<StudentDto> CreateStudentAsync(CreateStudentRequestDto dto)
        {
            var student = dto.ToStudentFromCreateDto();
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student.ToStudentDto();
        }

        /// <summary>
        /// Met à jour les informations d'un étudiant existant.
        /// </summary>
        /// <param name="id">Identifiant de l'étudiant.</param>
        /// <param name="dto">Données de mise à jour.</param>
        /// <returns>Le StudentDto mis à jour ou null si introuvable.</returns>
        public async Task<StudentDto?> UpdateStudentAsync(int id, CreateStudentRequestDto dto)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.IdStudent == id);
            if (student == null)
            {
                return null;
            }

            student.StudentMatricule = dto.StudentMatricule;
            student.StudentName = dto.StudentName;
            student.StudentFirstName = dto.StudentFirstName;
            student.StudentBirth = dto.StudentBirth;
            student.StudentGender = dto.StudentGender;
            student.StudentHomeAddress = dto.StudentHomeAddress;
            student.StudentPhoneNumber = dto.StudentPhoneNumber;
            student.StudentEmailAddress = dto.StudentEmailAddress;

            student.NationalityId = dto.NationalityId;
            student.VenueId = dto.VenueId;

            await _context.SaveChangesAsync();
            return student.ToStudentDto();
        }

        /// <summary>
        /// Supprime un étudiant par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de l'étudiant.</param>
        /// <returns>True si supprimé, sinon false.</returns>
        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.IdStudent == id);
            if (student == null)
            {
                return false;
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
