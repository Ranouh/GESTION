using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GESTION.model
{
    public class StudentLevel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStudentLevel { get; set; }

        [Required(ErrorMessage = "StudentId is required and cannot be empty")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "LevelId is required and cannot be empty")]
        public int LevelId { get; set; }

        [Required(ErrorMessage = "PeriodId is required and cannot be empty")]
        public int PeriodId { get; set; }

        //navigation property
        public virtual Student Student { get; set; }
        public virtual Level Level { get; set; }
        public virtual Period Period { get; set; }
    }
}