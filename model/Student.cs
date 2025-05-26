using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GESTION.model
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStudent { get; set; }

        [Required(ErrorMessage = "Matricule is required and cannot be empty")]
        public string? StudentMatricule { get; set; }

        [Required(ErrorMessage = "StudentName is required and cannot be empty")]
        public string? StudentName { get; set; }

        [Required(ErrorMessage = "FirstName is required and cannot be empty")]
        public string? StudentFirstName { get; set; }

        [Required(ErrorMessage = "Birth is required and cannot be empty")]
        public DateTime StudentBirth { get; set; }


        [Required(ErrorMessage = "Gender is required and cannot be empty")]
        public string? StudentGender { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required and cannot be empty")]
        public string? StudentPhoneNumber { get; set; }

        [Required(ErrorMessage = "EmailAddress is required and cannot be empty")]
        public string? StudentEmailAddress { get; set; }

        [Required(ErrorMessage = "HomeAddress is required and cannot be empty")]
        public string? StudentHomeAddress { get; set; }

        [Required(ErrorMessage = "VenueId is required and cannot be empty")]
        public int VenueId { get; set; }
        public virtual Venue Venue { get; set; }

        [Required(ErrorMessage = "NationalityId is required and cannot be empty")]
        public int NationalityId { get; set; }
        public virtual Nationality Nationality { get; set; }

        //navigation property
        public virtual ICollection<ExamStudent> ExamStudents {get;set;}
        public virtual ICollection<StudentLevel> StudentLevels { get; set; }
    }
}