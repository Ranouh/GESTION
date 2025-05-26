using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GESTION.model
{
    public class Exam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdExam { get; set; }

        [Required(ErrorMessage = "Name is Required and cannot be empty")]
        public string? Name { get; set; }
        
        [Required(ErrorMessage = "DateCreated is Required and cannot be empty")]
        public DateTime DateCreated { get; set; }=DateTime.Now;

        [Required(ErrorMessage="Uripath is Required and cannot be empty")]
        public string? Uripath {get;set;}

        [Required(ErrorMessage="Uripath asset note is Required and cannot be empty")]
        public string? UripathAN {get;set;}


        [Required(ErrorMessage = "PeriodId is Required and cannot be empty")]
        public int PeriodId { get; set; }
        public virtual Period Period { get; set; }

        [Required(ErrorMessage = "Session is Required and cannot be empty")]
        public int SessionId { get; set; }
        public virtual Session Session {get;set;}

        [Required(ErrorMessage = "LevelId is Required and cannot be empty")]
        public int LevelId { get; set; }
        public virtual Level Level { get; set; }


        //navigation property
        public virtual ICollection<ExamStudent> ExamStudents {get;set;}
    }
}