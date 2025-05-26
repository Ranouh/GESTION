using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GESTION.model
{
    public class Period
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPeriod { get; set; }


        [Required(ErrorMessage = "Year is required and cannot be empty")]
        public int? Year { get; set; }

        public string? PeriodName {get;set;}

        // Navigation properties
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<StudentLevel> StudentLevels { get; set; }
        public virtual ICollection<ProfLevel> ProfLevels {get;set;}
    }
}